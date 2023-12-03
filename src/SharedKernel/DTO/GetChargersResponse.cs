namespace SharedKernel.DTO;

public sealed record class GetChargersResponse(int Pages, IReadOnlyCollection<Charger> Data);
