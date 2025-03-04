using EasyCash.Domain.Abstractions.Repository;
using EasyCash.Domain.CashFlow.Entities;

namespace EasyCash.Domain.CashFlow.Interfaces;

public interface ITransactionsCommandStore : IGetRepository<TransactionEntity, Guid>, IAddRepository<TransactionEntity, Guid>
{
    
}