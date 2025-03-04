using EasyCash.Domain.Abstractions;
using EasyCash.Domain.Users.ValueObjets;

namespace EasyCash.Domain.Users.Entities;

public sealed class UserEntity : EntityBase<Guid>
{
    public static readonly UserEntity InitialTestUser = UserEntity.Create(new FirstName("Test"), new LastName("User"), Email.Instance("test@easycash.com.br"));

    private readonly List<RoleEntity> _roles = new();

    private UserEntity() { }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    public IReadOnlyCollection<RoleEntity> Roles => _roles.AsReadOnly();

    private UserEntity(Guid id, FirstName firstName, LastName lastName, Email email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public static UserEntity Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new UserEntity(Guid.NewGuid(), firstName, lastName, email);

        user._roles.Add(RoleEntity.Collaborator);

        return user;
    }

    public void SetIdentityId(string identityId) =>
        IdentityId = identityId;

    protected override void Validate()
    {

    }
}
