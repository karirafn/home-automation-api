using SharedKernel.DTO;

namespace Web.Services;

public interface IZaptecService
{
    Task<IReadOnlyCollection<ChargeCostSummary>> GetChargeHistoryCostSumamryAsync(string groupyby);
}
