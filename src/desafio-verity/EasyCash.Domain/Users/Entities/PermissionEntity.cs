using EasyCash.Domain.Abstractions;
using EasyCash.Domain.Extensions;
using EasyCash.Domain.Users.Enums;

namespace EasyCash.Domain.Users.Entities;

public sealed class PermissionEntity : EntityBase<Guid>
{
    public static readonly PermissionEntity CollaboratorsAll = new(Guid.Parse("a08dab99-40a0-41ab-b5e5-ba8b727f8f3a"), "Gereric permission", EModules.Collaborator, EActions.All, "Generic permission");
    public static readonly PermissionEntity Admin = new(Guid.Parse("71901f50-380f-40c5-80ef-292eba6bf82b"), "Admin permission", EModules.Admin, EActions.All, "Admin permission");

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public EModules Module { get; set; }

    public EActions Action { get; set; }

    public string Permission => $"{Module.GetName()}:{Action.GetName()}";

    private PermissionEntity(Guid id, string name, EModules module, EActions action, string description = "")
    {
        Id = id;
        Name = name;
        Module = module;
        Action = action;
        Description = description;
    }

    public static PermissionEntity Create(string name, EModules module, EActions action, string description = "")
    {
        var permission = new PermissionEntity(Guid.NewGuid(), name, module, action, description);

        permission.Validate();

        return permission;
    }

    protected override void Validate()
    {

    }

    public void UpdateName(string name)
    {
        if (Name == name)
            return;

        Name = name;

        Validate();
    }

    public void UpdateDescription(string description)
    {
        if (Description == description)
            return;

        Description = description;

        Validate();
    }

    public void UpdateModule(EModules module)
    {
        if (Module == module)
            return;

        Module = module;

        Validate();
    }

    public void UpdateAction(EActions action)
    {
        if (Action == action)
            return;

        Action = action;

        Validate();
    }
}
