namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string command, string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            var username = data[0];

            if (username != Session.User.Username)
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            Session.User = null;

            return userService.DeleteUser(username);
        }
    }
}