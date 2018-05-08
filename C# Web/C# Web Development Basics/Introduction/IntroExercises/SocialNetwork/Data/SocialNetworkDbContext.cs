namespace SocialNetwork.Data
{
    using Microsoft.EntityFrameworkCore;
    using SocialNetwork.Data.Models;

    public class SocialNetworkDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Tag> Tags { get; set; }


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
                .Entity<User>()
                .HasOne(u => u.Friend)
                .WithMany(f => f.Firends)
                .HasForeignKey(u => u.FriendId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Entity<PictureAlbum>()
                .HasKey(pa => new { pa.AlbumId, pa.PictureId });

            builder
                .Entity<PictureAlbum>()
                .HasOne(pa => pa.Album)
                .WithMany(a => a.Pictures)
                .HasForeignKey(pa => pa.PictureId);

            builder
                .Entity<PictureAlbum>()
                .HasOne(pa => pa.Picture)
                .WithMany(p => p.Albums)
                .HasForeignKey(pa => pa.PictureId);

            builder
                .Entity<AlbumTag>()
                .HasKey(at => new { at.AlbumId, at.TagId });

            builder
                .Entity<AlbumTag>()
                .HasOne(at => at.Album)
                .WithMany(a => a.Tags)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AlbumTag>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.Albums)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<UserAlbum>()
                .HasKey(ua => new {ua.UserId, ua.AlbumId});

            builder
                .Entity<UserAlbum>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.Albums)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<UserAlbum>()
                .HasOne(ua => ua.Album)
                .WithMany(u => u.Users)
                .HasForeignKey(ua => ua.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);


        }

    }
}
