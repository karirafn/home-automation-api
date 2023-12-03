namespace SharedKernel.DTO;

public sealed record class ChargeCost(Guid ChargeId, DateTime Start, DateTime End, double Energy, double Cost);
