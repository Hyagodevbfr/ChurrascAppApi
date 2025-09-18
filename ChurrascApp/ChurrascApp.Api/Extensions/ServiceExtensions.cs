using ChurrascApp.Application;
using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Application.Services;
using ChurrascApp.Domain.Services;
using ChurrascApp.Infrastructure.Services;

namespace ChurrascApp.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<PasswordValidationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IJoinRequestService, JoinRequestService>();
        services.AddScoped<IParticipantService, ParticipantService>();
        
        return services;
    }
}