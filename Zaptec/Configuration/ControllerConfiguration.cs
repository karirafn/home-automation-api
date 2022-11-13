using Microsoft.Extensions.DependencyInjection;

namespace Zaptec.Configuration;

internal static class ControllerConfiguration
{
    internal static IServiceCollection AddZaptecController(this IServiceCollection services) => services
        .AddControllers()
        .AddApplicationPart(typeof(ZaptecController).Assembly)
        .Services;
}
