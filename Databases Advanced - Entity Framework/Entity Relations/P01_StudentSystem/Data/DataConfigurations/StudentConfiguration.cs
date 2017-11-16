namespace P01_StudentSystem.Data.DataConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(s => s.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .IsUnicode(false)
                .IsRequired(false);

            builder.Property(s => s.Birthday)
                .IsRequired(false);


            builder
                .HasMany(s => s.HomeworkSubmissions)
                .WithOne(s => s.Student)
                .HasForeignKey(h => h.StudentId);

        }
    }
}
