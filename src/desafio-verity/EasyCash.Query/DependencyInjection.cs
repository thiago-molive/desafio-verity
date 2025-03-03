﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCash.Query;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationQuery(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        return services;
    }
}

