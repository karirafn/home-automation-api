using Microsoft.AspNetCore.Mvc;

namespace Zaptec;

[ApiController]
[Route("api/[controller]")]
public class ZaptecController : ControllerBase
{
    private readonly HttpClient _http;

    public ZaptecController(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(nameof(Zaptec));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetChargeHistory(Guid id)
    {
        throw new NotImplementedException();
    }
}
