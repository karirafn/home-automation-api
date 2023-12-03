namespace API.Zaptec.Features.GetChargers;

public sealed record class GetChargersResponse(int Pages, IReadOnlyCollection<Charger> Data);
