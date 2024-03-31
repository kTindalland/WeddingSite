using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using WeddingSite.Application.Infrastructure;
using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Infrastructure.Services;
internal class JwtTokenService(IConfiguration config) : ITokenService
{
    private readonly string _secretKey = config.GetValue<string>("TokenService:SecretKey") ?? string.Empty;

    public string CreateToken(IInvitation invitation)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var claims = new List<Claim>();
        claims.AddRange( invitation.Guests.Select(x => new Claim("guests", x)) );
        claims.AddRange( invitation.Roles.Select(x => new Claim("roles", x)) );
        claims.Add(new Claim("passphrase", invitation.Passphrase));
        claims.Add(new Claim("isFullDay", invitation.IsFullDay.ToString()));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };


        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}