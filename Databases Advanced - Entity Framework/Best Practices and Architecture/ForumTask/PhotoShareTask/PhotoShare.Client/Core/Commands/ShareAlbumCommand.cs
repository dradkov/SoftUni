namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IAlbumRoleService albumRoleService;

        public ShareAlbumCommand(IAlbumRoleService albumRoleService)
        {
            this.albumRoleService = albumRoleService;
        }

        public string Execute(string command, params string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            int albumId;
            bool result = int.TryParse(data[0], out albumId);

            if (!result)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username = data[1];
            string permission = data[2];

            return albumRoleService.ShareAlbum(albumId, username, permission);
        }
    }
}