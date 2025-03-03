namespace EasyCash.Domain.Abstractions.Messaging.Commands;

public interface IIdempotencyCommand<TCommandResult> : ICommand<TCommandResult>, IIdempotency
    where TCommandResult : ICommandResult
{
}

public interface IIdempotency
{
    public string IdempotencyKey { get; set; }
}