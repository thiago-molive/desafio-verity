using EasyCash.Domain.Abstractions.Messaging.Events;

namespace EasyCash.Domain.Abstractions;

public abstract class DomainEventBase : IDomainEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}