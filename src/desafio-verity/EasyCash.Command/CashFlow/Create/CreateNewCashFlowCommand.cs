using EasyCash.Domain.Abstractions.Messaging.Commands;

namespace EasyCash.Command.CashFlow.Create;

public sealed class CreateNewCashFlowCommand : IIdempotencyCommand<CreateNewCashFlowCommandResult>
{
    public string IdempotencyKey  { get; set; }
}

public sealed class CreateNewCashFlowCommandResult : ICommandResult
{
}