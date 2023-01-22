using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace RealEstateCatalog.Core.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly string _privateKey;
    private readonly string _sectionKey = "AuthenticationPrivateKey";

    public AuthenticationService(IConfiguration configuration)
    {
        _privateKey = configuration.GetSection(_sectionKey).Value ??
            throw new ArgumentNullException(_sectionKey);
    }

    public LoginResponseDto GetLoginRequest(User user)
        => new LoginResponseDto
        {
            Username = user.Username,
            Token = CreateJWT(user)
        };

    public int GetUserId(ClaimsPrincipal user)
        => int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    private string CreateJWT(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_privateKey));
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var signingCredentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(10),
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
