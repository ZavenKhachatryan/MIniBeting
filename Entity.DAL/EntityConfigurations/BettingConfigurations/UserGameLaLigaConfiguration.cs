using Entity.DAL.BettingModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.BettingConfigurations
{
	public class UserGameLaLigaConfiguration : IEntityTypeConfiguration<UserGameLaLiga>
	{
		public void Configure(EntityTypeBuilder<UserGameLaLiga> builder)
		{
                builder.ToTable("GameLaLiga");

                builder.Property(e => e.GameDate).HasColumnType("datetime");

                builder.Property(e => e.Team1)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                builder.Property(e => e.Team2)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
        }
    }
}
