using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.Auth
{
	public class LoginResultDto
	{
		[Required]
		public string AccessToken { get; set; }
		[Required]
		public string RefreshToken { get; set; }
	}
}
