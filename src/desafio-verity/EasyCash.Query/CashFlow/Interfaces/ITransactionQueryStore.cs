using EasyCash.Query.CashFlow.Get;

namespace EasyCash.Query.CashFlow.Interfaces;

public interface ITransactionQueryStore
{
    Task<GetDailyTransactionsQueryResult> GetDailyTransactionsAsync(GetDailyTransactionsQuery query, CancellationToken cancellationToken);
}