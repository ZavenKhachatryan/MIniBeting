using Microsoft.EntityFrameworkCore;
using Entity.DAL.AdminModels;

namespace Entity.DAL.DB
{
	public partial class AdminDbContext
	{
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder) { }

		public virtual DbSet<AdminBetLaLiga> AdminBetLaLigas { get; set; }
		public virtual DbSet<AdminGameLaLiga> AdminGameLaLigas { get; set; }
		public virtual DbSet<AdminTeamLaLiga> AdminTeamLaLigas { get; set; }

	}
}
