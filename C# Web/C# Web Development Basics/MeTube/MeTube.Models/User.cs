namespace MeTube.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string  Username { get; set; }

        [Required]
        [MinLength(3)]
        public string  Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }

        public ICollection<Tube> Tubes { get; set; } = new List<Tube>();
    }
}

