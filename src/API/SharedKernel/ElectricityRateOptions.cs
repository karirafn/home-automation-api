namespace API.SharedKernel;

internal sealed class ElectricityRateOptions
{
    public const string SectionName = "ElectricityRates";

    public double Usage { get; init; }
    public double Distribution { get; init; }
    public double Transport { get; init; }

    public double Total => Usage + Distribution + Transport;
}
