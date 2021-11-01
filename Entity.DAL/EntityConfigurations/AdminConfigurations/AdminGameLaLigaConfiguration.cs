using Entity.DAL.AdminModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.AdminConfigurations
{
	public class AdminGameLaLigaConfiguration : IEntityTypeConfiguration<AdminGameLaLiga>
	{
		public void Configure(EntityTypeBuilder<AdminGameLaLiga> builder)
		{
                builder.ToTable("GameLaLiga");

                builder.Property(e => e.GameDate).HasColumnType("datetime");

                builder.HasOne(d => d.Team1)
                    .WithMany(p => p.GameLaLigaTeam1s)
                    .HasForeignKey(d => d.Team1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game_To_Team1");

                builder.HasOne(d => d.Team2)
                    .WithMany(p => p.GameLaLigaTeam2s)
                    .HasForeignKey(d => d.Team2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game_To_Team2");
        }
    }
}
