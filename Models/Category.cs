using ArticleManagementAPI.Enums;

namespace ArticleManagementAPI.Models
{
	public class Category
	{
		public int Id { get; set; }
		public ArticleCategory Name { get; set; }

		public ICollection<Article> Articles { get; set; } = [];
	}
}
