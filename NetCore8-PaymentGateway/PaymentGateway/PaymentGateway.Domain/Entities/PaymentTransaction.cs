namespace PaymentGateway.Domain.Entities;

using PaymentGateway.Domain.Common;

public class PaymentTransaction : BaseEntity
{
    public Guid PaymentId { get; set; }

    public DateTime ProcessedDate { get; set; }

    public bool Success { get; set; }

    public string? Message { get; set; }
}