using MediatR;
using PaymentGateway.Application.Common.Interfaces;
using PaymentGateway.Application.Payments.DTOs;

namespace PaymentGateway.Application.Payments.Queries.GetPaymentById;

public sealed class GetPaymentByIdQueryHandler
    : IRequestHandler<GetPaymentByIdQuery, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentByIdQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentDto> Handle(
        GetPaymentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (payment is null)
        {
            throw new KeyNotFoundException(
                $"No se encontró el pago con Id {request.Id}");
        }

        return new PaymentDto
        {
            Id = payment.Id,
            Amount = payment.Amount,
            Currency = payment.Currency,
            CardHolder = payment.CardHolder,
            CardNumberMasked = payment.CardNumberMasked,
            Status = payment.Status.ToString(),
            AuthorizationCode = payment.AuthorizationCode,
            CreatedDate = payment.CreatedDate
        };
    }
}