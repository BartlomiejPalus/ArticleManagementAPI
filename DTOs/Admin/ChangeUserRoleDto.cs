using ArticleManagementAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.Admin
{
	public class ChangeUserRoleDto
	{
		[EnumDataType(typeof(UserRole))]
		public UserRole Role { get; set; }
	}
}
