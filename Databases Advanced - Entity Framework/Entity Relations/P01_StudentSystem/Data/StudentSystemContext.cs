namespace P01_StudentSystem.Data
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.DataConfigurations;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configurations.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new CourseConfiguration());

            builder.ApplyConfiguration(new StudentConfiguration());

            builder.ApplyConfiguration(new StudentCourseConfiguration());

            builder.ApplyConfiguration(new HomeworkConfiguration());

            builder.ApplyConfiguration(new ResourceConfiguration());
        }
    }
}