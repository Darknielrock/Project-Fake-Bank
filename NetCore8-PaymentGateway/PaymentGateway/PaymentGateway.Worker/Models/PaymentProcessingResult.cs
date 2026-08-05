namespace PaymentGateway.Worker.Models;

public class PaymentProcessingResult
{
    public bool Approved { get; set; }

    public string AuthorizationCode { get; set; }
        = string.Empty;

    public string Reason { get; set; }
        = string.Empty;
}