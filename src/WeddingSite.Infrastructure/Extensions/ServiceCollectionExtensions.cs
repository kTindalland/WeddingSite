using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        return services;
    }
}
