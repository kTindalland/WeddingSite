﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using WeddingSite.Application.Infrastructure;
using WeddingSite.Infrastructure.DataAccess;
using WeddingSite.Infrastructure.DataAccess.Abstractions;
using WeddingSite.Infrastructure.Repositories;
using WeddingSite.Infrastructure.Services;

namespace WeddingSite.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IMongoClient, MongoClient>(s =>
        {
            var connectionString = config.GetConnectionString("MongoDb") ?? string.Empty;
            return new MongoClient(connectionString);
        });

        services.AddTransient<IGuestDataAccess, MongoGuestDataAccess>();
        services.AddTransient<IGuestRepository, GuestRepository>();
        services.AddTransient<IInvitationDataAccess, MongoInvitationDataAccess>();
        services.AddTransient<IInvitationRepository, InvitationRepository>();

        services.AddTransient<ITokenService, JwtTokenService>();

        return services;
    }
}
