namespace ArticleManagementAPI.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public Guid? UserId { get; set; }
		public User User { get; set; } = null!;

		public int ArticleId { get; set; }
		public Article Article { get; set; } = null!;
	}
}
