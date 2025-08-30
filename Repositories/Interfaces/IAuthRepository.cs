using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IAuthRepository
	{
		Task<bool> AddUserAsync(User user);
		Task<bool> EmailExistsAsync(string email);
		Task<bool> NameExistsAsync(string name);
		Task<User?> GetUserByEmailAsync(string email);
		Task<bool> AddRefreshTokenAsync(RefreshToken refreshToken);
		Task<User?> GetUserByRefreshTokenAsync(string refreshTokenHash);
		Task<bool> UpdateRefreshTokenAsync(string oldRefreshTokenHash, RefreshToken newRefreshToken);
		Task<bool> RemoveRefreshTokenAsync(string refreshToken);
	}
}