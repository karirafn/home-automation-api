using System.Net.Http.Json;
using System.Text;
using System.Web;

using Microsoft.AspNetCore.Mvc;

using Zaptec.Features.Login;

namespace Zaptec;

[ApiController]
[Route("api/[controller]")]
public class ZaptecController : ControllerBase
{
    private readonly HttpClient _http;
    private string _token = string.Empty;

    public ZaptecController(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(nameof(Zaptec));
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        string username = HttpUtility.UrlEncode(request.username);
        string password = HttpUtility.UrlEncode(request.password);
        StringContent content = new(
            $"grant_type=password&username={username}&password={password}",
            Encoding.UTF8,
            "application/x-www-form-urlencoded");
        HttpResponseMessage response = await _http.PostAsync("oauth/token", content);
        LoginResponse? result = await response.Content.ReadFromJsonAsync<LoginResponse>();

        if (result is null)
        {
            return BadRequest();
        }

        _token = result.access_token;

        return Ok(result);
    }
}
