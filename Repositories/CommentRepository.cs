using ArticleManagementAPI.Data;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly ApplicationDbContext _context;

		public CommentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Comment?> GetByIdAsync(int id)
		{
			return await _context.Comments
				.Include(c => c.User)
				.FirstOrDefaultAsync(c => c.Id == id);
		}
	}
}
