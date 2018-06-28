namespace Kittens.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string  Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
