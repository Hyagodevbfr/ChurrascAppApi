using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}