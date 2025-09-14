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

		public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
		{
			_context.RefreshTokens.Add(refreshToken);
			await _context.SaveChangesAsync();
		}

		public async Task<RefreshToken?> GetRefreshTokenAsync(string refreshToken)
		{
			return await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);
		}

		public async Task RemoveRefreshTokenAsync(RefreshToken refreshToken)
		{			
			_context.RefreshTokens.Remove(refreshToken);
			await _context.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
