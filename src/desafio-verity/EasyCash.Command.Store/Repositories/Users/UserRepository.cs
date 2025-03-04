using EasyCash.Command.Store.Contexts;
using EasyCash.Domain.Users.Entities;
using EasyCash.Domain.Users.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.Command.Store.Repositories.Users;

internal sealed class UserRepository : Repository<UserEntity, Guid>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public new async Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<UserEntity>()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    public override async Task AddAsync(UserEntity user, CancellationToken cancellationToken = default)
    {
        foreach (RoleEntity role in user.Roles)
        {
            DbContext.Attach(role);
        }

        await DbContext.AddAsync(user, cancellationToken);
    }

    public void Update(UserEntity entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
    }
}
