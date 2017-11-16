namespace P01_StudentSystem.Data.DataConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");

            builder
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder
                .Property(r => r.Url)
                .IsUnicode(false);


        }
    }
}
