using ArticleManagementAPI.Common;
using ArticleManagementAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.Article
{
	public class AddArticleDto
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string Content { get; set; }

		[Required]
		[MinLength(1)]
		[EnumListValidationAttribute(typeof(ArticleCategory))]
		public List<int> CategoryIds { get; set; } = [];
	}
}
