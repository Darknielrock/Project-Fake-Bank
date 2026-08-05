using MediatR;

namespace PaymentGateway.Application.Payments.Commands.CreatePayment;

public sealed record CreatePaymentCommand : IRequest<Guid>
{
    public decimal Amount { get; init; }

    public string Currency { get; init; } = string.Empty;

    public string CardNumber { get; init; } = string.Empty;

    public string CardHolder { get; init; } = string.Empty;

    public string ExpirationMonth { get; init; } = string.Empty;

    public string ExpirationYear { get; init; } = string.Empty;

    public string Cvv { get; init; } = string.Empty;
}