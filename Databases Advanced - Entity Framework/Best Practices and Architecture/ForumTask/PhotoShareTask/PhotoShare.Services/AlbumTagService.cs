namespace PhotoShare.Services
{
    using System;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class AlbumTagService : IAlbumTagService
    {
        private readonly PhotoShareContext context;

        public AlbumTagService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string AddTagTo(string albumName, string tagName, int userId)
        {
            var album = context.Albums.Include(a => a.AlbumRoles).SingleOrDefault(a => a.Name == albumName);

            var tag = context.Tags.SingleOrDefault(t => t.Name == "#" + tagName);

            if (album == null || tag == null)
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            var role = album.AlbumRoles.SingleOrDefault(ar => ar.UserId == userId);

            if (role == null || !role.Role.Equals(Role.Owner))
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }
            var albumTag = new AlbumTag
            {
                Album = album,
                Tag = tag
            };

            context.AlbumTags.Add(albumTag);

            context.SaveChanges();

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
