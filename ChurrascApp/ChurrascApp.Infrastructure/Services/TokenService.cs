using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Domain.Entities;
using ChurrascApp.Infrastructure.Configurations.Token;
using Microsoft.IdentityModel.Tokens;

namespace ChurrascApp.Application.Services;

public class TokenService: ITokenService
{
    private readonly TokenConfiguration _tokenConfiguration;

    public TokenService(TokenConfiguration tokenConfiguration)
    {
        _tokenConfiguration = tokenConfiguration;
    }

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Name, $"{user.PersonalInfo.FirstName} {user.PersonalInfo.LastName}" ?? ""),
            new (JwtRegisteredClaimNames.NameId, user.Id ?? ""),
            new (JwtRegisteredClaimNames.Aud, _tokenConfiguration.Audience),
            new (JwtRegisteredClaimNames.Iss, _tokenConfiguration.Issuer),
            new ("Jti", Guid.NewGuid().ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_tokenConfiguration.TimeToExpiry),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}