using System.Net.Http.Json;
using System.Text;
using System.Web;

using MediatR;

namespace Zaptec.Features.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse?>
{
    private readonly HttpClient _http;

    public LoginHandler(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(nameof(Zaptec));
    }

    public async Task<LoginResponse?> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        string username = HttpUtility.UrlEncode(request.Username);
        string password = HttpUtility.UrlEncode(request.Password);

        StringContent content = new(
            $"grant_type=password&username={username}&password={password}",
            Encoding.UTF8,
            "application/x-www-form-urlencoded");

        HttpResponseMessage responseMessage = await _http.PostAsync("oauth/token", content, cancellationToken);
        LoginResponse? loginResponse = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken: cancellationToken);

        return loginResponse;
    }
}
