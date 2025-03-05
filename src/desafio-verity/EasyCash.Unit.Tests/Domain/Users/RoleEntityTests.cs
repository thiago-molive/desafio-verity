using EasyCash.Domain.Users.Entities;
using FluentAssertions;

namespace EasyCash.Unit.Tests.Domain.Users;

public sealed class RoleEntityTests
{
    [Fact]
    public void Create_ShouldReturnInactiveRoleEntity()
    {
        // Arrange
        var name = "TestRole";
        var description = "TestDescription";

        // Act
        var role = RoleEntity.Create(name, description);

        // Assert
        role.Should().NotBeNull();
        role.Name.Should().Be(name);
        role.Description.Should().Be(description);
        role.IsActive.Should().BeFalse();
    }

    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "TestRole";
        var description = "TestDescription";
        var isActive = true;

        // Act
        var role = new RoleEntity(id, name, description, isActive);

        // Assert
        role.Id.Should().Be(id);
        role.Name.Should().Be(name);
        role.Description.Should().Be(description);
        role.IsActive.Should().Be(isActive);
    }

    [Fact]
    public void Collaborator_ShouldReturnPredefinedRole()
    {
        // Act
        var role = RoleEntity.Collaborator;

        // Assert
        role.Should().NotBeNull();
        role.Name.Should().Be("Collaborator");
        role.Id.Should().Be(Guid.Parse("b8b1e85b-4492-4a33-b09b-dca91c067f49"));
    }

    [Fact]
    public void Admin_ShouldReturnPredefinedRole()
    {
        // Act
        var role = RoleEntity.Admin;

        // Assert
        role.Should().NotBeNull();
        role.Name.Should().Be("Admin");
        role.Id.Should().Be(Guid.Parse("ca9ed27c-c409-486f-a89f-31b8b37b1e56"));
    }
}

