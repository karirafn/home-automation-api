using SharedKernel.DTO;

namespace API.Zaptec.Features.GetChargers;

internal sealed class GetChargersHandler
{
    private readonly ILogger<GetChargersHandler> _logger;
    private readonly IZaptecHttpClientFactory _zaptecHttpClientFactory;

    public GetChargersHandler(ILogger<GetChargersHandler> logger, IZaptecHttpClientFactory zaptecHttpClientFactory)
    {
        _logger = logger;
        _zaptecHttpClientFactory = zaptecHttpClientFactory;
    }

    public async Task<GetChargersResponse> HandleAsync(CancellationToken cancellationToken)
    {
        HttpClient httpClient = await _zaptecHttpClientFactory.CreateAuthenticatedHttpClientAsync(cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation("Getting chargers from Zaptec");
        GetChargersResponse? response = await httpClient
            .GetFromJsonAsync<GetChargersResponse>("api/chargers", cancellationToken)
            .ConfigureAwait(false);

        if (response is null)
        {
            _logger.LogError("Failed to get Zaptec chargers");
            return new(default, []);
        }

        return response;
    }
}
