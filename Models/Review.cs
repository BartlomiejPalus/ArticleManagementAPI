namespace ArticleManagementAPI.Models
{
	public class Review
	{
		public int Id { get; set; }
		public string Note { get; set; }

		public Guid? UserId { get; set; }
		public User User { get; set; } = null!;

		public int ArticleId { get; set; }
		public Article Article { get; set; } = null!;
	}
}
