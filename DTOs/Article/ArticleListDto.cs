namespace ArticleManagementAPI.DTOs.Article
{
	public class ArticleListDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime CreatedAt {  get; set; }
		public string? AuthorName { get; set; }
		public Guid? AuthorId { get; set; }
		public bool IsPublished { get; set; }

		public List<CategoryDto> Categories { get; set; } = [];
	}
}
