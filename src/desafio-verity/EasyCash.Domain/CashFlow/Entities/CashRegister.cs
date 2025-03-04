using EasyCash.Domain.Abstractions;
using EasyCash.Domain.Abstractions.Exceptions;
using EasyCash.Domain.CashFlow.Enums;
using EasyCash.Domain.CashFlow.ValueObjects;

namespace EasyCash.Domain.CashFlow.Entities;

public sealed class CashRegister : EntityBase<Guid>
{
    private List<TransactionEntity> _transactions { get; set; } = [];

    public DateTimeOffset Date { get; private set; }

    public Money OpeningBalance { get; private set; }

    public Money CurrentBalance { get; private set; }

    public Money TotalCredits { get; private set; }

    public Money TotalDebits { get; private set; }

    public IReadOnlyCollection<TransactionEntity> Transactions => _transactions.AsReadOnly();

    private CashRegister() { }

    public CashRegister(DateTimeOffset date, decimal openingBalance)
    {
        Id = Guid.NewGuid();
        Date = date.Date;
        OpeningBalance = Money.FromDecimal(openingBalance);
        CurrentBalance = OpeningBalance;
        TotalCredits = Money.FromDecimal(0);
        TotalDebits = Money.FromDecimal(0);
    }

    public void AddTransaction(TransactionEntity transaction)
    {
        if (transaction.Date.Date != Date.Date)
        {
            throw new InvalidOperationException("The transaction must have the same date as the cash record.");
        }
        _transactions.Add(transaction);

        if (transaction.Type == ETransactionType.Credit)
        {
            TotalCredits += transaction.Amount;
            CurrentBalance += transaction.Amount;
        }
        else
        {
            TotalDebits += transaction.Amount;
            CurrentBalance -= transaction.Amount;
        }
    }

    public void RemoveTransaction(TransactionEntity transaction)
    {
        if (!Transactions.Contains(transaction))
            return;

        _transactions.Remove(transaction);

        if (transaction.Type == ETransactionType.Credit)
        {
            TotalCredits -= transaction.Amount;
            CurrentBalance -= transaction.Amount;
        }
        else
        {
            TotalDebits -= transaction.Amount;
            CurrentBalance += transaction.Amount;
        }
    }

    public void Close()
    {
        // Lógica para fechamento do caixa
    }

    protected override void Validate()
    {
        var validationErros = new List<ValidationError>();

        if (OpeningBalance <= 0)
        {
            validationErros.Add(new ValidationError("OpeningBalance", "Opening balance is required"));
        }
        
        if (validationErros.Any())
        {
            throw new ValidationException(validationErros);
        }
    }
}