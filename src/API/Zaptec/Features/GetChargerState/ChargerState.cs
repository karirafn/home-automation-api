namespace API.Zaptec.Features.GetChargerState;

public sealed record class ChargerState(Guid? ChargerId, int? StateId, string? StateName, DateTime? Timestamp, string? ValueAsString);
