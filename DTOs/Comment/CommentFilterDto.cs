using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.Comment
{
	public class CommentFilterDto
	{
		[Range(1, int.MaxValue)]
		public int PageNumber { get; set; } = 1;
		[Range(1, 100)]
		public int PageSize { get; set; } = 10;

		public bool SortDescending { get; set; } = true;
	}
}
