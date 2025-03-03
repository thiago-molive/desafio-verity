using MediatR;

namespace EasyCash.Domain.Abstractions.Messaging.Queries;

public interface IQueryHandler<in TQueryRequest, TQueryResponse> : IRequestHandler<TQueryRequest, TQueryResponse>
    where TQueryRequest : IQueryRequest<TQueryResponse>
    where TQueryResponse : class, new()
{
}