namespace P01_StudentSystem.Data.DataConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder
                .ToTable("StudentCourses");

            builder
                .HasKey(sc => new
                {
                    sc.StudentId,
                    sc.CourseId
                });

            builder
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
