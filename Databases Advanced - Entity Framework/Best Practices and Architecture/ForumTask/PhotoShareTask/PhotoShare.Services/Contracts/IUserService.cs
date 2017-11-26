namespace PhotoShare.Services.Contracts
{
    using PhotoShare.Models;

    public interface IUserService
    {
        User FindById(int id);

        User FindByUsername(string username);

        User FindByUsernameAndPassword(string username, string password);

        string RegisterUser(string username, string password, string repeatedPassword, string email);

        string ListFriends(string username);

        string DeleteUser(string username);

        string ModifyUser(string username, string property, string newValue);

        string PrintFriends(string username);
    }
}
