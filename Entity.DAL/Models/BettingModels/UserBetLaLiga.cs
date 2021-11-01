using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.DAL.BettingModels
{
    public partial class UserBetLaLiga
    {
        public UserBetLaLiga()
        {
            UserBetings = new HashSet<UserBeting>();
        }

        public int Id { get; set; }
        public int GameId { get; set; }
        public decimal? T1win { get; set; }
        public decimal? T2win { get; set; }
        public decimal? Draw { get; set; }
        public decimal? T1yellowCardTwoAndMore { get; set; }
        public decimal? T2yellowCardTwoAndMore { get; set; }

        public virtual UserGameLaLiga Game { get; set; }
        public virtual ICollection<UserBeting> UserBetings { get; set; }
    }
}
