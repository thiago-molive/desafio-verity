using EasyCash.Query.Store.CashFlow.Dto;

namespace EasyCash.Query.Store.CashFlow;

internal static class TransactionQueryStoreConsts
{
    internal const string SQL_GET_BY_DATE =
        $@"
        SELECT
            id {nameof(TransactionDto.Id)},
            description {nameof(TransactionDto.Description)},
            type {nameof(TransactionDto.Type)},
            Amount {nameof(TransactionDto.Amount)},
            Category {nameof(TransactionDto.Category)},
            Date {nameof(TransactionDto.Date)}
        FROM
            transactions
        WHERE
            Date::DATE = @date
        limit @Take offset @Skip";

    internal const string SQL_COUNT_BY_DATE =
        $@"
        SELECT
            COUNT(id)
        FROM
            transactions
        WHERE
            Date::DATE = @date";
}