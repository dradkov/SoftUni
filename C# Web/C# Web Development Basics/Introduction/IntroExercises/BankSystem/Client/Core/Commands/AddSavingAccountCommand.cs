namespace BankSystem.Client.Core.Commands
{
    using BankSystem.Client.Core.Helper;
    using BankSystem.Models;
    using StudentSystem.Data;

    public class AddSavingAccountCommand : Command
    {
        public AddSavingAccountCommand(BankDbContext db, string[] arguments) : base(db, arguments)
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

            decimal rate = decimal.Parse(this.arguments[1]);

            string acNumber = RandomGenerator.GenerateString(10);



            SavingAccount savingAccount = new SavingAccount()
            {
                AccountNumber = acNumber,
                UserId = Engine.CurrentUserId,
                Balance = balance,
                InterestRate = rate
            };

            this.db.SavingAccounts.Add(savingAccount);

            this.db.SaveChanges();

            result = string.Format(SuccessMesseges.AddAccount,acNumber);

            return result;
        }
    }
}
