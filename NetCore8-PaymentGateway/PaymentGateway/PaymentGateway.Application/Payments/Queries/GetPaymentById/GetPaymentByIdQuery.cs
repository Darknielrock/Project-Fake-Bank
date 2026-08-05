using MediatR;
using PaymentGateway.Application.Payments.DTOs;

namespace PaymentGateway.Application.Payments.Queries.GetPaymentById;

public sealed record GetPaymentByIdQuery(Guid Id)
    : IRequest<PaymentDto>;