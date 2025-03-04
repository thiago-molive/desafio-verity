using EasyCash.Command.Store.Constants;
using EasyCash.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyCash.Command.Store.EntityConfigurations.Users;

internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable(TableNames.RolePermissions);

        builder.HasKey(rolePermission => new { rolePermission.RoleId, rolePermission.PermissionId });

        builder.Property(x => x.PermissionId)
            .HasColumnName("permission_id")
            .IsRequired();

        builder.Property(x => x.RoleId)
            .HasColumnName("role_id")
            .IsRequired();

        builder.HasIndex(x => new { x.PermissionId, x.RoleId })
            .IsUnique();

        builder.HasData(
            new RolePermission
            {
                RoleId = RoleEntity.Collaborator.Id,
                PermissionId = PermissionEntity.CollaboratorsAll.Id
            });

        builder.HasData(
            new RolePermission
            {
                RoleId = RoleEntity.Admin.Id,
                PermissionId = PermissionEntity.Admin.Id
            });

        builder.HasData(
            new RolePermission
            {
                RoleId = RoleEntity.Admin.Id,
                PermissionId = PermissionEntity.CollaboratorsAll.Id
            });
    }
}
