using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Article> Articles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>()
				.Property(c => c.Name)
				.HasConversion<String>();

			var categories = Enum.GetValues(typeof(ArticleCategory))
			.Cast<ArticleCategory>()
			.Select((name, index) => new Category
			{
				Id = index + 1,
				Name = name
			})
			.ToList();

			modelBuilder.Entity<Category>().HasData(categories);
		}
	}
}
