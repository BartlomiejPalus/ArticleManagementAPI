using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IArticleRepository
	{
		Task AddAsync(Article article);
		Task<Article?> GetByIdAsync(int id);
		Task<IList<Category>> GetCategoriesByIdAsync(IEnumerable<int> categoriesId);
	}
}