using EasyCash.Command.Store.Contexts;
using EasyCash.Domain.Users.Entities;
using EasyCash.Domain.Users.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.Command.Store.Repositories.Users;

internal sealed class RoleRepository : Repository<RoleEntity, Guid>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public new async Task<RoleEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<RoleEntity>()
            .Include(x => x.Permissions)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<RoleEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<RoleEntity>()
            .ToListAsync(cancellationToken);
    }

    public void Delete(RoleEntity entity)
    {
        DbContext
            .Set<RoleEntity>()
            .Remove(entity);
    }

    public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<RoleEntity>()
            .AnyAsync(x => x.Name == name, cancellationToken);
    }

    public async Task<bool> HasUsersInRole(Guid roleId, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<RoleEntity>()
            .Where(x => x.Id == roleId)
            .Include(x => x.Users)
            .Where(x => x.Users.Any())
            .AnyAsync(cancellationToken);
    }

    public void Update(RoleEntity entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
    }
}
