namespace P01_BillsPaymentSystem.Data.DataConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {


            builder
                .ToTable("PaymentMethods");

            builder
                .HasKey(pm => pm.Id);

            builder
                .HasIndex(pm => new
                {
                    pm.CreditCardId,
                    pm.BankAccountId,
                    pm.UserId
                })
                .IsUnique();
         


            builder
                .HasOne(pm => pm.BankAccount)
                .WithOne(ba => ba.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId);

            builder
                .HasOne(pm => pm.CreditCard)
                .WithOne(ca => ca.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId);

            builder
                .HasOne(e => e.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId);
        }
    }
}
