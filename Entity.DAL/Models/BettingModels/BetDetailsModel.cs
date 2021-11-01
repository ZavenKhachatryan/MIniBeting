using System;

namespace Entity.DAL.BettingModels
{
	public class BetDetailsModel
	{
		public int GameId { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public DateTime GameDate { get; set; }
        public bool T1win { get; set; }
        public bool T2win { get; set; }
        public bool Draw { get; set; }
        public bool T1yellowCardTwoAndMore { get; set; }
        public bool T2yellowCardTwoAndMore { get; set; }
        public int BetPrice { get; set; }
    }
}
