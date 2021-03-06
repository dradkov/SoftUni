﻿namespace StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<StudentCourses> Students { get; set; } = new List<StudentCourses>();

        public ICollection<Resource> Resources { get; set; } = new List<Resource>();

        public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();


    }
}
