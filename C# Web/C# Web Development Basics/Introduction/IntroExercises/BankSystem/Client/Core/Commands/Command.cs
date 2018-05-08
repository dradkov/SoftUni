namespace BankSystem.Client.Core.Commands
{
    using BankSystem.Client.Contracts;
    using StudentSystem.Data;

    public abstract class Command : IExecutable
    {
        protected BankDbContext db;
        protected string[] arguments;

        public Command(BankDbContext db, string[] arguments)
        {
            this.db = db;
            this.arguments = arguments;
        }

        public abstract string Execute();
    }
}
