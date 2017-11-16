namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.DataConfigurations;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {

        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<Team> Teams { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new BetConfigurations());

            builder.ApplyConfiguration(new ColorConfigurations());

            builder.ApplyConfiguration(new CountryConfigurations());

            builder.ApplyConfiguration(new GameConfigurations());

            builder.ApplyConfiguration(new PlayerConfigurations());

            builder.ApplyConfiguration(new PlayerStatisticConfigurations());

            builder.ApplyConfiguration(new PositionConfigurations());

            builder.ApplyConfiguration(new TeamConfigurations());

            builder.ApplyConfiguration(new TownConfigurations());

            builder.ApplyConfiguration(new UserConfigurations());
        }
    }
}
