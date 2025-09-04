using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Auth;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		
		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto dto)
		{
			Result result = await _authService.RegisterAsync(dto);

			if (result.IsSuccess)
				return Ok("User registered successfully");

			return result.ErrorType switch
			{
				ErrorType.Conflict => Conflict(result.ErrorMessage),
				_ => StatusCode(500, "Internal server error")
			};
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto dto)
		{
			Result<AuthTokensDto> result = await _authService.LoginAsync(dto);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ErrorType switch
			{
				ErrorType.NotFound => NotFound(result.ErrorMessage),
				ErrorType.Unauthorized => Unauthorized(result.ErrorMessage),
				_ => StatusCode(500, "Internal server error")
			};
		}

		[HttpPost("refresh")]
		public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
		{
			Result<AuthTokensDto> result = await _authService.RefreshTokenAsync(dto);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ErrorType switch
			{
				ErrorType.Unauthorized => Unauthorized(result.ErrorMessage),
				_ => StatusCode(500, "Internal server error")
			};
		}

		[Authorize]
		[HttpPost("logout")]
		public async Task<IActionResult> Logout([FromBody] RefreshTokenDto dto)
		{
			var result = await _authService.LogoutAsync(dto);

			if (result.IsSuccess)
				return NoContent();

			return Unauthorized(result.ErrorMessage);
		}
	}
}
