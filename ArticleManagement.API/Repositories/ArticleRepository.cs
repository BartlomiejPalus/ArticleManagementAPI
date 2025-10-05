using ArticleManagementAPI.Data;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Repositories
{
	public class ArticleRepository : IArticleRepository
	{
		private readonly ApplicationDbContext _context;

		public ArticleRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Article article)
		{
			await _context.Articles.AddAsync(article);
			await _context.SaveChangesAsync();
		}

		public async Task<Article?> GetByIdAsync(int id)
		{
			return await _context.Articles
				.Include(a => a.User)
				.Include(a => a.Categories)
				.FirstOrDefaultAsync(a => a.Id == id);
		}

		public IQueryable<Article> GetArticles()
		{
			return _context.Articles
				.Include(a => a.User)
				.Include(a => a.Categories) 
				.AsQueryable();
		}

		public async Task RemoveAsync(Article article)
		{
			_context.Articles.Remove(article);
			await _context.SaveChangesAsync();
		}

		public async Task<IList<Category>> GetCategoriesByIdAsync(IEnumerable<int> categoriesId)
		{
			return await _context.Categories
				.Where(c => categoriesId.Contains(c.Id))
				.ToListAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
