using MediatR;

namespace EasyCash.Domain.Abstractions.Messaging.Queries;

public interface IQueryRequest<TQueryResponse> : IRequest<TQueryResponse>
    where TQueryResponse : class, new()
{
}