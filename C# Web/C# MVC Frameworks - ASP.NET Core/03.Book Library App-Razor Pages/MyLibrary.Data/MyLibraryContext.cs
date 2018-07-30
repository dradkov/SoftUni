namespace MyLibrary.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Models;

    public class MyLibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BorrowersBooks> BorrowersBooks { get; set; }
        public DbSet<BorrowHistory> BorrowHistories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerParameters.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Borrowers)
                .WithOne(bb => bb.Book)
                .HasForeignKey(bb => bb.BookId);

            modelBuilder.Entity<Borrower>()
                .HasMany(b => b.BorrowedBooks)
                .WithOne(bb => bb.Borrower)
                .HasForeignKey(bb => bb.BorrowerId);

            modelBuilder.Entity<BorrowersBooks>()
                .HasKey(bb => bb.Id);

            modelBuilder.Entity<Author>()
                .HasIndex(a => a.Name)
                .IsUnique();

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Title);

            base.OnModelCreating(modelBuilder);
        }

    }
}
