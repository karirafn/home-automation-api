namespace API.Zaptec.Features.GetChargeHistory;

public sealed record class ChargeDatum(DateTime Timestamp, int Energy);
