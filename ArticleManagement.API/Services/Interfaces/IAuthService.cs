using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Auth;
using ArticleManagementAPI.DTOs.User;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IAuthService
	{
		Task<Result<AuthTokensDto>> LoginAsync(LoginDto dto);
		Task<Result<AuthTokensDto>> RefreshTokenAsync(RefreshTokenDto dto);
		Task<Result> LogoutAsync(RefreshTokenDto dto);
	}
}