using Microsoft.EntityFrameworkCore;

namespace Stations.Data
{
    using Stations.Models;

    public class StationsDbContext : DbContext
    {
        public StationsDbContext()
        {
        }

        public StationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<CustomerCard> Cards { get; set; }

        public DbSet<SeatingClass> SeatingClasses { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Train> Trains { get; set; }

        public DbSet<TrainSeat> TrainSeats { get; set; }

        public DbSet<Trip> Trips { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Station>().HasAlternateKey(s => s.Name);

            builder.Entity<Train>().HasAlternateKey(s => s.TrainNumber);

            builder.Entity<SeatingClass>().HasAlternateKey(s => new { s.Name, s.Abbreviation });


            builder.Entity<Station>()
                .HasMany(s => s.TripsFrom)
                .WithOne(c => c.OriginStation)
                .HasForeignKey(c => c.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Station>()
                .HasMany(s => s.TripsTo)
                .WithOne(c => c.DestinationStation)
                .HasForeignKey(c => c.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Train>()
                .HasMany(t => t.Trips)
                .WithOne(c => c.Train)
                .HasForeignKey(c => c.TrainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Train>()
                .HasMany(t => t.TrainSeats)
                .WithOne(c => c.Train)
                .HasForeignKey(c => c.TrainId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}