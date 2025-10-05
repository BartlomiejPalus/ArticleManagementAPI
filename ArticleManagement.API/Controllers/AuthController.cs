using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Auth;
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

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto dto)
		{
			Result<AuthTokensDto> result = await _authService.LoginAsync(dto);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}

		[HttpPost("refresh")]
		public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
		{
			Result<AuthTokensDto> result = await _authService.RefreshTokenAsync(dto);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}

		[Authorize]
		[HttpPost("logout")]
		public async Task<IActionResult> Logout([FromBody] RefreshTokenDto dto)
		{
			var result = await _authService.LogoutAsync(dto);

			if (result.IsSuccess)
				return NoContent();

			return result.ToErrorActionResult(this);
		}
	}
}
