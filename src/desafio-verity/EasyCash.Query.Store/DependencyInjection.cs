using EasyCash.Dapper.Provider;
using EasyCash.Query.CashFlow.Interfaces;
using EasyCash.Query.Store.CashFlow;
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

        services.AddTransient<ITransactionQueryStore, TransactionQueryStore>();

        return services;
    }
}