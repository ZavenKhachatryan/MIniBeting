using Entity.DAL.LoginModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.LoginConfigurations
{
	public class LoginConfiguration : IEntityTypeConfiguration<Login>
	{
		public void Configure(EntityTypeBuilder<Login> builder)
		{
			builder.ToTable("ULogin");

			builder.Property(e => e.UsrLogin)
				.IsRequired()
				.HasMaxLength(20)
				.HasColumnName("ULogin");

			builder.Property(e => e.Upassword)
				.IsRequired()
				.HasMaxLength(25)
				.HasColumnName("UPassword");

			builder.HasOne(d => d.User)
				.WithMany(p => p.Logins)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ULogin_MUser");
		}
	}
}
