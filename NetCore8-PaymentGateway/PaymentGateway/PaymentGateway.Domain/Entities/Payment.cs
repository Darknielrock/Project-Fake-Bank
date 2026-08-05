namespace PaymentGateway.Domain.Entities;

using PaymentGateway.Domain.Common;
using PaymentGateway.Domain.Enums;

public class Payment : AuditableEntity
{
    public decimal Amount { get; private set; }

    public string Currency { get; private set; } = string.Empty;

    public string CardHolder { get; private set; } = string.Empty;

    public string CardNumberMasked { get; private set; } = string.Empty;

    public PaymentStatus Status { get; private set; }

    public string? AuthorizationCode { get; private set; }

    public string? RejectionReason { get; private set; }

    public Payment(
        decimal amount,
        string currency,
        string cardHolder,
        string cardNumberMasked)
    {
        Id = Guid.NewGuid();

        Amount = amount;

        Currency = currency;

        CardHolder = cardHolder;

        CardNumberMasked = cardNumberMasked;

        Status = PaymentStatus.Pending;

        CreatedDate = DateTime.UtcNow;
    }

    public void Approve(string authorizationCode)
    {
        Status = PaymentStatus.Approved;

        AuthorizationCode = authorizationCode;

        UpdatedDate = DateTime.UtcNow;
    }

    public void Reject(string reason)
    {
        Status = PaymentStatus.Rejected;

        RejectionReason = reason;

        UpdatedDate = DateTime.UtcNow;
    }
}