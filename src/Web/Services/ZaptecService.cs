using SharedKernel.DTO;

namespace Web.Services;

internal sealed class ZaptecService : IZaptecService
{
    private readonly HttpClient _httpClient;

    public ZaptecService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<IReadOnlyCollection<ChargeCostSummary>> GetChargeHistoryCostSumamryAsync(string groupyby)
        => await _httpClient.GetFromJsonAsync<IReadOnlyCollection<ChargeCostSummary>>($"api/zaptec/chargers/history/cost/summary?groupby={groupyby}") ?? [];
}
