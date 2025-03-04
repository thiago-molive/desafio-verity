namespace EasyCash.Domain.Abstractions.Authorization;

public interface IAuthorizationService
{
    Task<IUserRolesResponse> GetRolesForUserAsync(string identityId);

    Task<HashSet<string>> GetPermissionsForUserAsync(string identityId);
}