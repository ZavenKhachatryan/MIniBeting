using Entity.DAL.BettingModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.BettingConfigurations
{
	public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
	{
		public void Configure(EntityTypeBuilder<UserData> builder)
		{
			builder.Property(e => e.Balance).HasColumnType("money");

			builder.Property(e => e.UserLogin)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(e => e.UserName)
				.IsRequired()
				.HasMaxLength(20);
		}
	}
}
