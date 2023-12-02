namespace API.SharedKernel.Configuration;

internal static class DependencyInjection
{
    public static IServiceCollection AddSharedKernel(this IServiceCollection services)
    {
        services.AddOptions<ElectricityRateOptions>()
            .Configure<IConfiguration>((settings, configuration)
                => configuration.GetSection(ElectricityRateOptions.SectionName).Bind(settings));

        return services;
    }
}
