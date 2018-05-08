namespace BankSystem.Models
{
    public class SavingAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
