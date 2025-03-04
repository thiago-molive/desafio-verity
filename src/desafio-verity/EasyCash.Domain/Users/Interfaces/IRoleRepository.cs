using EasyCash.Domain.Abstractions.Repository;
using EasyCash.Domain.Users.Entities;

namespace EasyCash.Domain.Users.Interfaces;

public interface IRoleRepository : IRepository<RoleEntity, Guid>
{
    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken);

    Task<bool> HasUsersInRole(Guid roleId, CancellationToken cancellationToken);
}