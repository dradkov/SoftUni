namespace P01_StudentSystem.Data.DataConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.ToTable("Courses");

            builder
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode();

            builder
                .Property(c => c.Description)
                .IsUnicode()
                .IsRequired(false);


            builder
                .HasMany(c => c.Resources)
                .WithOne(c => c.Course)
                .HasForeignKey(r => r.CourseId);

            builder
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(c => c.Course)
                .HasForeignKey(h => h.CourseId);
        }
    }
}
