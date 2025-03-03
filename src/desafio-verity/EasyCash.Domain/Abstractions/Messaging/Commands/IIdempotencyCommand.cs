using System.ComponentModel.DataAnnotations;

namespace EasyCash.Domain.Abstractions.Messaging.Commands;

public interface IIdempotencyCommand<out TCommandResult> : ICommand<TCommandResult>, IIdempotency
    where TCommandResult : ICommandResult
{
}

public interface IIdempotency
{
    [Required]
    public string IdempotencyKey { get; set; }
}