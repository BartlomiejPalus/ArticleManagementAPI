using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Article;
using ArticleManagementAPI.DTOs.Common;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IArticleService
	{
		Task<Result<ArticleAdminDto>> AddArticleAsync(Guid userId, AddArticleDto dto);
		Task<Result<ArticleDto>> GetArticleByIdAsync(int id);
		Task<Result<PagedResultDto<ArticleDto>>> GetArticlesAsync(Guid userId, bool canSeeAll, ArticleFilterDto filter);
		Task<Result> RemoveArticleAsync(int id, Guid userId, bool isAdmin);
	}
}