namespace SocialNetwork.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SocialNetwork.Data.Atributes;

    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [Tag]
        public string Title { get; set; }

        public ICollection<AlbumTag> Albums { get; set; } = new List<AlbumTag>();


    }
}
