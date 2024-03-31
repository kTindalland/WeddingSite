using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;
using WeddingSite.Application.Services.Implementations;
using WeddingSite.Application.Services.Interfaces;

namespace WeddingSite.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddConvey()
            .AddQueryHandlers()
            .AddCommandHandlers()
            .AddInMemoryQueryDispatcher()
            .AddInMemoryCommandDispatcher();

        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IMealService, MealService>();

        return services;
    }
}