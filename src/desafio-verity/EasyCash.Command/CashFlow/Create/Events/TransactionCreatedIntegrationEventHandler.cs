﻿using EasyCash.Domain.Abstractions.Interfaces;
using EasyCash.Domain.CashFlow.Events;
using EasyCash.Domain.CashFlow.Interfaces;
using MediatR;

namespace EasyCash.Command.CashFlow.Create.Events;

internal sealed class TransactionCreatedIntegrationEventHandler : INotificationHandler<TransactionCreatedIntegrationEvent>
{
    private readonly ITransactionsCommandStore _transactionsCommandStore;
    private readonly IUnitOfWork _unitOfWork;

    public TransactionCreatedIntegrationEventHandler(ITransactionsCommandStore transactionsCommandStore
        , IUnitOfWork unitOfWork)
    {
        _transactionsCommandStore = transactionsCommandStore;
        _unitOfWork = unitOfWork;
    }


    public async Task Handle(TransactionCreatedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var entity = notification.MapToEntity();

        using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);

        await _transactionsCommandStore.AddAsync(entity, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        transaction.Commit();
    }
}

