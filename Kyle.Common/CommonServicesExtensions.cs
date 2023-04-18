using Microsoft.Extensions.DependencyInjection;

namespace Kyle.Common;

public static class CommonServicesExtensions
{
    public static void AddCommon(this IServiceCollection services)
    {
        services.AddSingleton<ILongGenerator, LongGenerator>();
    }
}