namespace BankSystem.Models
{
   public class CheckingAccount
    {

        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public decimal Fee { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
       
    }
}
