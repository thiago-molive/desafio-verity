﻿using EasyCash.Command.Store.Contexts;
using EasyCash.Command.Store.Repositories.Idempotency;
using EasyCash.Domain.Idempotency.Interfaces;
using EasyCash.Domain.Interfaces;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCash.Command.Store;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureCommandStore(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database") ??
                                  throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString)
                .UseExceptionProcessor()
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IIdempotencyCommandStore, IdempotencyCommandStore>();

        return services;
    }
}