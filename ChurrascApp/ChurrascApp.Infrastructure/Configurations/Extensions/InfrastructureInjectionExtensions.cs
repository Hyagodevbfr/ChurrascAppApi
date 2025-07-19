using ChurrascApp.Infrastructure.Configurations.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ChurrascApp.Infrastructure.Configurations.Extensions;

public static class InfrastructureInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDBSettings"));
        services.AddSingleton<MongoDbContext>();
        
        return services;
    }
}