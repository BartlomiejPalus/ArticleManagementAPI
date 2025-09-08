using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IArticleRepository
	{
		Task<Article?> GetByIdAsync(int id);
	}
}