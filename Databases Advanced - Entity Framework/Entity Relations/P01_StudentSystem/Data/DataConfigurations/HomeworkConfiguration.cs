namespace P01_StudentSystem.Data.DataConfigurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable("HomeworkSubmissions");

            builder
                .Property(h => h.Content)
                .IsUnicode(false);

        }
    }
}
