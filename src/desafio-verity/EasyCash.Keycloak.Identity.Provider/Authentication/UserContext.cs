using EasyCash.Domain.Abstractions.Authentication;
using EasyCash.Domain.Abstractions.Authorization;
using EasyCash.Domain.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;

namespace EasyCash.Keycloak.Identity.Provider.Authentication;

internal sealed class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuthorizationService _authorizationService;

    public UserContext(IHttpContextAccessor httpContextAccessor
        , IAuthorizationService authorizationService)
    {
        _httpContextAccessor = httpContextAccessor;
        _authorizationService = authorizationService;
    }

    public bool UserIdLoggedIn =>
        ((System.Security.Claims.ClaimsIdentity)(_httpContextAccessor.HttpContext?.User).Identity).IsAuthenticated;

    public Guid UserId =>
        _httpContextAccessor
            .HttpContext?
            .User
            .GetUserId() ??
        throw new BusinessException(new Error("UserPreferences.InvalidId", "Invalid user id"));

    public string IdentityId =>
        _httpContextAccessor
            .HttpContext?
            .User
            .GetIdentityId() ??
        throw new BusinessException(new Error("UserPreferences.InvalidId", "Invalid user"));

    public bool IsUserAdmin()
    {
        var user = _httpContextAccessor
            .HttpContext
            .User;

        if (user?.Identity?.IsAuthenticated != true)
            return false;

        var permissions = _authorizationService.GetPermissionsForUserAsync(IdentityId).GetAwaiter().GetResult();

        return permissions.Contains("admin") || user.IsInRole("admin") || user.HasClaim(c => c.Type == "role" && c.Value == "admin");
    }
}
