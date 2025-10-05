using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IJwtService
	{
		string GenerateAccessToken(User user);
		string GenerateRefreshToken();
		string HashToken(string token);
	}
}