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

		[HttpGet("/api/articles/{articleId}/comments")]
		public async Task<IActionResult> GetCommentsByArticleId([FromRoute] int articleId, [FromQuery] CommentFilterDto dto)
		{
			var result = await _commentService.GetCommentsAsync(null, articleId, dto);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}

		[HttpGet("/api/users/{userId}/comments")]
		public async Task<IActionResult> GetCommentsByUserId([FromRoute] Guid userId, [FromQuery] CommentFilterDto dto)
		{
			var result = await _commentService.GetCommentsAsync(userId, null, dto);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}

		[HttpPut("{commentId}")]
		[Authorize]
		public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromBody] CommentRequestDto dto)
		{
			var currentUserId = User.GetUserId();

			var result = await _commentService.UpdateCommentAsync(currentUserId, commentId, dto);

			if (result.IsSuccess)
				return NoContent();

			return result.ToErrorActionResult(this);
		}

		[HttpDelete("{commentId}")]
		[Authorize]
		public async Task<IActionResult> RemoveComment([FromRoute] int commentId)
		{
			var currentUserId = User.GetUserId();

			if (currentUserId == Guid.Empty)
				return BadRequest("Invalid user ID format");

			var isAdmin = User.IsInRole("Admin");

			var result = await _commentService.RemoveCommentAsync(currentUserId, isAdmin, commentId);

			if (result.IsSuccess)
				return NoContent();

			return result.ToErrorActionResult(this);
		}
	}
}
