using System.Collections;
using System.Collections.Generic;

namespace Relations.Models
{
    using System.ComponentModel.DataAnnotations;

   public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
