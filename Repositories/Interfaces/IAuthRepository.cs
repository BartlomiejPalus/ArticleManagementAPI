using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IAuthRepository
	{
		Task AddUserAsync(User user);
		Task<bool> EmailExistsAsync(string email);
		Task<bool> NameExistsAsync(string name);
	}
}