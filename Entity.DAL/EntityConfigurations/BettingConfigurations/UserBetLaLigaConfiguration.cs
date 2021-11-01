using Entity.DAL.BettingModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.BettingConfigurations
{
	public class UserBetLaLigaConfiguration : IEntityTypeConfiguration<UserBetLaLiga>
	{
		public void Configure(EntityTypeBuilder<UserBetLaLiga> builder)
		{
                builder.ToTable("BetLaLiga");

                builder.Property(e => e.Draw).HasColumnType("decimal(5, 3)");

                builder.Property(e => e.T1win)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("T1Win");

                builder.Property(e => e.T1yellowCardTwoAndMore)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("T1YellowCardTwoAndMore");

                builder.Property(e => e.T2win)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("T2Win");

                builder.Property(e => e.T2yellowCardTwoAndMore)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("T2YellowCardTwoAndMore");

                builder.HasOne(d => d.Game)
                    .WithMany(p => p.BetLaLigas)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bet_To_Game");
        }
    }
}
