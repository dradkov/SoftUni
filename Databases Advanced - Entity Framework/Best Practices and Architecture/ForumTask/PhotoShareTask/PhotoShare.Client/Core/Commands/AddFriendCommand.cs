namespace PhotoShare.Client.Core.Commands
{

    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class AddFriendCommand : ICommand
    {
        private readonly IFriendshipService friendshipService;

        public AddFriendCommand(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string command, string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username = data[0];
            string friendUsername = data[1];

            return friendshipService.AddFriend(username, friendUsername);
        }
    }
}