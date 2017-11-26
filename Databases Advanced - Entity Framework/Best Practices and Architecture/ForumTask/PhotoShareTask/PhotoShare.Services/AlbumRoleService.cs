namespace PhotoShare.Services
{
    using System;
    using System.Linq;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class AlbumRoleService : IAlbumRoleService
    {
        private readonly PhotoShareContext context;

        public AlbumRoleService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string ShareAlbum(int albumId, string username, string permission)
        {
            var album = context.Albums.SingleOrDefault(a => a.Id == albumId);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            var user = context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var isOwner = String.Equals(permission, Role.Owner.ToString(), StringComparison.InvariantCultureIgnoreCase);

            var isViewer = String.Equals(permission, Role.Viewer.ToString(), StringComparison.InvariantCultureIgnoreCase);

            if (!isOwner && !isViewer)
            {
                throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
            }

            var albumRole = new AlbumRole
            {
                Album = album,

                User = user
            };

            if (isOwner)
            {
                albumRole.Role = Role.Owner;
            }
            else
            {
                albumRole.Role = Role.Viewer;
            }

            context.AlbumRoles.Add(albumRole);

            context.SaveChanges();

            return $"Username {username} added to album {album.Name} ({permission})";
        }
    }
}
