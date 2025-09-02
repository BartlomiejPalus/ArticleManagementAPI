using ArticleManagementAPI.Common;
using ArticleManagementAPI.Enums;

namespace ArticleManagementAPI.Repositories.Interfaces
{
	public interface IAdminRepository
	{
		Task<Result> ChangeUserRoleAsync(Guid userId, UserRole newRole);
		Task<Result> RemoveUserAsync(Guid userId);
	}
}