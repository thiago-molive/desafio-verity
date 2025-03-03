using EasyCash.Domain.Abstractions.Messaging.Commands;

namespace EasyCash.Command.CashFlow.Create;

internal sealed class CreateNewCashFlowCommandHandler : ICommandHandler<CreateNewCashFlowCommand, CreateNewCashFlowCommandResult>
{
    public Task<CreateNewCashFlowCommandResult> Handle(CreateNewCashFlowCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

