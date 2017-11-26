namespace PhotoShare.Services.Contracts
{
    public interface IPictureService
    {
        string UploadPicture(string albumName, string pictureTitle, string pictureFilePath, string username);
    }
}
