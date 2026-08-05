using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using PaymentGateway.Domain.Entities;

public class PaymentConfiguration
    : IEntityTypeConfiguration<Payment>
{
    public void Configure(
        EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
            .HasMaxLength(3);

        builder.Property(x => x.CardHolder)
            .HasMaxLength(150);

        builder.Property(x => x.CardNumberMasked)
            .HasMaxLength(20);

        builder.Property(x => x.AuthorizationCode)
            .HasMaxLength(20);

        builder.Property(x => x.Status)
            .HasConversion<int>();
    }
}