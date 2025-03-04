namespace EasyCash.Domain.Abstractions.Authentication;

public interface IRegisterService<in TUser>
{
    Task<string> RegisterAsync(
        TUser user,
        string password,
        CancellationToken cancellationToken = default);
}