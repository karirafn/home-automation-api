namespace SharedKernel.DTO;

public sealed record class GetChargeHistoryResponse(int Pages, IReadOnlyCollection<ChargeData> Data);
