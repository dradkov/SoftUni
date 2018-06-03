using System.ComponentModel.DataAnnotations;

namespace WebServer.ByTheCakeApplication.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        //public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
