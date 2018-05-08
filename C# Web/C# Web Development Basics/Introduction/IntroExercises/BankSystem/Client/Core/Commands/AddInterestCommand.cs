namespace BankSystem.Client.Core.Commands
{
    using System.Linq;
    using BankSystem.Models;
    using StudentSystem.Data;

    public class AddInterestCommand : Command
    {
        public AddInterestCommand(BankDbContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;

            string accountNumber = this.arguments[0];

            if (this.db.SavingAccounts.Any(c => c.AccountNumber == accountNumber))
            {
                SavingAccount account = this.db.SavingAccounts.First(c => c.AccountNumber == accountNumber);

                var addRate = account.InterestRate*account.Balance;

                account.Balance += addRate;

                this.db.SaveChanges();


                result = string.Format(SuccessMesseges.IntersetFee, accountNumber, account.Balance);
                return result;
            }

            return result;
        }
    }
}
