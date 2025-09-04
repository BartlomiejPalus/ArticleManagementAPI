using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<bool> EmailExistsAsync(string email);
		Task<bool> NameExistsAsync(string name);
		Task AddUserAsync(User user);
		Task<User?> GetByIdAsync(Guid userId);
		void Remove(User user);
		Task SaveChangesAsync();
	}
}