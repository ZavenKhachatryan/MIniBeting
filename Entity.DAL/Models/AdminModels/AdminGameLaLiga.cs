using System;
using System.Collections.Generic;

namespace Entity.DAL.AdminModels
{
    public partial class AdminGameLaLiga
    {
        public AdminGameLaLiga()
        {
            BetLaLigas = new HashSet<AdminBetLaLiga>();
        }

        public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public DateTime GameDate { get; set; }

        public virtual AdminTeamLaLiga Team1 { get; set; }
        public virtual AdminTeamLaLiga Team2 { get; set; }
        public virtual ICollection<AdminBetLaLiga> BetLaLigas { get; set; }
    }
}
