namespace StudentSystem.Data.Models
{
    using System.Collections.Generic;
    using StudentSystem.Data.Models.Enums;

    public class Resource
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ResourseType Resourse  { get; set; }

        public string Url { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<License> Licenses { get; set; } = new List<License>();

    }
}
