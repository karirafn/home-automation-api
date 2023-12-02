using System.Net.Http.Headers;

using API.Zaptec.Features.Login;

using Microsoft.Extensions.Caching.Memory;

namespace API.Zaptec;

internal class ZaptecHttpClientFactory : IZaptecHttpClientFactory
{
    private readonly ZaptecLoginHandler _loginHandler;
    private readonly IMemoryCache _cache;
    private readonly IHttpClientFactory _httpClientFactory;

    public ZaptecHttpClientFactory(ZaptecLoginHandler loginHandler, IMemoryCache cache, IHttpClientFactory httpClientFactory)
    {
        _loginHandler = loginHandler;
        _cache = cache;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HttpClient> CreateAuthenticatedHttpClientAsync(CancellationToken cancellationToken)
    {
        if (!_cache.TryGetValue(ZaptecOptions.AccessTokenCacheKey, out ZaptecLoginResponse? token))
        {
            token = await _loginHandler.HandleAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        ArgumentNullException.ThrowIfNull(token, nameof(ZaptecLoginResponse));

        HttpClient httpClient = _httpClientFactory.CreateClient(ZaptecOptions.Zaptec);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

        return httpClient;
    }
}
