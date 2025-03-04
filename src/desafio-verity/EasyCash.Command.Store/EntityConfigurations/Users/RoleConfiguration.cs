using EasyCash.Command.Store.Constants;
using EasyCash.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyCash.Command.Store.EntityConfigurations.Users;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable(TableNames.Roles);

        builder.HasKey(role => role.Id);

        builder.Property(role => role.Name)
            .HasMaxLength(200)
            .IsRequired()
            .HasComment("Name of the role.");

        builder.Property(role => role.Description)
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment("Description of the role.");

        builder.HasMany(role => role.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>(
                j => j
                    .HasOne<PermissionEntity>()
                    .WithMany()
                    .HasForeignKey(rp => rp.PermissionId),
                j => j
                    .HasOne<RoleEntity>()
                    .WithMany()
                    .HasForeignKey(rp => rp.RoleId)
            );

        builder.HasIndex(role => role.Name)
            .IsUnique();

        builder.HasData(RoleEntity.Collaborator);
        builder.HasData(RoleEntity.Admin);
    }
}
