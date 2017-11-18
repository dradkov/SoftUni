namespace P01_BillsPaymentSystem.Data.DataConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {

            builder
                .ToTable("BankAccounts");

            builder
                .HasKey(b => b.BankAccountId);

            builder
                .Property(b => b.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(b => b.Balance)
                .IsRequired();

            builder
                .Property(b => b.SWIFT)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Ignore(b => b.PaymentMethodId);

        }
    }
}
