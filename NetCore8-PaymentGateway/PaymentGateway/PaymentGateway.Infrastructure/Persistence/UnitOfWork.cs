using PaymentGateway.Application.Common.Interfaces;

public class UnitOfWork
    : IUnitOfWork
{
    private readonly PaymentDbContext _context;

    public UnitOfWork(
        PaymentDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(
            cancellationToken);
    }
}