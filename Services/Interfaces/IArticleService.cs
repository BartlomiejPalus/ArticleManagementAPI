using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Article;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IArticleService
	{
		Task<Result<ArticleAdminDto>> AddArticleAsync(Guid userId, AddArticleDto dto);
		Task<Result<ArticleDto>> GetArticleByIdAsync(int id);
	}
}