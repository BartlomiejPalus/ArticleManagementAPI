using ArticleManagementAPI.Data;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
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
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
		}

		public async Task<User?> GetByEmailAsync(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<User?> GetByIdAsync(Guid id)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<User?> GetByRefreshTokenAsync(string refreshTokenHash)
		{
			return await _context.Users
				.Where(u => u.RefreshToken
					.Any(rt => rt.Token == refreshTokenHash && rt.ExpiresAt > DateTime.UtcNow))
				.FirstOrDefaultAsync();
		}

		public async Task RemoveAsync(User user)
		{
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
