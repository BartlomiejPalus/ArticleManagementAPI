using ArticleManagementAPI.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Common
{
	public class Result
	{
		public bool IsSuccess { get; }
		public bool IsFailure => !IsSuccess;
		public ErrorType? ErrorType { get; }
		public string? ErrorMessage { get; }

		protected Result(bool isSuccess, ErrorType? error, string? message)
		{
			IsSuccess = isSuccess;
			ErrorType = error;
			ErrorMessage = message;
		}

		public static Result Success() => new (true, null, null);

		public static Result Failure(ErrorType error, string message) => new (false, error, message);
	}

	public class Result<T> : Result
	{
		public T? Value { get; }

		protected Result(bool isSuccess, ErrorType? error, string? message, T? value) : base(isSuccess, error, message)
		{
			Value = value;
		}

		public static Result<T> Success(T value) => new (true, null, null, value);

		public static new Result<T> Failure(ErrorType error, string message) => new (false, error, message, default);
	}

	public static class ResultExtensions
	{
		public static IActionResult ToErrorActionResult(this Result result, ControllerBase controller)
		{
			if (result.IsSuccess)
				throw new InvalidOperationException("Cannot map a successful result to an error response.");

			return result.ErrorType switch
			{
				ErrorType.BadRequest => controller.BadRequest(result.ErrorMessage),
				ErrorType.Unauthorized => controller.Unauthorized(result.ErrorMessage),
				ErrorType.NotFound => controller.NotFound(result.ErrorMessage),
				ErrorType.InternalServerError => controller.StatusCode(500, result.ErrorMessage),
				_ => controller.StatusCode(500, "Unexpected error")
			};
		}
	}
}
