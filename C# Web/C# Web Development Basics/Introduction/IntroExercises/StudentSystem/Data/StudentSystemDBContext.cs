namespace StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Data.Models;

    public class StudentSystemDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<License> Licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourses>()
                .HasKey(sc => new {sc.StudentId,sc.CourseId });

            builder
                .Entity<StudentCourses>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);

            builder
                .Entity<StudentCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);

            builder
                .Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);

            builder
                .Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.Homeworks)
                .HasForeignKey(h => h.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Homework>()
                .HasOne(h => h.Student)
                .WithMany(s => s.Homeworks)
                .HasForeignKey(h => h.StudentId);

            builder
                .Entity<License>()
                .HasOne(l => l.Resourse)
                .WithMany(r => r.Licenses)
                .HasForeignKey(l => l.ResourseId);



        }
    }
}
