using System;
using System.Collections.Generic;

namespace Entity.DAL.BettingModels
{
    public partial class UserGameLaLiga
    {
        public UserGameLaLiga()
        {
            BetLaLigas = new HashSet<UserBetLaLiga>();
        }

        public int Id { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public DateTime GameDate { get; set; }

        public virtual ICollection<UserBetLaLiga> BetLaLigas { get; set; }
    }
}
