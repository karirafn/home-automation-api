using API.Zaptec.Features.GetCost;

namespace API.Zaptec.Features.GethargeHistoryCostSummary;

internal sealed class GetChargeHistoryCostSummaryHandler
{
    private readonly GetChargeHistoryCostHandler _getChargeHistoryCostHandler;

    public GetChargeHistoryCostSummaryHandler(GetChargeHistoryCostHandler getChargeHistoryCostHandler) => _getChargeHistoryCostHandler = getChargeHistoryCostHandler;

    public async Task<IEnumerable<ChargeCostSummary>> HandleAsync(string groupby, CancellationToken cancellationToken = default)
    {
        IEnumerable<ChargeCost> history = await _getChargeHistoryCostHandler.HandleAsync(cancellationToken);

        var summaries = groupby switch
        {
            "year" => history.GroupBy(x => $"{x.End.Year}"),
            "quarter" => history.GroupBy(x => $"{x.End.Year}-Q{(x.End.Month - 1) / 3 + 1}"),
            "month" => history.GroupBy(x => $"{x.End.Year}-{x.End.Month:D2}"),
            "dayofweek" => history.GroupBy(x => $"{x.End.DayOfWeek}"),
            "hourofday" => history.GroupBy(x => $"{x.End.Hour}"),
            _ => []
        };

        IEnumerable<ChargeCostSummary> response = summaries
            .Select(group => new ChargeCostSummary(
                Period: group.Key,
                Energy: group.Sum(charge => charge.Energy),
                Cost: group.Sum(charge => charge.Cost),
                Sessions: group.Count()));

        return response;
    }
}
