using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Auth;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Controllers
{
	[Route("api/[controller]")]
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
				return Ok(new { message = "User registered successfully" });

			return Conflict(result.ErrorMessage);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto dto)
		{
			Result<LoginResultDto> result = await _authService.LoginAsync(dto);

			if (result.IsSuccess)
			{
				return Ok(new
				{
					message = "Login successful",
					result.Value.AccessToken,
					result.Value.RefreshToken
				});
			}

			return result.ErrorType switch
			{
				ErrorType.NotFound => NotFound(result.ErrorMessage),
				ErrorType.Unauthorized => Unauthorized(result.ErrorMessage),
				_ => BadRequest(result.ErrorMessage)
			};
		}
	}
}
