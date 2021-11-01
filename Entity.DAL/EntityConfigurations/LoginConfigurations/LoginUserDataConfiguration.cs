using Entity.DAL.LoginModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.LoginConfigurations
{
	public class LoginUserDataConfiguration : IEntityTypeConfiguration<LoginUserData>
	{
		public void Configure(EntityTypeBuilder<LoginUserData> builder)
		{
			builder.Property(e => e.CurrnetAddress)
				.IsRequired()
				.HasMaxLength(40)
				.IsUnicode(false);

			builder.Property(e => e.DateOfBirth).HasColumnType("datetime");

			builder.Property(e => e.Email)
				.IsRequired()
				.HasMaxLength(35)
				.IsUnicode(false);

			builder.Property(e => e.PassportNumber)
				.IsRequired()
				.HasMaxLength(15)
				.IsUnicode(false);

			builder.Property(e => e.Phone)
				.IsRequired()
				.HasMaxLength(9)
				.IsUnicode(false);
		}
	}
}
