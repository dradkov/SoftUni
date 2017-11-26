namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

   public class LoginCommand : ICommand
    {
        private readonly IUserService userService;

        public LoginCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string command, params string[] data)
        {
            if (Session.User != null)
            {
                throw new ArgumentException("You should logout first!");
            }

            if (data.Length < 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            var username = data[0];
            var password = data[1];

            var user = userService.FindByUsernameAndPassword(username, password);

            if (user == null)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            Session.User = user;

            return $"User {username} successfully logged in!";
        }
    }
}