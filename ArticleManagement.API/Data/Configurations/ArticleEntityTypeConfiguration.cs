using ArticleManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleManagementAPI.Data.Configurations
{
	public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.Property(a => a.Title)
				.IsRequired();

			builder.Property(a => a.Content)
				.IsRequired();

			builder.HasOne(a => a.User)
				.WithMany()
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.SetNull);
		}
	}
}
