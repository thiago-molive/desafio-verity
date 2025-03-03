using EasyCash.Domain.Idempotency.Entity;

namespace EasyCash.Domain.Idempotency.Interfaces;

public interface IIdempotencyCommandStore
{
    Task<IdempotencyEntity?> GetByIdAsync(string key, CancellationToken cancellationToken);

    Task AddAsync(IdempotencyEntity idempotencyEntity, CancellationToken cancellationToken);

    void MarkRequestAsProcessedAsync(IdempotencyEntity entity);
}