using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Admin;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Repositories.Interfaces;
using ArticleManagementAPI.Services.Interfaces;

namespace ArticleManagementAPI.Services
{
	public class AdminService : IAdminService
	{
		private readonly IAdminRepository _adminRepository;

		public AdminService(IAdminRepository adminRepository)
		{
			_adminRepository = adminRepository;
		}

		public async Task<Result> ChangeUserRole(Guid userId, ChangeUserRoleDto dto)
		{
			return await _adminRepository.ChangeUserRoleAsync(userId, dto.Role);
		}
	}
}
