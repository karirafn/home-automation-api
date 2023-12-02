using API.SharedKernel;
using API.Zaptec.Features.GetChargeHistory;

using Microsoft.Extensions.Options;

namespace API.Zaptec.Features.GetCost;

internal sealed class GetChargeHistoryCostHandler
{
    private readonly GetChargeHistoryHandler _getChargeHistoryHandler;
    private readonly IOptions<ElectricityRateOptions> _options;

    public GetChargeHistoryCostHandler(GetChargeHistoryHandler getChargeHistoryHandler, IOptions<ElectricityRateOptions> options)
    {
        _getChargeHistoryHandler = getChargeHistoryHandler;
        _options = options;
    }

    public async Task<IEnumerable<ChargeCost>> HandleAsync(CancellationToken cancellationToken)
    {
        GetChargeHistoryResponse response = await _getChargeHistoryHandler.HandleAsync(cancellationToken);

        return response.Data.Select(x => new ChargeCost(
            ChargeId: x.Id,
            Start: x.StartDateTime,
            End: x.EndDateTime,
            Energy: x.Energy,
            Cost: x.Energy * _options.Value.Total));
    }
}
