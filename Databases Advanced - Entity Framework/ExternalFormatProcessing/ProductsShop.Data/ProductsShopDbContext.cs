namespace ProductsShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShop.Data.Configuration;
    using ProductShop.Models;

    public class ProductsShopDbContext : DbContext
    {


        public ProductsShopDbContext()
        {

        }
        public ProductsShopDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }


     


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configurations.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new UserConfiguraion());

            builder.ApplyConfiguration(new CategoryProductConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());



        }

    }
}
