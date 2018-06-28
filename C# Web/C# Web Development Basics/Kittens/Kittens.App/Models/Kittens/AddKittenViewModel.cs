namespace Kittens.App.Models.Kittens
{
    using System.ComponentModel.DataAnnotations;
    using global::Kittens.Models.Enums;

    public class AddKittenViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(0)]
        [MaxLength(18)]
        public string Age { get; set; }

        [Required]
        public string Breed { get; set; }
    }
}
