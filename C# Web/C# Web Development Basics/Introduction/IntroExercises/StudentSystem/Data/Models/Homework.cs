namespace StudentSystem.Data.Models
{
    using System;
    using StudentSystem.Data.Models.Enums;

    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmitionTime { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
