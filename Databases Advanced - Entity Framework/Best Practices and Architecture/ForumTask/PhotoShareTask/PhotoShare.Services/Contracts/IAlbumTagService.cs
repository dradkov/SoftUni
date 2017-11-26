namespace PhotoShare.Services.Contracts
{

    public interface IAlbumTagService
    {
        string AddTagTo(string albumName, string tagName, int userId);
    }
}
