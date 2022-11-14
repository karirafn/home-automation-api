using Zaptec.Models;

namespace Zaptec.Features.GetChargeHistory;
public record GetChargeHistoryResponse(int Pages, IEnumerable<ChargeData> Data, string Message);
