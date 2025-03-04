using EasyCash.Command.Store.Constants;
using EasyCash.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyCash.Command.Store.EntityConfigurations.Users;

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntity>
{
    public void Configure(EntityTypeBuilder<PermissionEntity> builder)
    {
        builder.ToTable(TableNames.Permissions);

        builder.HasKey(permission => permission.Id);

        builder.Property(permission => permission.Name)
            .HasMaxLength(200)
            .IsRequired()
            .HasComment("Name of the permission.");

        builder.Property(permission => permission.Description)
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment("Description of the permission.");

        builder.Property(permission => permission.Module)
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Module of the permission.");

        builder.Property(permission => permission.Action)
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Action of the permission.");

        builder.Ignore(permission => permission.Permission);

        builder.HasIndex(permission => new { permission.Module, permission.Action })
            .IsUnique();

        builder.HasData(PermissionEntity.CollaboratorsAll);
        builder.HasData(PermissionEntity.Admin);
    }
}
