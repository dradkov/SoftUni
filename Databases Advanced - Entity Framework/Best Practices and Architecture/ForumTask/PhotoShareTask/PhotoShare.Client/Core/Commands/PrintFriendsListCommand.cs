namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class PrintFriendsListCommand : ICommand
    {
        private readonly IUserService userService;

        public PrintFriendsListCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // PrintFriendsList <username>
        public string Execute(string command, string[] data)
        {
            if (data.Length < 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            var username = data[0];

            return userService.PrintFriends(username);
        }
    }
}