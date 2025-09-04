using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.User;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Repositories.Interfaces;
using ArticleManagementAPI.Services.Interfaces;

namespace ArticleManagementAPI.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<Result> ChangeUserRoleAsync(Guid userId, ChangeRoleDto dto)
		{
			var user = await _userRepository.GetByIdAsync(userId);

			if (user == null)
				return Result.Failure(ErrorType.NotFound, "User not found");

			if (user.Role == dto.Role)
				return Result.Failure(ErrorType.Conflict, "User already has this role");

			user.Role = dto.Role;

			await _userRepository.SaveChangesAsync();

			return Result.Success();
		}

		public async Task<Result> RemoveUserAsync(Guid userId)
		{
			var user = await _userRepository.GetByIdAsync(userId);

			if (user == null)
				return Result.Failure(ErrorType.NotFound, "User not found");

			if (user.Role == UserRole.Admin)
				return Result.Failure(ErrorType.Forbidden, "Cannot remove admin");

			_userRepository.Remove(user);

			await _userRepository.SaveChangesAsync();
			
			return Result.Success();
		}
	}
}
