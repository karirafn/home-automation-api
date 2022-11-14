using MediatR;

namespace Zaptec.Features.GetChargeHistory;
public class GetChargeHistoryHandler : IRequestHandler<GetChargeHistoryRequest, GetChargeHistoryResponse>
{
    private readonly HttpClient _http;

    public GetChargeHistoryHandler(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(nameof(Zaptec));
    }

    public async Task<GetChargeHistoryResponse> Handle(GetChargeHistoryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
