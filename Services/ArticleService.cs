using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Article;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Models;
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

		public async Task<Result<ArticleAdminDto>> AddArticleAsync(Guid userId, AddArticleDto dto)
		{
			var categoryIds = dto.CategoryIds.Distinct();
			var categories = await _articleRepository.GetCategoriesByIdAsync(categoryIds);

			var newArticle = new Article
			{
				Title = dto.Title,
				Content = dto.Content,
				UserId = userId,
				Categories = categories
			};

			await _articleRepository.AddAsync(newArticle);

			var articleDto = new ArticleAdminDto
			{
				Id = newArticle.Id,
				Title = newArticle.Title,
				Content = newArticle.Content,
				CreatedAt = newArticle.CreatedAt,
				AuthorId = newArticle.UserId,
				IsPublished = newArticle.IsPublished,
				Categories = newArticle.Categories.Select(
					c => new CategoryDto
					{
						Id = c.Id,
						Name = c.Name.ToString()
					}).ToList()
			};

			return Result<ArticleAdminDto>.Success(articleDto);
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
				AuthorName = article.User.Name,
				AuthorId = article.UserId,
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
