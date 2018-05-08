namespace FootballBetting
{
    using System;
    using FootballBetting.Data;

    public class StartUp
    {
       public static void Main(string[] args)
        {
            using (FootballDbContext db = new FootballDbContext() )
            {
                SetDb(db);
            }
        }

        private static void SetDb(FootballDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
