namespace MeTube.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tube
    {
        public int Id { get; set; }

        [Required]
        public string  Title { get; set; }

        [Required]
        public string  Author { get; set; }

        [Required]
        public string  Description { get; set; }

        [Required]
        public string YouTubeVideo { get; set; }
     
        public int Views { get; set; } = 0;

        public int  UserId { get; set; }

        public User User { get; set; }
    }
}

