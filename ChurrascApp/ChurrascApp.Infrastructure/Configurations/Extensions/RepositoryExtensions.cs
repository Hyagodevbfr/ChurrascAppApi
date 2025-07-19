using ChurrascApp.Domain.Repositories;
using ChurrascApp.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace ChurrascApp.Infrastructure.Configurations.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
    
}