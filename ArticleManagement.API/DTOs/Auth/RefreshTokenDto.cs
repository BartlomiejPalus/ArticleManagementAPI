using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.Auth
{
	public class RefreshTokenDto
	{
		[Required]
		public string RefreshToken { get; set; }
	}
}
