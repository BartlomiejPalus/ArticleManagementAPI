using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IAuthRepository
	{
		Task AddRefreshTokenAsync(RefreshToken refreshToken);
		Task<RefreshToken?> GetRefreshTokenAsync(string refreshToken);
		Task RemoveRefreshTokenAsync(RefreshToken refreshToken);
		Task SaveChangesAsync();
	}
}