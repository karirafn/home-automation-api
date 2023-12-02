using API.Zaptec.Features.GetChargers;

using Microsoft.Extensions.Caching.Memory;

namespace API.Zaptec.Features.GetChargeHistory;

internal class GetChargeHistoryHandler
{
    private readonly ILogger<GetChargersHandler> _logger;
    private readonly IZaptecHttpClientFactory _zaptecHttpClientFactory;
    private readonly IMemoryCache _cache;

    public GetChargeHistoryHandler(ILogger<GetChargersHandler> logger, IZaptecHttpClientFactory zaptecHttpClientFactory, IMemoryCache cache)
    {
        _logger = logger;
        _zaptecHttpClientFactory = zaptecHttpClientFactory;
        _cache = cache;
    }

    public async Task<GetChargeHistoryResponse> HandleAsync(CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue(ZaptecOptions.ChargeHistoryCacheKey, out GetChargeHistoryResponse? response) && response is not null)
        {
            _logger.LogInformation("Found Zaptec charge history in cache");
            return response;
        }

        _logger.LogInformation("Zaptec charge history not found in cache");

        HttpClient httpClient = await _zaptecHttpClientFactory.CreateAuthenticatedHttpClientAsync(cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation("Getting Zaptec charge history from API");
        response = await httpClient
            .GetFromJsonAsync<GetChargeHistoryResponse>("api/chargehistory", cancellationToken)
            .ConfigureAwait(false);

        if (response is null)
        {
            _logger.LogError("Failed to get Zaptec charge history from API");
            return new(default, []);
        }

        _logger.LogInformation("Adding Zaptec charge history to cache");
        _cache.GetOrCreate(ZaptecOptions.ChargeHistoryCacheKey, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            return response;
        });

        return response;
    }
}
