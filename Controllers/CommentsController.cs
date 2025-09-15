using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Comment;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

		[HttpPost("/api/articles/{articleId}/comments")]
		[Authorize]
		public async Task<IActionResult> AddComment([FromRoute] int articleId, [FromBody] CommentRequestDto dto)
		{
			var userId = User.GetUserId();

			var result = await _commentService.AddCommentAsync(userId, articleId, dto);

			if (result.IsSuccess)
			{
				var commentDto = result.Value;
				return CreatedAtAction(nameof(GetCommentById), new { commentId = commentDto.Id }, commentDto);
			}
			
			return result.ToErrorActionResult(this);
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
