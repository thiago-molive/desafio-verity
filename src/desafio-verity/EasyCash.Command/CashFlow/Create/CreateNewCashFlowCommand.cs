using EasyCash.Domain.Abstractions.Messaging.Commands;

namespace EasyCash.Command.CashFlow.Create;

public sealed class CreateNewCashFlowCommand : ICommand<CreateNewCashFlowCommandResult>
{

}

public sealed class CreateNewCashFlowCommandResult : ICommandResult
{
}