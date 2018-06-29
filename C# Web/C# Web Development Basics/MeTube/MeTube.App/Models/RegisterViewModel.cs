namespace MeTube.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string  Username { get; set; }

        [Required]
        [MinLength(3)]
        public string  Password { get; set; }

        [Required]
        [Compare("Password")]
        public string  ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }
    }
}
