using Asp.Versioning;
using EasyCash.Api.Middleware;
using EasyCash.Command.CashFlow.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace EasyCash.Api.Controllers;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Produces("application/json")]
[Description("Cash flow controller")]
[ApiExplorerSettings(GroupName = "CashFlow")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CashFlowsController : ControllerBase
{

    private readonly ISender _sender;

    public CashFlowsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    // [HasPermission(PermissionsConsts.Admin)]
    [ProducesResponseType(typeof(CreateTransactionCommandResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionHandlingMiddleware.ExceptionDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionHandlingMiddleware.ExceptionDetails), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> AddCategory([FromBody] CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return Ok(result);
    }
}
