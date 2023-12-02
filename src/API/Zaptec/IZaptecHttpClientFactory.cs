
namespace API.Zaptec;

public interface IZaptecHttpClientFactory
{
    Task<HttpClient> CreateAuthenticatedHttpClientAsync(CancellationToken cancellationToken);
}
