using API.Zaptec.Features.GetChargers;

namespace API.Zaptec.Features.GetChargerById;

internal sealed class GetChargerByIdHandler
{
    private readonly ILogger<GetChargersHandler> _logger;
    private readonly IZaptecHttpClientFactory _zaptecHttpClientFactory;

    public GetChargerByIdHandler(ILogger<GetChargersHandler> logger, IZaptecHttpClientFactory zaptecHttpClientFactory)
    {
        _logger = logger;
        _zaptecHttpClientFactory = zaptecHttpClientFactory;
    }

    public async Task<GetChargerByIdResponse?> HandleAsync(Guid id, CancellationToken cancellationToken)
    {
        HttpClient httpClient = await _zaptecHttpClientFactory.CreateAuthenticatedHttpClientAsync(cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation("Getting Zaptec charger {Id}", id);
        GetChargerByIdResponse? response = await httpClient
            .GetFromJsonAsync<GetChargerByIdResponse>($"api/chargers/{id}", cancellationToken)
            .ConfigureAwait(false);

        if (response is null)
        {
            _logger.LogError("Zaptec charger {Id} was not found", id);
        }

        return response;
    }
}
