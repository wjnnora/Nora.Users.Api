using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nora.Users.Domain.Command.Commands.v1.Users.Create;
using Nora.Users.Domain.Query.Queries.v1.Users.GetById;

namespace Nora.Users.Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public sealed class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command)
    {
        await mediator.Send(command);        

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var response = await mediator.Send(new GetUserByIdQuery(id));

        return Ok(response);
    }
}