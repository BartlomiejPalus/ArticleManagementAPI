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

		public async Task AddAsync(Comment comment)
		{
			await _context.Comments.AddAsync(comment);
			await _context.SaveChangesAsync();
		}

		public async Task<Comment?> GetByIdAsync(int id)
		{
			return await _context.Comments
				.Include(c => c.User)
				.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task RemoveAsync(Comment comment)
		{
			_context.Comments.Remove(comment);
			await _context.SaveChangesAsync();
		}
	}
}
