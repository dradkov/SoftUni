namespace PhotoShare.Services.Contracts
{
    using PhotoShare.Models;

    public interface ITownService
    {
        string AddTown(string townName, string countryName);

        Town FindTownByName(string townName);

        Town FindTownById(int townId);
    }
}
