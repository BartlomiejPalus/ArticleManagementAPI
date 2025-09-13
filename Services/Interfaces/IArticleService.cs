using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Article;
using ArticleManagementAPI.DTOs.Common;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IArticleService
	{
		Task<Result<ArticleDetailsDto>> AddArticleAsync(Guid userId, ArticleRequestDto dto);
		Task<Result<ArticleDetailsDto>> GetArticleByIdAsync(int id);
		Task<Result<PagedResultDto<ArticleListDto>>> GetArticlesAsync(Guid userId, bool canSeeAll, ArticleFilterDto filter);
		Task<Result> UpdateVisibilityAsync(int id, UpdateVisibilityDto dto);
		Task<Result> UpdateArticleAsync(Guid userId, int id, ArticleRequestDto dto);
		Task<Result> RemoveArticleAsync(Guid userId, int id, bool isAdmin);
	}
}