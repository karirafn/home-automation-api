namespace API.Zaptec.Features.GetChargeHistory;

public sealed record class GetChargeHistoryResponse(int Pages, IReadOnlyCollection<ChargeData> Data);
