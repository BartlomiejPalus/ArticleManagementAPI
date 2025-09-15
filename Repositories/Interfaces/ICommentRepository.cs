using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface ICommentRepository
	{
		Task<Comment?> GetByIdAsync(int id);
	}
}