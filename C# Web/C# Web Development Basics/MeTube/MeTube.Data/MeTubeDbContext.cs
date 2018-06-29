namespace MeTube.Data
{
    using MeTube.Models;
    using Microsoft.EntityFrameworkCore;

    public class MeTubeDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Tube> Tubes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MeTubeDb-Test;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


            builder
                .Entity<Tube>()
                .HasOne(u => u.User)
                .WithMany(t => t.Tubes)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
