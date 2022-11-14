using MediatR;

using Microsoft.AspNetCore.Mvc;

using Zaptec.Features.Login;

namespace Zaptec;

[ApiController]
[Route("api/[controller]")]
public class ZaptecController : ControllerBase
{
    private readonly IMediator _mediator;

    public ZaptecController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return response.AccessToken is not null ? Ok(response) : BadRequest();
    }
}
