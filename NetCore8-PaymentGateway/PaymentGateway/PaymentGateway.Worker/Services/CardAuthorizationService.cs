using PaymentGateway.Shared.Events;

namespace PaymentGateway.Worker.Services;

public class CardAuthorizationService
{

    public Task<bool> AuthorizeAsync(PaymentRequestedEvent payment)
    {

        var approved = Random.Shared.Next(1, 10) <= 5;


        return Task.FromResult(approved);
    }
}