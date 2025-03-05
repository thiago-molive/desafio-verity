using EasyCash.Domain.Abstractions;

namespace EasyCash.Domain.Users.Entities;

public sealed class RoleEntity : EntityBase<Guid>
{
    public static readonly RoleEntity Collaborator = new(Guid.Parse("b8b1e85b-4492-4a33-b09b-dca91c067f49"), "Collaborator");
    public static readonly RoleEntity Admin = new(Guid.Parse("ca9ed27c-c409-486f-a89f-31b8b37b1e56"), "Admin");

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public ICollection<UserEntity> Users { get; init; } = new List<UserEntity>();

    public ICollection<PermissionEntity> Permissions { get; init; } = new List<PermissionEntity>();

    private RoleEntity() { }

    public RoleEntity(Guid id, string name, string description = "", bool isActive = true)
    {
        Id = id;
        Name = name;
        Description = description;
        IsActive = isActive;
    }

    public static RoleEntity Create(string name, string description)
    {
        var role = new RoleEntity(Guid.NewGuid(), name, description, false);

        role.Validate();

        return role;
    }

    protected override void Validate()
    {

    }
}
