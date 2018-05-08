namespace Relations.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Salesman
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    }
}
