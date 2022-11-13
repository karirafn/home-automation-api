using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Configuration;

public static class ControllerConfiguration
{
    public static IServiceCollection AddController<TController>(this IServiceCollection services)
        where TController : ControllerBase => services
        .AddControllers()
        .AddApplicationPart(typeof(TController).Assembly)
        .Services;
}
