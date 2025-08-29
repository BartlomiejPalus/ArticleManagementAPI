using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IAuthRepository
	{
		Task AddUserAsync(User user);
		Task<bool> EmailExistsAsync(string email);
		Task<bool> NameExistsAsync(string name);
		Task<User?> GetUserByEmailAsync(string email);
		Task AddRefreshTokenAsync(RefreshToken refreshToken);
		Task<User?> GetUserByRefreshTokenAsync(string refreshTokenHash);
		Task UpdateRefreshTokenAsync(string oldRefreshTokenHash, RefreshToken newRefreshToken);
	}
}