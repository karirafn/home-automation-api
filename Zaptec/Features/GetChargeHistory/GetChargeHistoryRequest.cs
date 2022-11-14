using MediatR;

namespace Zaptec.Features.GetChargeHistory;
public record GetChargeHistoryRequest(
    Guid InstallationId,
    Guid UserId,
    Guid ChargerId,
    DateTime From,
    DateTime To,
    int GroupBy,
    int DetailLevel,
    string SortProperty,
    bool SortDescending,
    int PageSize,
    int PageIndex,
    bool IncludeDisabled,
    IEnumerable<string> Exclude) : IRequest<GetChargeHistoryResponse>;
