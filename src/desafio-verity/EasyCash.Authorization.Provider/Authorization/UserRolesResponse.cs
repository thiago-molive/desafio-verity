using EasyCash.Domain.Abstractions.Authorization;
using EasyCash.Domain.Users.Entities;

namespace EasyCash.Authorization.Provider.Authorization;

internal sealed class UserRolesResponse : IUserRolesResponse
{
    public Guid UserId { get; init; }

    public List<RoleEntity> Roles { get; init; } = new();
}
