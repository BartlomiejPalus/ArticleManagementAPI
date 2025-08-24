namespace ArticleManagementAPI.Models
{
	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public bool IsPublished { get; set; } = false;

		public Guid? UserId { get; set; }
		public User User { get; set; } = null!;

		public ICollection<Category> Categories { get; set; } = [];
		public ICollection<Comment> Comments { get; set; } = [];
		public ICollection<Review> Reviews { get; set; } = [];
	}
}
