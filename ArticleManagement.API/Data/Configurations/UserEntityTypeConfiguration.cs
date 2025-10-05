using ArticleManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleManagementAPI.Data.Configurations
{
	public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(u => u.Name)
				.IsRequired()
				.HasMaxLength(30);

			builder.HasIndex(u => u.Name)
				.IsUnique();

			builder.Property(u => u.Email)
				.IsRequired();

			builder.HasIndex(u => u.Email)
				.IsUnique();
		}
	}
}
