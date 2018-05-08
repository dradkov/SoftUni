namespace BankSystem.Client.Core.Commands
{
    using System.Linq;
    using BankSystem.Models;
    using StudentSystem.Data;

    public class DeductFeeCommand : Command
    {
        public DeductFeeCommand(BankDbContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;

            string accountNumber = this.arguments[0];

            if (this.db.CheckingAccounts.Any(c => c.AccountNumber == accountNumber))
            {
                CheckingAccount account = this.db.CheckingAccounts.First(c => c.AccountNumber == accountNumber);

                account.Balance -= account.Fee;

                this.db.SaveChanges();

                result = string.Format(SuccessMesseges.DeductedFee, accountNumber, account.Balance);
                return result;
            }


            result = string.Format(ErrorMesseges.InvalidAccount, accountNumber);
            return result;
        }
    }
}
