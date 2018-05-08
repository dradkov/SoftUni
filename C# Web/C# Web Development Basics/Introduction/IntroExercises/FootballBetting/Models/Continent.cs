namespace FootballBetting.Models
{
    using System.Collections.Generic;

    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CountryContinents> CountryList { get; set; } = new List<CountryContinents>();
    }
}
