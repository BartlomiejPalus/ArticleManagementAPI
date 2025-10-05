using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IArticleRepository
	{
		Task AddAsync(Article article);
		Task<Article?> GetByIdAsync(int id);
		IQueryable<Article> GetArticles();
		Task RemoveAsync(Article article);
		Task<IList<Category>> GetCategoriesByIdAsync(IEnumerable<int> categoriesId);
		Task SaveChangesAsync();
	}
}