using ArticleManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleManagementAPI.Data.Configurations
{
	public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
	{
		public void Configure(EntityTypeBuilder<RefreshToken> builder)
		{
			builder.Property(r => r.Token)
				.IsRequired()
				.HasMaxLength(256);

			builder.HasIndex(r => r.Token)
				.IsUnique();
		}
	}
}
