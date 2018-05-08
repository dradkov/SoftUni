namespace SocialNetwork.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public string BackgroundColor { get; set; }

        [RegularExpression(@"(^public?|^not public?)")]
        public string Information { get; set; }

        //public int  UserId { get; set; }

        //public User User { get; set; }

        public ICollection<PictureAlbum> Pictures { get; set; } = new List<PictureAlbum>();

        public ICollection<AlbumTag> Tags { get; set; } = new List<AlbumTag>();

        public ICollection<UserAlbum> Users { get; set; } = new List<UserAlbum>();



    }
}
