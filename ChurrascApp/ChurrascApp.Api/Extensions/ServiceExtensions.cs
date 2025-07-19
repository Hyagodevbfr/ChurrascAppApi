using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Application.Services;
using ChurrascApp.Domain.Services;

namespace ChurrascApp.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<PasswordValidationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        
        
        return services;
    }
}