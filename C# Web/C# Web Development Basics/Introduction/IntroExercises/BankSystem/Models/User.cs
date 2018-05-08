namespace BankSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BankSystem.Client.Core;

    public class User
    {
        public int Id { get; set; }

        [Required]

        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<SavingAccount> SavingAccounts { get; set; } = new List<SavingAccount>();

        public ICollection<CheckingAccount> CheckingAccounts { get; set; } = new List<CheckingAccount>();

    }
}
