using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Middleware
{
	public class ErrorHandlingMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next.Invoke(context);
			}
			catch (DbUpdateException)
			{
				await WriteErrorResponse(context, StatusCodes.Status500InternalServerError, "Database error occurred");
			}
			catch (Exception)
			{
				await WriteErrorResponse(context, StatusCodes.Status500InternalServerError, "Internal server error");
			}
		}

		private async Task WriteErrorResponse(HttpContext context, int statusCode, string message)
		{
			context.Response.StatusCode = statusCode;

			var error = new
			{
				status = statusCode,
				error = message
			};

			await context.Response.WriteAsJsonAsync(error);
		}
	}
}
