using Entity.DAL.AdminModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.AdminConfigurations
{
	public class AdminBetLaLigaConfiguration : IEntityTypeConfiguration<AdminBetLaLiga>
	{
		public void Configure(EntityTypeBuilder<AdminBetLaLiga> builder)
		{
                builder.ToTable("BetLaLiga");

                builder.Property(e => e.Draw).HasColumnType("decimal(18, 0)");

                builder.Property(e => e.T1win)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("T1Win");

                builder.Property(e => e.T1yellowCardTwoAndMore)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("T1YellowCardTwoAndMore");

                builder.Property(e => e.T2win)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("T2Win");

                builder.Property(e => e.T2yellowCardTwoAndMore)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("T2YellowCardTwoAndMore");

                builder.HasOne(d => d.Game)
                    .WithMany(p => p.BetLaLigas)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bet_To_Game");
        }
    }
}
