using ArticleManagementAPI.Common;
using ArticleManagementAPI.Services.Interfaces;
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

		[HttpGet("{articleId}")]
		public async Task<IActionResult> GetArticleById([FromRoute] int articleId)
		{
			var result = await _articleService.GetArticleByIdAsync(articleId);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}
	}
}
