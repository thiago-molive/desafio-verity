using System.Data;

namespace EasyCash.Domain.Abstractions.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
