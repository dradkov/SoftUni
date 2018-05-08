namespace BankSystem.Client.Core.Commands
{
    using BankSystem.Client.Core.Helper;
    using BankSystem.Models;
    using StudentSystem.Data;

    public class AddCheckingAccountCommand : Command
    {
        public AddCheckingAccountCommand(BankDbContext db, string[] arguments) : base(db, arguments)
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

            decimal balance = decimal.Parse(this.arguments[0]);

            decimal fee = decimal.Parse(this.arguments[1]);

            string acNumber = RandomGenerator.GenerateString(10);

            CheckingAccount checkingAccount = new CheckingAccount()
            {
               UserId = Engine.CurrentUserId,
               AccountNumber = acNumber,
               Fee = fee,
               Balance = balance,
            };


            this.db.CheckingAccounts.Add(checkingAccount);

            this.db.SaveChanges();

            result = string.Format(SuccessMesseges.AddAccount, acNumber);

            return result;
        }
    }
}
