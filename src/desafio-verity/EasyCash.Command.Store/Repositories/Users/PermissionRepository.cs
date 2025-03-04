using EasyCash.Command.Store.Contexts;
using EasyCash.Domain.Users.Entities;
using EasyCash.Domain.Users.Enums;
using EasyCash.Domain.Users.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.Command.Store.Repositories.Users;

internal sealed class PermissionRepository : Repository<PermissionEntity, Guid>, IPermissionRepository
{
    public PermissionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<PermissionEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<PermissionEntity>()
            .ToListAsync(cancellationToken);
    }

    public void Delete(PermissionEntity entity)
    {
        DbContext
            .Set<PermissionEntity>()
            .Remove(entity);
    }

    public async Task<bool> ExistsAsync(EModules module, EActions action, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<PermissionEntity>()
            .AnyAsync(x => x.Module == module && x.Action == action, cancellationToken);
    }

    public Task<bool> IsUsingPermission(Guid permissionId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<RolePermission>()
            .AnyAsync(x => x.PermissionId == permissionId, cancellationToken);
    }

    public async Task<PermissionEntity[]> GetPermissionsAsync(List<Guid> permissionsId, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<PermissionEntity>()
            .Where(x => permissionsId.Contains(x.Id))
            .ToArrayAsync(cancellationToken);
    }

    public void Update(PermissionEntity entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
    }
}