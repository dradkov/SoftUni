namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class AddTagToCommand : ICommand
    {
        private readonly IAlbumTagService albumTagService;

        public AddTagToCommand(IAlbumTagService albumTagService)
        {
            this.albumTagService = albumTagService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string command, params string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string albumName = data[0];
            string tagName = data[1];

            return albumTagService.AddTagTo(albumName, tagName, Session.User.Id);
        }
    }
}