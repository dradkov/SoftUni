namespace FootballBetting.Models
{
    using FootballBetting.Models.Enums;

    public class ResultPrediction
    {
        public int  Id { get; set; }

        public Prediction Prediction { get; set; }

        public int BetId { get; set; }

        public Bet Bet { get; set; }

    }
}
