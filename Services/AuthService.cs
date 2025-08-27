using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Auth;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ArticleManagementAPI.Services
{
	public class AuthService : IAuthService
	{
		public readonly IAuthRepository _authRepository;
		private readonly PasswordHasher<User> _passwordHasher = new();

		public AuthService(IAuthRepository authRepository)
		{
			_authRepository = authRepository;
		}

		public async Task<Result> RegisterAsync(RegisterDto dto)
		{
			if (await _authRepository.EmailExistsAsync(dto.Email))
				return Result.Failure(ErrorType.Conflict, "Email already exists");

			if (await _authRepository.NameExistsAsync(dto.Name))
				return Result.Failure(ErrorType.Conflict, "Name already exists");

			var user = new User
			{
				Name = dto.Name,
				Email = dto.Email
			};

			user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

			await _authRepository.AddUserAsync(user);
			
			return Result.Success();
		}
	}
}
