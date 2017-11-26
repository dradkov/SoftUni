namespace PhotoShare.Services.Contracts
{
    using System.Collections.Generic;

    public interface IAlbumService
    {
        string CreateAlbum(string username, string albumTitle, string BgColor, List<string> tagNames);
    }
}
