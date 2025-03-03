using EasyCash.Domain.Abstractions;

namespace EasyCash.Domain.Interfaces;

public interface IIntegrationEventSender<TEvent> where TEvent : IntegrationEventBase
{
    
}