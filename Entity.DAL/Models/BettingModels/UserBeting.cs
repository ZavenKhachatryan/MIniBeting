namespace Entity.DAL.BettingModels
{
    public partial class UserBeting
    {
        public int Id { get; set; }
        public int UserDataId { get; set; }
        public int BetId { get; set; }
        public decimal TotalCoefficient { get; set; }
        public int BetPrice { get; set; }

        public virtual UserBetLaLiga Bet { get; set; }
        public virtual UserData UserData { get; set; }
    }
}
