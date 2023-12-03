namespace API.Zaptec.Features.GethargeHistoryCostSummary;

public sealed record class ChargeCostSummary(string Period, double Energy, double Cost, int Sessions);
