namespace Kittens.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [Range(0,20)]
        public int Age { get; set; }

        [Required]
        [MaxLength(30)]
        public string  Breed { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
