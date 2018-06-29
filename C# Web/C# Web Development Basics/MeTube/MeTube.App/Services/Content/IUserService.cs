namespace MeTube.App.Services.Content
{
    public interface IUserService
    {
        bool Create(string username, string password, string email);

        bool UserExist(string username, string password);
    }
}
