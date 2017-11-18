namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class CreditCard
    {

        public int CreditCardId { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed; // Calculate property

        public DateTime ExpirationDate { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


        public void Withdraw(decimal amount)
        {
            if (amount > this.LimitLeft)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }

            this.MoneyOwed -= amount;
        }

        public void Deposit(decimal amount)
        {
            this.MoneyOwed += amount;
        }

    }
}
