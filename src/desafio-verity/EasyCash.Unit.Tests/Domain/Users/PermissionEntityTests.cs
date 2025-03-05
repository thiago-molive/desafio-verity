using EasyCash.Domain.Users.Entities;
using EasyCash.Domain.Users.Enums;
using FluentAssertions;

namespace EasyCash.Unit.Tests.Domain.Users;

public sealed class PermissionEntityTests
{
    [Fact]
    public void CollaboratorsAll_ShouldHave_CorrectValues()
    {
        // Arrange & Act
        var permission = PermissionEntity.CollaboratorsAll;

        // Assert
        permission.Id.Should().Be(Guid.Parse("a08dab99-40a0-41ab-b5e5-ba8b727f8f3a"));
        permission.Name.Should().Be("Gereric permission");
        permission.Module.Should().Be(EModules.Collaborator);
        permission.Action.Should().Be(EActions.All);
        permission.Description.Should().Be("Generic permission");
        permission.Permission.Should().Be("collaborator:all");
    }

    [Fact]
    public void Admin_ShouldHave_CorrectValues()
    {
        // Arrange & Act
        var permission = PermissionEntity.Admin;

        // Assert
        permission.Id.Should().Be(Guid.Parse("71901f50-380f-40c5-80ef-292eba6bf82b"));
        permission.Name.Should().Be("Admin permission");
        permission.Module.Should().Be(EModules.Admin);
        permission.Action.Should().Be(EActions.All);
        permission.Description.Should().Be("Admin permission");
        permission.Permission.Should().Be("admin:all");
    }

    [Fact]
    public void Permission_ShouldReturn_CorrectFormat()
    {
        // Arrange
        var permission = PermissionEntity.CollaboratorsAll;

        // Act
        var result = permission.Permission;

        // Assert
        result.Should().Be("collaborator:all");
    }

    [Fact]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var name = "Test Permission";
        var module = EModules.Collaborator;
        var action = EActions.Read;
        var description = "Test Description";

        // Act
        var permission = PermissionEntity.Create(name, module, action, description);

        // Assert
        permission.Id.Should().NotBeEmpty();
        permission.Name.Should().Be(name);
        permission.Module.Should().Be(module);
        permission.Action.Should().Be(action);
        permission.Description.Should().Be(description);
        permission.Permission.Should().Be("collaborator:read");
    }
}