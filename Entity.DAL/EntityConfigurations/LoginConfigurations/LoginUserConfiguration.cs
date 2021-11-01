using Entity.DAL.LoginModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.LoginConfigurations
{
	class LoginUserConfiguration : IEntityTypeConfiguration<LoginUser>
	{
		public void Configure(EntityTypeBuilder<LoginUser> builder)
		{
			builder.ToTable("MUser");

			builder.Property(e => e.FirstName)
				.IsRequired()
				.HasMaxLength(20)
				.IsUnicode(false);

			builder.Property(e => e.LastName)
				.IsRequired()
				.HasMaxLength(25)
				.IsUnicode(false);

			builder.HasOne(d => d.UserData)
				.WithMany(p => p.Users)
				.HasForeignKey(d => d.UserDataId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_MUser_UserData");
		}
	}
}
