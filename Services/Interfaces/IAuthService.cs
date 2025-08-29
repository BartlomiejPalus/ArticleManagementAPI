using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Auth;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IAuthService
	{
		Task<Result> RegisterAsync(RegisterDto dto);
		Task<Result<AuthTokensDto>> LoginAsync(LoginDto dto);
		Task<Result<AuthTokensDto>> RefreshTokenAsync(RefreshTokenDto dto);
		Task<Result> LogoutAsync(RefreshTokenDto dto);
	}
}