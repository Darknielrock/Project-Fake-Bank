namespace PaymentGateway.Application.Payments.DTOs;

public sealed class PaymentDto
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string CardHolder { get; set; } = string.Empty;

    public string CardNumberMasked { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string? AuthorizationCode { get; set; }

    public DateTime CreatedDate { get; set; }
}