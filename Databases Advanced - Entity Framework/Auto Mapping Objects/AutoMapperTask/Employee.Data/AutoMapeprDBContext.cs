namespace Employee.Data
{
    using Microsoft.EntityFrameworkCore;
    using Employee.Models;

    public class AutoMapeprDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AutoMapeprDBContext()
        {

        }
        public AutoMapeprDBContext(DbContextOptions options)
            : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configurations.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Employee>(e =>
            {
                e.HasKey(k => k.EmpoyeeId);
                e.Property(k => k.FirstName).HasMaxLength(20).IsRequired();
                e.Property(k => k.LastName).HasMaxLength(20).IsRequired();
                e.Property(k => k.Salary).IsRequired();
            });


        }
    }
}
