using Microsoft.AspNetCore.Authorization;

namespace EasyCash.Authorization.Provider.Authorization;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(permission)
    {
    }
}
