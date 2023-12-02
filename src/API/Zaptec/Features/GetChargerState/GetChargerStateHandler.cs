using API.Zaptec.Features.GetChargers;

namespace API.Zaptec.Features.GetChargerState;

internal sealed class GetChargerStateHandler
{

    private readonly ILogger<GetChargersHandler> _logger;
    private readonly IZaptecHttpClientFactory _zaptecHttpClientFactory;

    public GetChargerStateHandler(ILogger<GetChargersHandler> logger, IZaptecHttpClientFactory zaptecHttpClientFactory)
    {
        _logger = logger;
        _zaptecHttpClientFactory = zaptecHttpClientFactory;
    }

    public async Task<IReadOnlyCollection<ChargerState>> HandleAsync(Guid id, CancellationToken cancellationToken)
    {
        HttpClient httpClient = await _zaptecHttpClientFactory.CreateAuthenticatedHttpClientAsync(cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation("Getting Zaptec charger states");
        IReadOnlyCollection<ChargerState>? response = await httpClient
            .GetFromJsonAsync<IReadOnlyCollection<ChargerState>>($"api/chargers/{id}/state", cancellationToken)
            .ConfigureAwait(false);

        if (response is null)
        {
            _logger.LogError("Failed to get Zaptec charger states");
            return [];
        }

        return response;
    }
}
