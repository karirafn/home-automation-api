using API.SharedKernel;
using API.Zaptec.Features.GetChargeHistory;

using Microsoft.Extensions.Options;

using SharedKernel.DTO;

namespace API.Zaptec.Features.GetCost;

internal sealed class GetChargeHistoryCostHandler
{
    private readonly GetChargeHistoryHandler _getChargeHistoryHandler;
    private readonly IOptions<RateOptions> _options;

    public GetChargeHistoryCostHandler(GetChargeHistoryHandler getChargeHistoryHandler, IOptions<RateOptions> options)
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
            Cost: x.Energy * _options.Value.Electricity));
    }
}
