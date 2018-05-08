namespace Relations.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();
    }
}
