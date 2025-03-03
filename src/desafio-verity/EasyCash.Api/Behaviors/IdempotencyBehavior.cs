using EasyCash.Domain.Abstractions.Messaging.Commands;
using EasyCash.Domain.Idempotency.Entity;
using EasyCash.Domain.Idempotency.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace EasyCash.Api.Behaviors;

internal sealed class IdempotencyBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IIdempotencyCommand<TResponse>
    where TResponse : ICommandResult
{
    private readonly IIdempotencyCommandStore _idempotencyCommandStore;

    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All,
        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
    };

    public IdempotencyBehavior(IIdempotencyCommandStore idempotencyCommandStore)
    {
        _idempotencyCommandStore = idempotencyCommandStore;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.IdempotencyKey))
            return await next();

        var idempotencyEntity = await _idempotencyCommandStore.GetByIdAsync(request.IdempotencyKey, cancellationToken);

        if (idempotencyEntity is not null)
        {
            if (!string.IsNullOrWhiteSpace(idempotencyEntity.Response))
                return JsonConvert.DeserializeObject<TResponse>(idempotencyEntity.Response, JsonSerializerSettings)!;
        }
        else
        {
            idempotencyEntity = IdempotencyEntity.Create(request.IdempotencyKey, JsonConvert.SerializeObject(request, JsonSerializerSettings), null);
            await _idempotencyCommandStore.AddAsync(idempotencyEntity, cancellationToken);
        }

        var response = await next();

        idempotencyEntity.DefineResult(JsonConvert.SerializeObject(response, JsonSerializerSettings));

        _idempotencyCommandStore.MarkRequestAsProcessedAsync(idempotencyEntity);

        return response;
    }
}