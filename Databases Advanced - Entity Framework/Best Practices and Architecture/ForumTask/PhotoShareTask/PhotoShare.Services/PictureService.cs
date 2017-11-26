namespace PhotoShare.Services
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Linq;

    public class PictureService : IPictureService
    {
        private readonly PhotoShareContext context;

        public PictureService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string UploadPicture(string albumName, string pictureTitle, string pictureFilePath, string username)
        {
            Album album = FindAlbum(albumName);

            User user = FindUser(username);

            var role = album.AlbumRoles.SingleOrDefault(ar => ar.User == user);

            if (role == null || !role.Role.Equals(Role.Owner))
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            var picture = new Picture()
            {
                Title = pictureTitle,
                Path = pictureFilePath,
                Album = album,
                UserProfile = user
            };

            context.Pictures.Add(picture);

            context.SaveChanges();

            return $"Picture {pictureTitle} added to {albumName}!";
        }

        private User FindUser(string username)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            return user;
        }

        private Album FindAlbum(string albumName)
        {
            var album = context.Albums.Include(a => a.AlbumRoles).SingleOrDefault(a => a.Name == albumName);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            return album;
        }
    }
}