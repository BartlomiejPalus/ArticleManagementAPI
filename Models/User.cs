using ArticleManagementAPI.Enums;

namespace ArticleManagementAPI.Models
{
	public class User
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public UserRole Role { get; set; } = UserRole.Reader;
		public string Email { get; set; }
		public string PasswordHash { get; set; }

		public ICollection<Article> Articles { get; set; } = [];
		public ICollection<Comment> Comments { get; set; } = [];
		public ICollection<Review> Reviews { get; set; } = [];
	}
}
