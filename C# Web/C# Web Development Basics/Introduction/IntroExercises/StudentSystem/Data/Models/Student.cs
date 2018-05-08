namespace StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {

        public int Id  { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationTime { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<StudentCourses> Courses { get; set; } = new List<StudentCourses>();

        public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}