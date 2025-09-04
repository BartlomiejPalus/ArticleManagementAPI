using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.User;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto dto)
		{
			var result = await _userService.RegisterUserAsync(dto);

			if (result.IsSuccess)
			{
				var userDto = result.Value;
				return CreatedAtAction(nameof(GetUserById), new { userId = userDto.Id }, userDto);
			}

			return result.ToErrorActionResult(this);
		}

		[HttpPatch("{userId}/role")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> ChangeUserRole([FromRoute] Guid userId, [FromBody] ChangeRoleDto dto)
		{
			var result = await _userService.ChangeUserRoleAsync(userId, dto);

			if (result.IsSuccess)
				return NoContent();

			return result.ToErrorActionResult(this);
		}

		[HttpDelete("me")]
		[Authorize]
		public async Task<IActionResult> RemoveMe()
		{
			var currentUserId = User.GetUserId();

			if (currentUserId == Guid.Empty)
				return BadRequest("Invalid user ID format");

			var result = await _userService.RemoveMeAsync(currentUserId);

			if (result.IsSuccess)
				return NoContent();

			return result.ToErrorActionResult(this);
		}

		[HttpDelete("{userId}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveUser([FromRoute] Guid userId)
		{
			var currentUserId = User.GetUserId();

			if (currentUserId == Guid.Empty)
				return BadRequest("Invalid user ID format");

			if (currentUserId == userId)
				return BadRequest("Cannot remove your account via this endpoint");

			var result = await _userService.RemoveUserAsync(userId);
			
			if (result.IsSuccess) 
				return NoContent();

			return result.ToErrorActionResult(this);
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetUserById([FromRoute] Guid userId)
		{
			var result = await _userService.GetUserByIdAsync(userId);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToErrorActionResult(this);
		}
	}
}
