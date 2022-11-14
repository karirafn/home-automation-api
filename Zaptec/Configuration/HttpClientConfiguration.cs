using Microsoft.Extensions.DependencyInjection;

namespace Zaptec.Configuration;

internal static class HttpClientConfiguration
{
    internal static IServiceCollection AddZaptecHttpClient(this IServiceCollection services) => services
        .AddHttpClient(nameof(Zaptec), options =>
        {
            options.BaseAddress = new Uri("https://api.zaptec.com/");
        }).Services;
}
