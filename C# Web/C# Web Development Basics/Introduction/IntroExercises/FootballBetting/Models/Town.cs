namespace FootballBetting.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}
