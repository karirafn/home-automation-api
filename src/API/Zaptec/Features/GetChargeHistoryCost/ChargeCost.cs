namespace API.Zaptec.Features.GetCost;

public sealed record class ChargeCost(Guid ChargeId, DateTime Start, DateTime End, double Energy, double Cost);
