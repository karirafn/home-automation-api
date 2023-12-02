namespace API.Zaptec.Features.GethargeHistoryCostSummary;

internal sealed record class ChargeCostSummary(string Period, double Energy, double Cost, int Sessions);
