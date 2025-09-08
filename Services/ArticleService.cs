using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Article;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Repositories.Interfaces;
using ArticleManagementAPI.Services.Interfaces;

namespace ArticleManagementAPI.Services
{
	public class ArticleService : IArticleService
	{
		private readonly IArticleRepository _articleRepository;

		public ArticleService(IArticleRepository articleRepository)
		{
			_articleRepository = articleRepository;
		}

		public async Task<Result<ArticleDto>> GetArticleByIdAsync(int id)
		{
			var article = await _articleRepository.GetByIdAsync(id);

			if (article == null)
				return Result<ArticleDto>.Failure(ErrorType.NotFound, "Article not found");

			var articleDto = new ArticleDto
			{
				Id = article.Id,
				Title = article.Title,
				Content = article.Content,
				CreatedAt = article.CreatedAt,
				Author = article.User.Name,
				Categories = article.Categories.Select(
					c => new CategoryDto
					{
						Id = c.Id,
						Name = c.Name.ToString()
					}).ToList()
			};

			return Result<ArticleDto>.Success(articleDto);
		}
	}
}
