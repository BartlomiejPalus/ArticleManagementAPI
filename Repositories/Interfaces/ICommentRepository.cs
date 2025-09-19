using ArticleManagementAPI.Models;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface ICommentRepository
	{
		Task AddAsync(Comment comment);
		Task<Comment?> GetByIdAsync(int id);
		IQueryable<Comment> GetAll();
		Task RemoveAsync(Comment comment);
		Task SaveChangesAsync();
	}
}