using ArticleManagementAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.DTOs.Article
{
	public class ArticleFilterDto
	{
		public string? Title { get; set; }
		public Guid? AuthorId { get; set; }
		public List<int>? CategoryIds { get; set; }

		[Range(1, int.MaxValue)]
		public int PageNumber { get; set; } = 1;
		[Range(1, 100)]
		public int PageSize { get; set; } = 10;

		public ArticleSortBy SortBy { get; set; } = ArticleSortBy.CreatedAt;
		public bool SortDescending { get; set; } = true;
	}
}
