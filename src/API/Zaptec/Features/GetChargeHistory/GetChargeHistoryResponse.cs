namespace API.Zaptec.Features.GetChargeHistory;

public sealed record GetChargeHistoryResponse(int Pages, IReadOnlyCollection<ChargeData> Data);
