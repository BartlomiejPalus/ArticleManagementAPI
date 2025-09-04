using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.User;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Controllers
{
	[Route("api/users")]
	[ApiController]
	[Authorize]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
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
	}
}
