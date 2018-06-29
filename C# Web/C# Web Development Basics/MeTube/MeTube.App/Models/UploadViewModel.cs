namespace MeTube.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UploadViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string YouTubeLink { get; set; }

        [Required]
        public string  Description { get; set; }
    }
}
