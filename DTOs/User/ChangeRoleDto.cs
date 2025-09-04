using ArticleManagementAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.User
{
	public class ChangeRoleDto
	{
		[Required]
		[EnumDataType(typeof(UserRole))]
		public UserRole Role { get; set; }
	}
}
