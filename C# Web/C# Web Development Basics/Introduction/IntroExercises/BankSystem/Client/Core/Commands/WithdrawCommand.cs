namespace BankSystem.Client.Core.Commands
{
    using System.Linq;
    using BankSystem.Models;
    using StudentSystem.Data;

    public class WithdrawCommand : Command
    {
        public WithdrawCommand(BankDbContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;


            string accountNumber = this.arguments[0];

            decimal money = decimal.Parse(this.arguments[1]);

            if (this.db.CheckingAccounts.Any(c => c.AccountNumber == accountNumber))
            {
                CheckingAccount account = this.db.CheckingAccounts.First(c => c.AccountNumber == accountNumber);

                account.Balance -= money;

                this.db.SaveChanges();

                result = string.Format(SuccessMesseges.AccountCurrentBalance, accountNumber, account.Balance);
                return result;
            }
            else if (this.db.SavingAccounts.Any(c => c.AccountNumber == accountNumber))
            {
                SavingAccount account = this.db.SavingAccounts.First(c => c.AccountNumber == accountNumber);

                account.Balance -= money;

                this.db.SaveChanges();

                result = string.Format(SuccessMesseges.AccountCurrentBalance, accountNumber, account.Balance);
                return result;
            }

            result = string.Format(ErrorMesseges.InvalidAccount, accountNumber);
            return result;

        }
    }
}
