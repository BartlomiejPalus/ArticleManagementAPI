using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.Auth
{
	public class LoginDto
	{
		[Required]
		[EmailAddress]
		public string email { get; set; }
		[Required]
		public string password { get; set; }
	}
}
