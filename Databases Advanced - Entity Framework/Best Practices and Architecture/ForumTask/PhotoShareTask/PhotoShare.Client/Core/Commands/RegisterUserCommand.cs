namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string command, string[] data)
        {
            if (Session.User != null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 4)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            return userService.RegisterUser(username, password, repeatPassword, email);
        }
    }
}