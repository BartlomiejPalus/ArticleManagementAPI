using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<bool> EmailExistsAsync(string email);
		Task<bool> NameExistsAsync(string name);
		Task AddUserAsync(User user);
		Task<User?> GetByEmailAsync(string email);
		Task<User?> GetByIdAsync(Guid userId);
		Task<User?> GetByRefreshTokenAsync(string refreshTokenHash);
		Task UpdateAsync(User user);
		Task RemoveAsync(User user);
	}
}