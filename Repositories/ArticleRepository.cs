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

		public async Task<Article?> GetByIdAsync(int id)
		{
			return await _context.Articles
				.Include(a => a.User)
				.Include(a => a.Categories)
				.FirstOrDefaultAsync(a => a.Id == id);
		}
	}
}
