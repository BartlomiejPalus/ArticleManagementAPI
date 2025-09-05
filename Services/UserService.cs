using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.User;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ArticleManagementAPI.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IPasswordHasher<User> _passwordHasher;

		public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
		}

		public async Task<Result<RegisterResponseDto>> RegisterUserAsync(RegisterDto dto)
		{
			var nameExists = await _userRepository.NameExistsAsync(dto.Name);
			var emailExists = await _userRepository.EmailExistsAsync(dto.Email);

			if (nameExists || emailExists)
				return Result<RegisterResponseDto>.Failure(ErrorType.Conflict, "Name or email is already taken");

			var newUser = new User
			{
				Name = dto.Name,
				Email = dto.Email
			};

			newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password);

			await _userRepository.AddUserAsync(newUser);

			var userDto = new RegisterResponseDto
			{
				Id = newUser.Id,
				Name = newUser.Name,
				Email = newUser.Email,
			};

			return Result<RegisterResponseDto>.Success(userDto);
		}

		public async Task<Result> ChangeUserRoleAsync(Guid userId, ChangeRoleDto dto)
		{
			var user = await _userRepository.GetByIdAsync(userId);

			if (user == null)
				return Result.Failure(ErrorType.NotFound, "User not found");

			if (user.Role == dto.Role)
				return Result.Failure(ErrorType.Conflict, "User already has this role");

			user.Role = dto.Role;

			await _userRepository.UpdateAsync(user);

			return Result.Success();
		}

		public async Task<Result> RemoveMeAsync(Guid currentUserId)
		{
			var user = await _userRepository.GetByIdAsync(currentUserId);

			if (user == null)
				return Result.Failure(ErrorType.NotFound, "User not found");

			await _userRepository.RemoveAsync(user);

			return Result.Success();
		}

		public async Task<Result> RemoveUserAsync(Guid userId)
		{
			var user = await _userRepository.GetByIdAsync(userId);

			if (user == null)
				return Result.Failure(ErrorType.NotFound, "User not found");

			if (user.Role == UserRole.Admin)
				return Result.Failure(ErrorType.Forbidden, "Cannot remove admin");

			await _userRepository.RemoveAsync(user);
			
			return Result.Success();
		}

		public async Task<Result<GetUserResponseDto>> GetUserByIdAsync(Guid userId)
		{
			var user = await _userRepository.GetByIdAsync(userId);

			if (user == null)
				return Result<GetUserResponseDto>.Failure(ErrorType.NotFound, "User not found");

			var userDto = new GetUserResponseDto
			{
				Id = user.Id,
				Name = user.Name,
			};

			return Result<GetUserResponseDto>.Success(userDto);
		}
	}
}
