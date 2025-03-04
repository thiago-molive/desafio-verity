﻿using EasyCash.Command.Store.Contexts;
using EasyCash.Domain.Abstractions.Idempotency.Entity;
using EasyCash.Domain.Abstractions.Idempotency.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.Command.Store.Repositories.Idempotency;

internal sealed class IdempotencyCommandStore : Repository<IdempotencyEntity, string>, IIdempotencyCommandStore
{
    public IdempotencyCommandStore(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task AddAsync(IdempotencyEntity entity, CancellationToken cancellationToken = default)
    {
        await DbContext.AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public void MarkRequestAsProcessedAsync(IdempotencyEntity entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
    }
}