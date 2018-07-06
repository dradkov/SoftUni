namespace Kittens.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CatsDbContext  : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        public CatsDbContext(DbContextOptions<CatsDbContext> options)
                :base (options)
        {
            
        }
        
    }
}
