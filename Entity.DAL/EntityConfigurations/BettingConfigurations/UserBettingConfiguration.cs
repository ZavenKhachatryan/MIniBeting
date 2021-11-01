using Entity.DAL.BettingModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.BettingConfigurations
{
	public class UserBetingConfiguration : IEntityTypeConfiguration<UserBeting>
	{
		public void Configure(EntityTypeBuilder<UserBeting> builder)
		{
			builder.ToTable("UserBeting");

			builder.Property(e => e.TotalCoefficient).HasColumnType("decimal(5, 3)");

			builder.HasOne(d => d.Bet)
				.WithMany(p => p.UserBetings)
				.HasForeignKey(d => d.BetId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_UserBeting_To_BetLaLiga");

			builder.HasOne(d => d.UserData)
				.WithMany(p => p.UserBetings)
				.HasForeignKey(d => d.UserDataId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_UserBeting_To_UserData");
		}
	}
}
