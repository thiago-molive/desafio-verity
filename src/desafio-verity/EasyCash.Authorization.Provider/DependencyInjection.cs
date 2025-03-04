using EasyCash.Authorization.Provider.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCash.Authorization.Provider;

public static class DependencyInjection
{
    public static void AddInfrastructureAuthorization(this IServiceCollection services)
    {
        services.AddScoped<Domain.Abstractions.Authorization.IAuthorizationService, AuthorizationService>();

        services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();

        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
    }
}
