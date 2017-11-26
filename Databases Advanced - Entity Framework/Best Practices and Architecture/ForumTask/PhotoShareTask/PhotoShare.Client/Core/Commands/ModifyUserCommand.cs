namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService userService;

        public ModifyUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string command, string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            var username = data[0];
            var property = data[1];
            var newValue = data[2];

            return userService.ModifyUser(username, property, newValue);
        }
    }
}