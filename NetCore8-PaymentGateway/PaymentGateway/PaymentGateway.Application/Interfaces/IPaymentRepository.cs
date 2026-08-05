using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Application.Common.Interfaces;

public interface IPaymentRepository
{
    Task AddAsync(
        Payment payment,
        CancellationToken cancellationToken);

    Task<Payment?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

    Task UpdateAsync(
        Payment payment,
        CancellationToken cancellationToken);
}