namespace EasyCash.Domain.Users.Entities;

public sealed class RolePermission
{
    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }
}
