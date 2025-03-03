using EasyCash.Dapper.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCash.Query.Store;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureQueryStore(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructureDapperProvider(configuration);

        return services;
    }
}