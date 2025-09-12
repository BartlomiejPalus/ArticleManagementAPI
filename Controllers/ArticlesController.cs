using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Article;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Controllers
{
	[Route("api/articles")]
	[ApiController]
	public class ArticlesController : ControllerBase
	{
		private readonly IArticleService _articleService;

		public ArticlesController(IArticleService articleService)
		{
			_articleService = articleService;
		}

		[HttpPost]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> AddArticle([FromBody] AddArticleDto dto)
		{
			var currentUserId = User.GetUserId();

			if (currentUserId == Guid.Empty)
				return BadRequest("Invalid user ID format");

			var result = await _articleService.AddArticleAsync(currentUserId, dto);

			if (result.IsSuccess)
			{
				var articleDto = result.Value;
				return CreatedAtAction(nameof(GetArticleById), new { articleId = articleDto.Id }, articleDto);
			}

			return result.ToErrorActionResult(this);
		}

		[HttpGet("{articleId}")]
		public async Task<IActionResult> GetArticleById([FromRoute] int articleId)
		{
			var result = await _articleService.GetArticleByIdAsync(articleId);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}

		[HttpGet]
		public async Task<IActionResult> GetArticles([FromQuery] ArticleFilterDto filter)
		{
			var currentUserId = User.GetUserId();

			var canSeeAll = User.IsInRole("Admin") || User.IsInRole("Reviewer");
			
			var result = await _articleService.GetArticlesAsync(currentUserId, canSeeAll, filter);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}

		[HttpPatch("{articleId}/visibility")]
		[Authorize(Roles = "Admin, Reviewer")]
		public async Task<IActionResult> UpdateVisibility([FromRoute] int articleId, [FromBody] UpdateVisibilityDto dto)
		{
			var result = await _articleService.UpdateVisibilityAsync(articleId, dto);
			
			if (result.IsSuccess)
				return NoContent();
			
			return result.ToErrorActionResult(this);
		}

		[HttpDelete("{articleId}")]
		[Authorize(Roles = "Admin, Writer")]
		public async Task<IActionResult> RemoveArticle([FromRoute] int articleId)
		{
			var currentUserId = User.GetUserId();

			if (currentUserId == Guid.Empty)
				return BadRequest("Invalid user ID format");

			var isAdmin = User.IsInRole("Admin");

			var result = await _articleService.RemoveArticleAsync(articleId, currentUserId, isAdmin);

			if (result.IsSuccess)
				return NoContent();

			return result.ToErrorActionResult(this);
		}
	}
}
