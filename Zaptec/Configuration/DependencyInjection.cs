using Microsoft.Extensions.DependencyInjection;

namespace Zaptec.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddZaptec(this IServiceCollection services) => services
        .AddZaptecHttpClient()
        .AddZaptecController();
}
