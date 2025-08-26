using ArticleManagementAPI.DTOs.Auth;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IAuthService
	{
		Task<bool> RegisterAsync(RegisterDto dto);
	}
}