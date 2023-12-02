namespace API.SharedKernel.Configuration;

internal static class DependencyInjection
{
    public static IServiceCollection AddSharedKernel(this IServiceCollection services)
    {
        services.AddOptions<RateOptions>()
            .Configure<IConfiguration>((settings, configuration)
                => configuration.GetSection(RateOptions.SectionName).Bind(settings));

        return services;
    }
}
