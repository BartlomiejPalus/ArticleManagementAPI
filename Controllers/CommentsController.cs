using ArticleManagementAPI.Common;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Controllers
{
	[Route("api/comments")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentService _commentService;

		public CommentsController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[HttpGet("{commentId}")]
		public async Task<IActionResult> GetCommentById([FromRoute] int commentId)
		{
			var result = await _commentService.GetCommentByIdAsync(commentId);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}
	}
}
