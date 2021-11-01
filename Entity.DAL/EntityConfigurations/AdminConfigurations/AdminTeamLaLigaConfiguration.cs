using Entity.DAL.AdminModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.DAL.EntityConfigurations.AdminConfigurations
{
	public class AdminTeamLaLigaConfiguration : IEntityTypeConfiguration<AdminTeamLaLiga>
	{
		public void Configure(EntityTypeBuilder<AdminTeamLaLiga> builder)
		{
                builder.ToTable("TeamLaLiga");

                builder.Property(e => e.Team)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
        }
    }
}
