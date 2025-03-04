using EasyCash.Domain.Abstractions.Repository;
using EasyCash.Domain.Users.Entities;
using EasyCash.Domain.Users.Enums;

namespace EasyCash.Domain.Users.Interfaces;

public interface IPermissionRepository : IRepository<PermissionEntity, Guid>
{
    Task<bool> ExistsAsync(EModules module, EActions action, CancellationToken cancellationToken);

    Task<bool> IsUsingPermission(Guid permissionId, CancellationToken cancellationToken);

    Task<PermissionEntity[]> GetPermissionsAsync(List<Guid> permissionsId, CancellationToken cancellationToken);
}