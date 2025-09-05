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
		private readonly IUserRepository _userRepository;
		private readonly IJwtService _jwtService;
		private readonly IConfiguration _configuration;
		private readonly IPasswordHasher<User> _passwordHasher;

		public AuthService(IAuthRepository authRepository, IUserRepository userRepository, IJwtService jwtService,
			IConfiguration configuration, IPasswordHasher<User> passwordHasher)
		{
			_authRepository = authRepository;
			_userRepository = userRepository;
			_jwtService = jwtService;
			_configuration = configuration;
			_passwordHasher = passwordHasher;
		}

		public async Task<Result<AuthTokensDto>> LoginAsync(LoginDto dto)
		{
			var user = await _userRepository.GetByEmailAsync(dto.Email);

			if (user == null)
				return Result<AuthTokensDto>.Failure(ErrorType.Unauthorized, "Invalid credentials");

			var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

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
			var user = await _userRepository.GetByRefreshTokenAsync(refreshTokenHash);
			
			if (user == null)
				return Result<AuthTokensDto>.Failure(ErrorType.Unauthorized, "Invalid refresh token");
			
			var accessToken = _jwtService.GenerateAccessToken(user);
			var refreshTokenValue = _jwtService.GenerateRefreshToken();

			var refreshToken = await _authRepository.GetRefreshTokenAsync(refreshTokenHash);

			if (refreshToken == null)
				return Result<AuthTokensDto>.Failure(ErrorType.Unauthorized, "Invalid refresh token");

			refreshToken.Token = _jwtService.HashToken(refreshTokenValue);
			refreshToken.ExpiresAt = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("Jwt:RefreshTokenExpirationInDays"));
			refreshToken.CreatedAt = DateTime.UtcNow;

			await _authRepository.UpdateRefreshTokenAsync(refreshToken);

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
			var refreshToken = await _authRepository.GetRefreshTokenAsync(refreshTokenHash);

			if (refreshToken == null)
				return Result.Failure(ErrorType.Unauthorized, "Invalid refresh token");

			await _authRepository.RemoveRefreshTokenAsync(refreshToken);
			
			return Result.Success();
		}
	}
}
