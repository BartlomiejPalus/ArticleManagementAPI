using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.Auth
{
	public class AuthTokensDto
	{
		[Required]
		public string AccessToken { get; set; }
		[Required]
		public string RefreshToken { get; set; }
	}
}
