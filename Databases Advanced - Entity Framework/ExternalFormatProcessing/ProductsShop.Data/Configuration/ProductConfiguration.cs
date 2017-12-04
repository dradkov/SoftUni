namespace ProductsShop.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models;

   public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.Name).IsRequired();

            builder.Property(e => e.Price).IsRequired();

            builder.Property(e => e.SellerId).IsRequired();

            builder.Property(e => e.BuyerId).IsRequired(false);


            builder
                .HasMany(c => c.Categories)
                .WithOne(s => s.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Seller)
                .WithMany(s => s.ProductsSold)
                .HasForeignKey(p => p.SellerId);

            builder.HasOne(p => p.Buyer)
                .WithMany(b => b.ProductsBought)
                .HasForeignKey(p => p.BuyerId);

        }
    }
}
