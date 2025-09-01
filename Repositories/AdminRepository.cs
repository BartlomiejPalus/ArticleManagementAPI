using ArticleManagementAPI.Common;
using ArticleManagementAPI.Data;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Repositories
{
	public class AdminRepository : IAdminRepository
	{
		private readonly ApplicationDbContext _context;

		public AdminRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Result> ChangeUserRoleAsync(Guid userId, UserRole newRole)
		{
			var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

			if (user == null)
				return Result.Failure(ErrorType.NotFound, "User not found");

			if (user.Role == newRole)
				return Result.Failure(ErrorType.Conflict, "User already has this role");

			user.Role = newRole;
			if (await _context.SaveChangesAsync() == 0)
				return Result.Failure(ErrorType.InternalServerError, "Failed to change user role");

			return Result.Success();
		}
	}
}
