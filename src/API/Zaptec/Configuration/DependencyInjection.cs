using API.Zaptec.Features.GetChargeHistory;
using API.Zaptec.Features.GetChargerById;
using API.Zaptec.Features.GetChargers;
using API.Zaptec.Features.GetChargerState;
using API.Zaptec.Features.GetCost;
using API.Zaptec.Features.GethargeHistoryCostSummary;
using API.Zaptec.Features.Login;

using Microsoft.Extensions.Options;

namespace API.Zaptec.Configuration;

internal static class DependencyInjection
{
    public static IServiceCollection AddZaptec(this IServiceCollection services)
    {
        services.AddOptions<ZaptecOptions>()
            .Configure<IConfiguration>((settings, configuration)
                => configuration.GetSection(ZaptecOptions.Zaptec).Bind(settings));

        services.AddHttpClient(ZaptecOptions.Zaptec, (services, client) =>
        {
            ZaptecOptions options = services.GetRequiredService<IOptions<ZaptecOptions>>().Value;

            client.BaseAddress = new(options.ApiRoot);
        });

        services.AddTransient<IZaptecHttpClientFactory, ZaptecHttpClientFactory>();
        services.AddTransient<ZaptecLoginHandler>();
        services.AddTransient<GetChargersHandler>();
        services.AddTransient<GetChargerByIdHandler>();
        services.AddTransient<GetChargerStateHandler>();
        services.AddTransient<GetChargeHistoryHandler>();
        services.AddTransient<GetChargeHistoryCostHandler>();
        services.AddTransient<GetChargeHistoryCostSummaryHandler>();

        return services;
    }
}
