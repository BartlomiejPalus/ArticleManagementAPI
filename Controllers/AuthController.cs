using ArticleManagementAPI.DTOs.Auth;
using ArticleManagementAPI.Services.Interfaces;
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
			if (await _authService.RegisterAsync(dto))
				return Ok(new { message = "User registered successfully" });
			else
				return BadRequest("Email or name exists");
		}
	}
}
