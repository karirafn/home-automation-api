using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace API.Zaptec.Features.Login;

internal sealed class ZaptecLoginHandler
{
    private readonly ILogger<ZaptecLoginHandler> _logger;
    private readonly IOptions<ZaptecOptions> _options;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _cache;

    public ZaptecLoginHandler(
        ILogger<ZaptecLoginHandler> logger,
        IOptions<ZaptecOptions> options,
        IHttpClientFactory httpClientFactory,
        IMemoryCache cache)
    {
        _logger = logger;
        _options = options;
        _httpClientFactory = httpClientFactory;
        _cache = cache;
    }

    public async Task<ZaptecLoginResponse?> HandleAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Logging into Zaptec API");

        DateTimeOffset now = DateTimeOffset.UtcNow;

        Dictionary<string, string> parameters = new()
        {
            ["grant_type"] = "password",
            ["username"] = $"{_options.Value.Username}",
            ["password"] = $"{_options.Value.Password}",
        };

        FormUrlEncodedContent form = new(parameters);

        HttpClient httpClient = _httpClientFactory.CreateClient(ZaptecOptions.Zaptec);
        HttpResponseMessage response = await httpClient
            .PostAsync("oauth/token", form, cancellationToken)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Failed to log into Zaptec API");
            return null;
        }

        _logger.LogInformation("Deserializing Zaptec login response");
        ZaptecLoginResponse? token = await response.Content
            .ReadFromJsonAsync<ZaptecLoginResponse>(cancellationToken)
            .ConfigureAwait(false);

        if (token is null)
        {
            _logger.LogError("Failed to deserialize Zaptec login response");
            return null;
        }

        DateTimeOffset expiration = now.AddSeconds(token.ExpiresIn);

        _logger.LogInformation("Token expires on {Timestamp}", expiration);
        _cache.GetOrCreate(ZaptecOptions.AccessTokenCacheKey, entry =>
        {
            entry.AbsoluteExpiration = expiration;
            return token;
        });

        return token;
    }
}
