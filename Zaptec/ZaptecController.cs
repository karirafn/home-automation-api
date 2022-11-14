using MediatR;

using Microsoft.AspNetCore.Mvc;

using Zaptec.Features.GetChargeHistory;
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

        return response.AccessToken is not null ? Ok(response) : BadRequest(request);
    }

    [HttpPost]
    public async Task<IActionResult> GetChargeHistory(GetChargeHistoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return response is not null ? Ok(response) : BadRequest(request);
    }
}
