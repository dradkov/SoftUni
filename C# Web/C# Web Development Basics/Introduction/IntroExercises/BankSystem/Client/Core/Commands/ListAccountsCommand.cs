namespace BankSystem.Client.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using StudentSystem.Data;

    public class ListAccountsCommand : Command
    {
        public ListAccountsCommand(BankDbContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;


            if (!Engine.UserIsLogged)
            {
                result = ErrorMesseges.NoUserLogedIn;

                return result;
            }

            var user = this.db.Users
                .Where(u => u.Id == Engine.CurrentUserId)
                .Select(a => new
                {
                    SA = a.SavingAccounts.Select(sa => new
                    {
                        sa.Balance,
                        sa.AccountNumber
                    }).OrderBy(sa => sa.AccountNumber),
                    CA = a.CheckingAccounts.Select(ca => new
                    {
                        ca.Balance,
                        ca.AccountNumber
                    }).OrderBy(sa => sa.AccountNumber)
                }).First();



            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Saving Accounts:");

         
            foreach (var sa in user.SA)
            {
                sb.AppendLine($"--{sa.AccountNumber} {sa.Balance}");
            }
           sb.AppendLine($"Checking Accounts:");

            foreach (var ca in user.CA)
            {
               sb.AppendLine($"--{ca.AccountNumber} {ca.Balance}");
            }
            return sb.ToString();
        }
    }
}
