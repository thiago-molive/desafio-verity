using EasyCash.Domain.Abstractions.Interfaces;
using System.Data;

namespace EasyCash.Api.Extensions;

internal static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ISqlConnectionFactory sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using IDbConnection connection = sqlConnectionFactory.CreateConnection();


    }
}
