using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace Zaptec.Configuration;

internal static class HttpClientConfiguration
{
    internal static IServiceCollection AddZaptecHttpClient(this IServiceCollection services) => services
        .AddHttpClient(nameof(Zaptec), options =>
        {
            options.BaseAddress = new Uri("https://api.zaptec.com/");

            options.DefaultRequestHeaders.Accept.Clear();
            options.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }).Services;
}
