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

		public async Task<bool> AddUserAsync(User user)
		{
			_context.Users.Add(user);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<User?> GetUserByEmailAsync(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<bool> AddRefreshTokenAsync(RefreshToken refreshToken)
		{
			_context.RefreshTokens.Add(refreshToken);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<User?> GetUserByRefreshTokenAsync(string refreshTokenHash)
		{
			return await _context.RefreshTokens
				.Where(rt => rt.Token == refreshTokenHash && rt.ExpiresAt > DateTime.UtcNow)
				.Select(rt => rt.User)
				.FirstOrDefaultAsync();
		}

		public async Task<bool> UpdateRefreshTokenAsync(string oldRefreshTokenHash, RefreshToken newRefreshToken)
		{
			var record = await _context.RefreshTokens
				.Where(rf => rf.Token == oldRefreshTokenHash)
				.FirstOrDefaultAsync();

			if (record == null)
				return false;

			record.Token = newRefreshToken.Token;
			record.ExpiresAt = newRefreshToken.ExpiresAt;
			record.CreatedAt = newRefreshToken.CreatedAt;

			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> RemoveRefreshTokenAsync(string refreshToken)
		{
			var token = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);

			if(token == null)
				return false;
			
			_context.RefreshTokens.Remove(token);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
