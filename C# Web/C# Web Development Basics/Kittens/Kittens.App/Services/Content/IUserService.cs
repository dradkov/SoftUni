namespace Kittens.App.Services.Content
{
    public interface IUserService
    {
        bool Create(string username, string email, string password, string confirmPassword);

        bool UserLogin(string username, string password);
    }
}
