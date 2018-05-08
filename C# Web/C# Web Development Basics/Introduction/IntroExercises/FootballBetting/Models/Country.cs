namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int ContinentId { get; set; }

        public Continent Continent { get; set; }

        public ICollection<Town> Towns { get; set; } = new List<Town>();

        public ICollection<CountryContinents> ContinentList { get; set; } = new List<CountryContinents>();

    }
}
