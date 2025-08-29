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
		private readonly IAuthRepository _authRepository;
		private readonly IJwtService _jwtService;
		private readonly IConfiguration _configuration;
		private readonly PasswordHasher<User> _passwordHasher = new();

		public AuthService(IAuthRepository authRepository, IJwtService jwtService,
			IConfiguration configuration)
		{
			_authRepository = authRepository;
			_jwtService = jwtService;
			_configuration = configuration;
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

		public async Task<Result<AuthTokensDto>> LoginAsync(LoginDto dto)
		{
			var user = await _authRepository.GetUserByEmailAsync(dto.email);

			if (user == null)
				return Result<AuthTokensDto>.Failure(ErrorType.Unauthorized, "Invalid credentials");

			var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.password);

			if (result == PasswordVerificationResult.Failed)
				return Result<AuthTokensDto>.Failure(ErrorType.Unauthorized, "Invalid credentials");

			string accessToken = _jwtService.GenerateAccessToken(user);

			string refreshTokenValue = _jwtService.GenerateRefreshToken();
			string refreshTokenHash = _jwtService.HashToken(refreshTokenValue);

			var refreshToken = new RefreshToken
			{
				Token = refreshTokenHash,
				UserId = user.Id,
				ExpiresAt = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("Jwt:RefreshTokenExpirationInDays"))
			};

			await _authRepository.AddRefreshTokenAsync(refreshToken);

			var authTokensDto = new AuthTokensDto
			{
				AccessToken = accessToken,
				RefreshToken = refreshTokenValue
			};

			return Result<AuthTokensDto>.Success(authTokensDto);
		}

		public async Task<Result<AuthTokensDto>> RefreshTokenAsync(RefreshTokenDto dto)
		{
			var refreshTokenHash = _jwtService.HashToken(dto.RefreshToken);
			var user = await _authRepository.GetUserByRefreshTokenAsync(refreshTokenHash);
			
			if (user == null)
				return Result<AuthTokensDto>.Failure(ErrorType.Unauthorized, "Invalid refresh token");
			
			var accessToken = _jwtService.GenerateAccessToken(user);
			var refreshTokenValue = _jwtService.GenerateRefreshToken();

			var refreshToken = new RefreshToken
			{
				Token = _jwtService.HashToken(refreshTokenValue),
				UserId = user.Id,
				ExpiresAt = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("Jwt:RefreshTokenExpirationInDays"))
			};

			await _authRepository.UpdateRefreshTokenAsync(refreshTokenHash, refreshToken);

			var authTokensDto = new AuthTokensDto
			{
				AccessToken = accessToken,
				RefreshToken = refreshTokenValue
			};

			return Result<AuthTokensDto>.Success(authTokensDto);
		}

		public async Task<Result> LogoutAsync(RefreshTokenDto dto)
		{
			var refreshTokenHash = _jwtService.HashToken(dto.RefreshToken);

			if (await _authRepository.RemoveRefreshTokenAsync(refreshTokenHash))
				return Result.Success();

			return Result.Failure(ErrorType.Unauthorized, "Invalid refresh token");
		}
	}
}
