using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Article;
using ArticleManagementAPI.DTOs.Common;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Services
{
	public class ArticleService : IArticleService
	{
		private readonly IArticleRepository _articleRepository;

		public ArticleService(IArticleRepository articleRepository)
		{
			_articleRepository = articleRepository;
		}

		public async Task<Result<ArticleDetailsDto>> AddArticleAsync(Guid userId, AddArticleDto dto)
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

			var articleDetailsDto = new ArticleDetailsDto
			{
				Id = newArticle.Id,
				Title = newArticle.Title,
				Content = newArticle.Content,
				CreatedAt = newArticle.CreatedAt,
				AuthorName = newArticle.User.Name,
				AuthorId = newArticle.UserId,
				IsPublished = newArticle.IsPublished,
				Categories = newArticle.Categories.Select(
					c => new CategoryDto
					{
						Id = c.Id,
						Name = c.Name.ToString()
					}).ToList()
			};

			return Result<ArticleDetailsDto>.Success(articleDetailsDto);
		}

		public async Task<Result<ArticleDetailsDto>> GetArticleByIdAsync(int id)
		{
			var article = await _articleRepository.GetByIdAsync(id);

			if (article == null)
				return Result<ArticleDetailsDto>.Failure(ErrorType.NotFound, "Article not found");

			var articleDetailsDto = new ArticleDetailsDto
			{
				Id = article.Id,
				Title = article.Title,
				Content = article.Content,
				CreatedAt = article.CreatedAt,
				AuthorName = article.User.Name,
				AuthorId = article.UserId,
				IsPublished = article.IsPublished,
				Categories = article.Categories.Select(
					c => new CategoryDto
					{
						Id = c.Id,
						Name = c.Name.ToString()
					}).ToList()
			};

			return Result<ArticleDetailsDto>.Success(articleDetailsDto);
		}

		public async Task<Result<PagedResultDto<ArticleListDto>>> GetArticlesAsync(Guid userId, bool canSeeAll, ArticleFilterDto filter)
		{
			var query = _articleRepository.GetArticles();

			query = ApplyFilters(query, userId, canSeeAll, filter);

			query = ApplySorting(query, filter);

			var totalCount = await query.CountAsync();

			query = ApplyPagination(query, filter);
			
			var items = await query
				.Select(article => new ArticleListDto
				{
					Id = article.Id,
					Title = article.Title,
					CreatedAt = article.CreatedAt,
					AuthorName = article.User.Name,
					AuthorId = article.UserId,
					IsPublished = article.IsPublished,
					Categories = article.Categories.Select(
						c => new CategoryDto
						{
							Id = c.Id,
							Name = c.Name.ToString()
						}).ToList()
				}).ToListAsync();

			var pagedResult = new PagedResultDto<ArticleListDto>
			{
				Items = items,
				TotalCount = totalCount,
				PageNumber = filter.PageNumber,
				PageSize = filter.PageSize
			};

			return Result<PagedResultDto<ArticleListDto>>.Success(pagedResult);
		}

		private IQueryable<Article> ApplyFilters(IQueryable<Article> query, Guid userId, bool canSeeAll, ArticleFilterDto filter)
		{
			switch (filter.Visability)
			{
				case ArticleVisibilityFilter.Published:
					query = query.Where(a => a.IsPublished);
					break;

				case ArticleVisibilityFilter.Unpublished:
					if (canSeeAll)
						query = query.Where(a => !a.IsPublished);
					else
						query = query.Where(a => a.UserId == userId && !a.IsPublished);
					break;

				case ArticleVisibilityFilter.All:
					if (!canSeeAll)
						query = query.Where(a => a.UserId == userId || a.IsPublished);
					break;
			}

			if (!string.IsNullOrWhiteSpace(filter.Title))
				query = query.Where(a => a.Title.Contains(filter.Title));

			if (filter.AuthorId.HasValue)
				query = query.Where(a => a.UserId == filter.AuthorId);

			if (filter.CategoryIds?.Any() == true)
				query = query.Where(a => a.Categories.Any(c => filter.CategoryIds.Contains(c.Id)));

			if (filter.HasReview.HasValue)
			{
				query = filter.HasReview.Value
					? query.Where(a => a.Reviews.Any()) 
					: query.Where(a => !a.Reviews.Any());
			}

			return query;
		}

		private IQueryable<Article> ApplySorting(IQueryable<Article> query, ArticleFilterDto filter)
		{
			query = filter.SortBy switch
			{
				ArticleSortBy.CreatedAt => filter.SortDescending
					? query.OrderByDescending(a => a.CreatedAt)
					: query.OrderBy(a => a.CreatedAt),
				ArticleSortBy.Title => filter.SortDescending
					? query.OrderByDescending(a => a.Title)
					: query.OrderBy(a => a.Title),
				ArticleSortBy.AuthorName => filter.SortDescending
					? query.OrderByDescending(a => a.User.Name)
					: query.OrderBy(a => a.User.Name),
				_ => query.OrderByDescending(a => a.CreatedAt)
			};

			return query;
		}

		private IQueryable<Article> ApplyPagination(IQueryable<Article> query, ArticleFilterDto filter)
		{
			return query.Skip(filter.PageSize * (filter.PageNumber - 1)).Take(filter.PageSize);
		}

		public async Task<Result> UpdateVisibilityAsync(int id, UpdateVisibilityDto dto)
		{
			var article = await _articleRepository.GetByIdAsync(id);

			if (article == null)
				return Result.Failure(ErrorType.NotFound, "Article not found");

			if (article.IsPublished == dto.IsPublished)
				return Result.Failure(ErrorType.Conflict, "Article already has this visibility status");

			article.IsPublished = dto.IsPublished;

			await _articleRepository.SaveChangesAsync();

			return Result.Success();
		}

		public async Task<Result> RemoveArticleAsync(int id, Guid userId, bool isAdmin)
		{
			var article = await _articleRepository.GetByIdAsync(id);

			if (article == null)
				return Result.Failure(ErrorType.NotFound, "Article not found");

			if (!isAdmin && article.UserId != userId)
				return Result.Failure(ErrorType.Forbidden, "You can only delete your own articles");

			await _articleRepository.RemoveAsync(article);

			return Result.Success();
		}
	}
}
