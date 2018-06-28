namespace Kittens.Data
{
    using Kittens.Models;
    using Microsoft.EntityFrameworkCore;

    public class KittenDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Kitten> Kittens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=KittensDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

        }
    }
}
