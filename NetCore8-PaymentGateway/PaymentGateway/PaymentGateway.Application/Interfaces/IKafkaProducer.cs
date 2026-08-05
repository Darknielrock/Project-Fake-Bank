using PaymentGateway.Domain.Entities;
using PaymentGateway.Shared.Events;

namespace PaymentGateway.Application.Common.Interfaces;

public interface IKafkaProducer
{
    Task PublishPaymentRequestAsync(Payment payment, CancellationToken cancellationToken);
    Task ProcessPaymentApprovedAsync(PaymentApprovedEvent paymentApproved, CancellationToken cancellationToken);
    Task ProcessPaymentRejectedAsync(PaymentRejectedEvent paymentRejected, CancellationToken cancellationToken);

}