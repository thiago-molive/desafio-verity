using EasyCash.Domain.Abstractions.Messaging.Commands;
using FluentValidation;

namespace EasyCash.Command.CashFlow.Create;

internal sealed class CreateNewCashFlowCommandHandler : ICommandHandler<CreateNewCashFlowCommand, CreateNewCashFlowCommandResult>
{
    public Task<CreateNewCashFlowCommandResult> Handle(CreateNewCashFlowCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CreateNewCashFlowCommandResult());
    }
}

internal sealed class CreateNewCashFlowCommandValidator : AbstractValidator<CreateNewCashFlowCommand>
{
    public CreateNewCashFlowCommandValidator()
    {

    }
}