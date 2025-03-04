using EasyCash.Domain.Abstractions.Messaging.Queries;
using EasyCash.Query.Transactions.Interfaces;

namespace EasyCash.Query.Transactions.Get;

internal sealed class GetDailyTransactionsQueryHandler : IQueryHandler<GetDailyTransactionsQuery, GetDailyTransactionsQueryResult>
{
    private readonly ITransactionQueryStore _transactionQueryStore;

    public GetDailyTransactionsQueryHandler(ITransactionQueryStore transactionQueryStore)
    {
        _transactionQueryStore = transactionQueryStore;
    }

    public async Task<GetDailyTransactionsQueryResult> Handle(GetDailyTransactionsQuery request, CancellationToken cancellationToken)
    {
        return await _transactionQueryStore.GetDailyTransactionsAsync(request, cancellationToken);
    }
}

