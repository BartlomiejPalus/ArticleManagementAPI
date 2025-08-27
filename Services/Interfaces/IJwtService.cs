using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IJwtService
	{
		string GenerateToken(User user);
	}
}