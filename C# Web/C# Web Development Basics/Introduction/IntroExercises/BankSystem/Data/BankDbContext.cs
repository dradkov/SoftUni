namespace StudentSystem.Data
{
    using BankSystem.Data;
    using BankSystem.Models;
    using Microsoft.EntityFrameworkCore;

    public class BankDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<SavingAccount> SavingAccounts { get; set; }

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<SavingAccount>()
                .HasOne(sa => sa.User)
                .WithMany(u => u.SavingAccounts)
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<CheckingAccount>()
                .HasOne(ca => ca.User)
                .WithMany(u => u.CheckingAccounts)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
