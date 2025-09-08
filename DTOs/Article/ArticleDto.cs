namespace ArticleManagementAPI.DTOs.Article
{
	public class ArticleDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt {  get; set; }
		public string? AuthorName { get; set; }
		public Guid? AuthorId { get; set; }

		public ICollection<CategoryDto> Categories { get; set; } = [];
	}
}
