using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.User;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface IUserService
	{
		Task<Result<RegisterResponseDto>> RegisterUserAsync(RegisterDto dto);
		Task<Result> ChangeUserRoleAsync(Guid userId, ChangeRoleDto dto);
		Task<Result> RemoveMeAsync(Guid currentUserId);
		Task<Result> RemoveUserAsync(Guid userId);
		Task<Result<GetUserResponseDto>> GetUserByIdAsync(Guid userId);
	}
}