using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Article;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IArticleService
	{
		Task<Result<ArticleDto>> GetArticleByIdAsync(int id);
	}
}