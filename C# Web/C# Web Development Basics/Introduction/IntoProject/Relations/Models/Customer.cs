using System.Collections;
using System.Collections.Generic;

namespace Relations.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int SalesmanId { get; set; }

        public Salesman Salesman { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
