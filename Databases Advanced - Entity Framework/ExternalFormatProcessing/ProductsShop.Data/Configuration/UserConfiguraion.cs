namespace ProductsShop.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models;

   public class UserConfiguraion : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.UserId);

            builder.Property(e => e.FirstName).IsRequired(false);
            builder.Property(e => e.LastName).IsRequired(true);
            builder.Property(e => e.Age).IsRequired(false);


        }
    }
}
