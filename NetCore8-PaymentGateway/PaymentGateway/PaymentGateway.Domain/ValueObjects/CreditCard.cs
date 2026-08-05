namespace PaymentGateway.Domain.ValueObjects;

public class CreditCard
{
    public string Number { get; }

    public string Holder { get; }

    public string ExpirationMonth { get; }

    public string ExpirationYear { get; }

    public CreditCard(
        string number,
        string holder,
        string expirationMonth,
        string expirationYear)
    {
        Number = number;

        Holder = holder;

        ExpirationMonth = expirationMonth;

        ExpirationYear = expirationYear;
    }

    public string Mask()
    {
        return $"{Number[..6]}******{Number[^4..]}";
    }
}