namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Services.Contracts;
    using PhotoShare.Client.Core.Contracts;

    public class AcceptFriendCommand : ICommand
    {
        private readonly IFriendshipService friendshipService;

        public AcceptFriendCommand(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string command, string[] data)
        {
            if (data.Length < 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username1 = data[0];
            string username2 = data[1];

            return friendshipService.AcceptFriend(username1, username2);
        }
    }
}