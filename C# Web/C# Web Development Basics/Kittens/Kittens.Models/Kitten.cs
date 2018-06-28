namespace Kittens.Models
{
    using System.ComponentModel.DataAnnotations;
    using Kittens.Models.Enums;

    public class Kitten
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(6)]
        public string  Name { get; set; }

        [Required]
        [MinLength(0)]
        [MaxLength(18)]
        public int Age { get; set; }

        [Required]
        public BreedType Breed { get; set; }
    }
}
