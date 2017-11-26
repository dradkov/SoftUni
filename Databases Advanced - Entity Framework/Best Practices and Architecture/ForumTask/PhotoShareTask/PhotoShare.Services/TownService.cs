namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System.Linq;

    public class TownService : ITownService
    {
        private readonly PhotoShareContext context;

        public TownService(PhotoShareContext context)
        {
            this.context = context;
        }

        public Town FindTownById(int townId)
        {
            var town = context.Towns
                .Find(townId);

            return town;
        }

        public Town FindTownByName(string townName)
        {
            var town = context.Towns
                .SingleOrDefault(u => u.Name == townName);

            return town;
        }

        public string AddTown(string townName, string countryName)
        {
            var town = context.Towns.SingleOrDefault(t => t.Name == townName);

            if (town != null)
            {
                return $"Town {townName} was already added!";
            }

            town = new Town
            {
                Name = townName,
                Country = countryName
            };

            context.Towns.Add(town);

            context.SaveChanges();

            return $"Town {townName} was added successfully!";
        }
    }
}