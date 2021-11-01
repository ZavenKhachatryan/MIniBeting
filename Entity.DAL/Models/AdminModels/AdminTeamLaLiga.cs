using System.Collections.Generic;

namespace Entity.DAL.AdminModels
{
	public partial class AdminTeamLaLiga
    {
        public AdminTeamLaLiga()
        {
            GameLaLigaTeam1s = new HashSet<AdminGameLaLiga>();
            GameLaLigaTeam2s = new HashSet<AdminGameLaLiga>();
        }

        public int Id { get; set; }
        public string Team { get; set; }

        public virtual ICollection<AdminGameLaLiga> GameLaLigaTeam1s { get; set; }
        public virtual ICollection<AdminGameLaLiga> GameLaLigaTeam2s { get; set; }
    }
}
