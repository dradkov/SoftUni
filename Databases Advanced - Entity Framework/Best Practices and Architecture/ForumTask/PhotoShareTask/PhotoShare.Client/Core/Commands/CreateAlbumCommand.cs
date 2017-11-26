namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PhotoShare.Client.Core.Contracts;

    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;

        public CreateAlbumCommand(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string command, params string[] data)
        {
            if (data.Length < 4)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username = data[0];
            string albumTitle = data[1];
            string BgColor = data[2];
            List<string> tagNames = data.Skip(3).ToList();

            return albumService.CreateAlbum(username, albumTitle, BgColor, tagNames);
        }
    }
}