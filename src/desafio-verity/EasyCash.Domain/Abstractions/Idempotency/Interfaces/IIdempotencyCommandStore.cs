using EasyCash.Domain.Abstractions.Idempotency.Entity;

namespace EasyCash.Domain.Abstractions.Idempotency.Interfaces;

public interface IIdempotencyCommandStore
{
    Task<IdempotencyEntity?> GetByIdAsync(string key, CancellationToken cancellationToken);

    Task AddAsync(IdempotencyEntity idempotencyEntity, CancellationToken cancellationToken);

    void MarkRequestAsProcessedAsync(IdempotencyEntity entity);
}