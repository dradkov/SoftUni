namespace FootballBetting.Data
{
    using System.Data.SqlClient;
    using FootballBetting.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
        public DbSet<BetGame> BetGames { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<ResultPrediction> ResultPredictions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Team>()
                .HasOne(t => t.PrimaryKitColor)
                .WithMany()
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Team>()
                .HasOne(t => t.SecondaryKitColor)
                .WithMany()
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Team>()
                .HasOne(t => t.Town)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Town>()
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

         


            builder
                .Entity<CountryContinents>()
                .HasKey(cc => new { cc.ContinentId, cc.CountryId });

            builder
                .Entity<CountryContinents>()
                .HasOne(c => c.Country)
                .WithMany(cn => cn.ContinentList)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<CountryContinents>()
                .HasOne(c => c.Continent)
                .WithMany(cn => cn.CountryList)
                .HasForeignKey(c => c.ContinentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Player>()
                .HasOne(p => p.Position)
                .WithMany(po => po.Players)
                .HasForeignKey(p => p.PositionId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Entity<PlayerGames>()
                .HasKey(pg => new { pg.PlayerId, pg.GameId });

            builder
                .Entity<PlayerGames>()
                .HasOne(pg => pg.Player)
                .WithMany(p => p.Games)
                .HasForeignKey(pg => pg.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<PlayerGames>()
                .HasOne(pg => pg.Game)
                .WithMany(p => p.Players)
                .HasForeignKey(pg => pg.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<PlayerStatistic>()
                .HasOne(ps=>ps.Player)
                .WithMany(p=>p.PlayerStatistics)
                .HasForeignKey(ps=>ps.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<PlayerStatistic>()
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .Entity<Game>()
                .HasOne(g=>g.Round)
                .WithMany(r=>r.Games)
                .HasForeignKey(g=>g.RoundId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Game>()
                .HasOne(g => g.Competition)
                .WithMany(c => c.Games)
                .HasForeignKey(g => g.CompetitionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Game>()
                .HasOne(g=>g.AwayTeam)
                .WithMany(t=>t.AwayGames)
                .HasForeignKey(g=>g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<BetGame>()
                .HasKey(bt => new {bt.BetId, bt.GameId});

            builder
                .Entity<BetGame>()
                .HasOne(bt=>bt.Game)
                .WithMany(g=>g.Bets)
                .HasForeignKey(bt=>bt.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<BetGame>()
                .HasOne(bt => bt.Bet)
                .WithMany(b => b.Games)
                .HasForeignKey(bt => bt.BetId)
                .OnDelete(DeleteBehavior.Restrict);
  

            builder.Entity<BetGame>()
                .HasOne(bg => bg.ResultPrediction)
                .WithMany()
                .HasForeignKey(bg => bg.ResultPredictionId);

            builder
                .Entity<Bet>()
                .HasOne(b=>b.User)
                .WithMany(u=>u.Bets)
                .HasForeignKey(b=>b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}