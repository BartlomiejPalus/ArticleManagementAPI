using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IAuthRepository
	{
		Task AddRefreshTokenAsync(RefreshToken refreshToken);
		Task<RefreshToken?> GetRefreshTokenAsync(string refreshToken);
		Task UpdateRefreshTokenAsync(RefreshToken refreshToken);
		Task RemoveRefreshTokenAsync(RefreshToken refreshToken);
	}
}