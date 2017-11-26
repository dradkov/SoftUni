namespace PhotoShare.Services.Contracts
{
    public interface IAlbumRoleService
    {
        string ShareAlbum(int albumId, string username, string permission);
    }
}
