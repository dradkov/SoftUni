namespace PhotoShare.Client.Core.Commands
{  
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using PhotoShare.Client.Core.Contracts;

    public class UploadPictureCommand : ICommand
    {
        private readonly IPictureService pictureService;

        public UploadPictureCommand(IPictureService pictureService)
        {
            this.pictureService = pictureService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
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

            string albumName = data[0];
            string pictureTitle = data[1];
            string pictureFilePath = data[2];

            User user = Session.User;

            if (Session.User == null)
            {
                return "You are not logged in!";
            }

            string currentUsername = user.Username;

            return pictureService.UploadPicture(albumName, pictureTitle, pictureFilePath, currentUsername);
        }
    }
}