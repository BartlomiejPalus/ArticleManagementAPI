using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Auth;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IAuthService
	{
		Task<Result> RegisterAsync(RegisterDto dto);
		Task<Result<LoginResultDto>> LoginAsync(LoginDto dto);
	}
}