namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        [StringLength(3, MinimumLength = 3)]
        public string Initials { get; set; }

        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public decimal Budget { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public ICollection<Game> HomeGames { get; set; } = new List<Game>();

        public ICollection<Game> AwayGames { get; set; } = new List<Game>();

    }
}
