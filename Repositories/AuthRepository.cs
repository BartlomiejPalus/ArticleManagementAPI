using ArticleManagementAPI.Data;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private readonly ApplicationDbContext _context;

		public AuthRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> EmailExistsAsync(string email)
		{
			return await _context.Users.AnyAsync(u => u.Email == email);
		}

		public async Task<bool> NameExistsAsync(string name)
		{
			return await _context.Users.AnyAsync(u => u.Name == name);
		}

		public async Task AddUserAsync(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
		}
	}
}
