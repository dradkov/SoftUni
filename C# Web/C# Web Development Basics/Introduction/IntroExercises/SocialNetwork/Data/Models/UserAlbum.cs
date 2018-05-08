namespace SocialNetwork.Data.Models
{
    using SocialNetwork.Data.Models.Enums;

    public class UserAlbum
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public Role Role { get; set; }

    }
}
