using SharedKernel.DTO;

namespace Web.ViewModels;

internal sealed class ChargeCostSummaryViewModel
{
    public ChargeCostSummaryViewModel(ChargeCostSummary summary)
    {
        Period = summary.Period;
        Energy = (int)Math.Round(summary.Energy, 0);
        Cost = (int)Math.Round(summary.Cost, 0);
    }

    public string Period { get; }
    public int Energy { get; set; }
    public int Cost { get; }
}
