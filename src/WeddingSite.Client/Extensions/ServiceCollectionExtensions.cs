using WeddingSite.Client.Services.Abstractions;
using WeddingSite.Client.Services;

namespace WeddingSite.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeddingSiteServices(this IServiceCollection services)
    {
        services.AddTransient<IDataService, DataService>();

        return services;
    }
}
