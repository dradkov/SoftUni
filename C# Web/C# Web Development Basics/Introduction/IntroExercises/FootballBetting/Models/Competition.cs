namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using FootballBetting.Models.Enums;

    public class Competition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CompetitionTypeId { get; set; }

        public Color CompetitionType { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
