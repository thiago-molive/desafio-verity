using EasyCash.Domain.Abstractions.Authentication;
using EasyCash.Domain.Abstractions.Messaging.Commands;

namespace EasyCash.Command.Users.Login;

internal sealed class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, AccessTokenCommandResult>
{
    private readonly ILoginService _loginService;

    public LogInUserCommandHandler(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async Task<AccessTokenCommandResult> Handle(
        LogInUserCommand request,
        CancellationToken cancellationToken)
    {
        string result = await _loginService.LoginAsync(
            request.Email,
            request.Password,
            cancellationToken);

        return new AccessTokenCommandResult(result);
    }
}
