using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Admin;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IAdminService
	{
		Task<Result> ChangeUserRole(Guid userId, ChangeUserRoleDto dto);
		Task<Result> RemoveUser(Guid userId);
	}
}