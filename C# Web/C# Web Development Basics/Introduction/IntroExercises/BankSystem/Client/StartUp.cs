namespace BankSystem.Client
{
    using BankSystem.Client.Contracts;
    using BankSystem.Client.Core;
    using StudentSystem.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BankDbContext db= new BankDbContext())
            {
                StartApp(db);
            }
        }

        private static void StartApp(BankDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            IEngine engine = new Engine(db,new CommandInterpreter(db), new ConsoleRead(),new ConsoleWrite());
            engine.Run();

        }
    }
}
