using Dapper;
using EasyCash.Domain.Abstractions.Interfaces;
using EasyCash.Domain.Abstractions.Messaging.Queries.PagedQueries;
using EasyCash.Query.CashFlow.Get;
using EasyCash.Query.CashFlow.Interfaces;
using EasyCash.Query.Store.CashFlow.Dto;
using System.Data;

namespace EasyCash.Query.Store.CashFlow;

internal sealed class TransactionQueryStore : ITransactionQueryStore
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public TransactionQueryStore(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<GetDailyTransactionsQueryResult> GetDailyTransactionsAsync(GetDailyTransactionsQuery query, CancellationToken cancellationToken)
    {
        var param = new DynamicParameters();
        param.Add("@date", query.Date, direction: ParameterDirection.Input);
        param.Add("@Skip", query.GetPageOffset(), direction: ParameterDirection.Input);
        param.Add("@Take", query.PageSize, direction: ParameterDirection.Input);

        var count = await _sqlConnectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<int>(
                new CommandDefinition(TransactionQueryStoreConsts.SQL_COUNT_BY_DATE, param, cancellationToken: cancellationToken));

        if (count == 0)
            return GetDailyTransactionsQueryResult.Empty;

        var result = await _sqlConnectionFactory.CreateConnection()
            .QueryAsync<TransactionDto>(
                new CommandDefinition(TransactionQueryStoreConsts.SQL_GET_BY_DATE, param, cancellationToken: cancellationToken));

        var transactionDtos = result as TransactionDto[] ?? result.ToArray();

        return GetDailyTransactionsQueryResult.Create(transactionDtos.Select(TransactionDto.MapToResult).ToArray(), query, count);
    }
}