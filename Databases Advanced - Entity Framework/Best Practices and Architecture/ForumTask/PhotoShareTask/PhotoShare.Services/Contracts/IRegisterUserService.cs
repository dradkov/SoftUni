namespace PhotoShare.Services.Contracts
{
    using PhotoShare.Models;

    public interface IRegisterUserService
    {
        User Register(string username, string password, string repeatpassword, string email);
    }
}
