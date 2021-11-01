namespace Entity.DAL.AdminModels
{
    public partial class AdminBetLaLiga
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public decimal T1win { get; set; }
        public decimal T2win { get; set; }
        public decimal Draw { get; set; }
        public decimal T1yellowCardTwoAndMore { get; set; }
        public decimal T2yellowCardTwoAndMore { get; set; }

        public virtual AdminGameLaLiga Game { get; set; }
    }
}
