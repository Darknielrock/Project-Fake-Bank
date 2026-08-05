namespace PaymentGateway.Domain.ValueObjects;

public record Money(
    decimal Amount,
    string Currency);