namespace PhotoShare.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class AlbumService : IAlbumService
    {
        private readonly PhotoShareContext context;

        public AlbumService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string CreateAlbum(string username, string albumTitle, string BgColor, List<string> tagNames)
        {
            User user = FindUser(username);

            Album album = FindAlbum(albumTitle);

            Color color = FindColor(BgColor);

            List<Tag> tags = FindTagList(tagNames);

            Album currentAlbum = CreateAlbum(albumTitle, album, color);

            CreateAlbumTags(currentAlbum, tags);

            return $"Album {albumTitle} successfully created!";
        }

        private void CreateAlbumTags(Album album, List<Tag> tags)
        {
            var albumTags = new List<AlbumTag>();

            foreach (var tag in tags)
            {
                var albumTag = new AlbumTag()
                {
                    Tag = tag,
                    Album = album
                };

                albumTags.Add(albumTag);
            }

            context.AlbumTags.AddRange(albumTags);

            context.SaveChanges();
        }

        private Album CreateAlbum(string albumTitle, Album album, Color color)
        {
            album = new Album
            {
                Name = albumTitle,
                BackgroundColor = color
            };

            context.Albums.Add(album);

            context.SaveChanges();

            return album;
        }

        private List<Tag> FindTagList(List<string> tagNames)
        {
            List<Tag> tags = context.Tags.Where(t => tagNames.Contains(t.Name.Substring(1))).ToList();

            if (tags.Count == 0)
            {
                throw new ArgumentException("Invalid tags!");
            }

            return tags;
        }

        private static Color FindColor(string BgColor)
        {
            Color color;
            bool hasColor = Enum.TryParse<Color>(BgColor, true, out color);

            if (!hasColor)
            {
                throw new ArgumentException($"Color {BgColor} not found!");
            }

            return color;
        }

        private Album FindAlbum(string albumTitle)
        {
            var album = context.Albums.SingleOrDefault(a => a.Name == albumTitle);

            if (album != null)
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            return album;
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


    }
}