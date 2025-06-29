using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class JwtTokenGenerationService
{
    private readonly string _jwtSecretKey;
    private readonly string _jwtIssuer;
    private readonly string _jwtAudience;

    public JwtTokenGenerationService(string jwtSecretKey, string jwtIssuer, string jwtAudience)
    {
        _jwtSecretKey = jwtSecretKey ?? throw new ArgumentNullException();
        _jwtIssuer = jwtIssuer ?? throw new ArgumentNullException();
        _jwtAudience = jwtAudience ?? throw new ArgumentNullException();
    }
    
    public string Generate(UserModel user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var jwt = new JwtSecurityToken(
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey)), SecurityAlgorithms.HmacSha256));


        var result = new JwtSecurityTokenHandler().WriteToken(jwt);

        return result;
    }
}