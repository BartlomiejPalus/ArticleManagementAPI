using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<User?> GetByIdAsync(Guid userId);
		void Remove(User user);
		Task SaveChangesAsync();
	}
}