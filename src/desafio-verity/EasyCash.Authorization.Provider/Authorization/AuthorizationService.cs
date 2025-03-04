using EasyCash.Command.Store.Contexts;
using EasyCash.Domain.Abstractions.Authorization;
using EasyCash.Domain.Abstractions.Exceptions;
using EasyCash.Domain.Abstractions.Interfaces;
using EasyCash.Domain.Users.Entities;
using EasyCash.Domain.Users.Errors;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.Authorization.Provider.Authorization;

public sealed class AuthorizationService : IAuthorizationService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICacheService _cacheService;

    public AuthorizationService(ApplicationDbContext dbContext, ICacheService cacheService)
    {
        _dbContext = dbContext;
        _cacheService = cacheService;
    }

    public async Task<IUserRolesResponse> GetRolesForUserAsync(string identityId)
    {
        string cacheKey = $"auth:roles-{identityId}";
        UserRolesResponse? cachedRoles = await _cacheService.GetAsync<UserRolesResponse>(cacheKey);

        if (cachedRoles is not null)
        {
            return cachedRoles;
        }

        UserRolesResponse? roles = await _dbContext.Set<UserEntity>()
            .Where(u => u.IdentityId == identityId)
            .Select(u => new UserRolesResponse
            {
                UserId = u.Id,
                Roles = u.Roles.ToList()
            })
            .FirstOrDefaultAsync();

        if (roles is null)
            throw new BusinessException(UserErrors.NoRolesGivenToUser);

        await _cacheService.SetAsync(cacheKey, roles);

        return roles;
    }

    public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    {
        string cacheKey = $"auth:permissions-{identityId}";
        HashSet<string>? cachedPermissions = await _cacheService.GetAsync<HashSet<string>>(cacheKey);

        if (cachedPermissions is not null)
        {
            return cachedPermissions;
        }

        ICollection<PermissionEntity>? permissions = await _dbContext.Set<UserEntity>()
            .Where(u => u.IdentityId == identityId)
            .SelectMany(u => u.Roles.Select(r => r.Permissions))
            .FirstOrDefaultAsync();

        if (permissions is null)
            return [];

        var permissionsSet = permissions.Select(p => p.Permission).ToHashSet();

        await _cacheService.SetAsync(cacheKey, permissionsSet);

        return permissionsSet;
    }
}
