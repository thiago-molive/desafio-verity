using System.Reflection;

namespace EasyCash.Api.Extensions;

public static class ConfigureMediatorExtension
{
    public static IServiceCollection AddCoreApplicationMessaging(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(assemblies);

            services.AddApplicationGenericBehaviors(configuration);
        });

        return services;
    }
}


public static class BehaviorExtensions
{
    public static IServiceCollection AddApplicationGenericBehaviors(this IServiceCollection services,
        MediatRServiceConfiguration configuration)
    {
        //configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

        //configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

        //configuration.AddOpenBehavior(typeof(IdempotencyBehavior<,>));

        //configuration.AddOpenBehavior(typeof(QueryCachingBehavior<,>));

        //configuration.AddOpenBehavior(typeof(TransactionalBehavior<,>));

        return services;
    }
}
