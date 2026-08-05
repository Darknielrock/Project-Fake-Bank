using PaymentGateway.Application.Common.Interfaces;
using PaymentGateway.Shared.Events;

namespace PaymentGateway.Worker.Services;

public class PaymentProcessorService
{
    private readonly CardAuthorizationService _authorizationService;
    private readonly IKafkaProducer _kafkaProducer;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILogger _logger;
    public PaymentProcessorService(
        CardAuthorizationService authorizationService,
        IKafkaProducer kafkaProducer,
        IPaymentRepository paymentRepository,
        ILogger logger  )
    {
        _authorizationService = authorizationService;
        _kafkaProducer = kafkaProducer;
        _paymentRepository = paymentRepository;
        _logger = logger;
    }


    public async Task ProcessAsync(
        PaymentRequestedEvent payment,
        CancellationToken cancellationToken)
    {
        var result = await _authorizationService.AuthorizeAsync(payment);

        if (result)
        {
            var approvedEvent = new PaymentApprovedEvent
            {
                PaymentId = payment.PaymentId,
                AuthorizationCode = Guid.NewGuid().ToString()
            };


            await _kafkaProducer.ProcessPaymentApprovedAsync(
                approvedEvent,
                cancellationToken);
        }
        else
        {
            var rejectedEvent = new PaymentRejectedEvent
            {
                PaymentId = payment.PaymentId,
                RejectionReason = "Error al procesar la solicitud"
            };

            await _kafkaProducer.ProcessPaymentRejectedAsync(
                rejectedEvent,
                cancellationToken);
        }
    }
}