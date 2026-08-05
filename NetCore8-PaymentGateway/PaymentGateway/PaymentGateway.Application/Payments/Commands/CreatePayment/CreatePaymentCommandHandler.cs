using MediatR;
using PaymentGateway.Application.Common.Interfaces;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Enums;

namespace PaymentGateway.Application.Payments.Commands.CreatePayment;

public sealed class CreatePaymentCommandHandler
    : IRequestHandler<CreatePaymentCommand, Guid>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IKafkaProducer _kafkaProducer;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaymentCommandHandler(
        IPaymentRepository paymentRepository,
        IKafkaProducer kafkaProducer,
        IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _kafkaProducer = kafkaProducer;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        CreatePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var payment = new Payment(
            request.Amount,
            request.Currency,
            request.CardHolder,
            MaskCardNumber(request.CardNumber)
        );

        await _paymentRepository.AddAsync(payment, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _kafkaProducer.PublishPaymentRequestAsync(payment, cancellationToken);

        return payment.Id;
    }

    private static string MaskCardNumber(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length < 10)
            return "****";

        return $"{cardNumber[..6]}******{cardNumber[^4..]}";
    }
}