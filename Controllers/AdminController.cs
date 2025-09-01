using ArticleManagementAPI.DTOs.Admin;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Controllers
{
	[Route("api/admin")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpPatch("users/{userId}/role")]
		public async Task<IActionResult> ChangeUserRole([FromRoute] Guid userId, [FromBody] ChangeUserRoleDto dto)
		{
			var result = await _adminService.ChangeUserRole(userId, dto);

			if (result.IsSuccess)
				return NoContent();

			return result.ErrorType switch
			{
				ErrorType.NotFound => NotFound(result.ErrorMessage),
				ErrorType.Conflict => Conflict(result.ErrorMessage),
				_ => StatusCode(500, "Internal server error")
			};
		}
	}
}
