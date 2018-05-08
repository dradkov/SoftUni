namespace FootballBetting.Models
{
    using System.Collections.Generic;

    public class Round
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
