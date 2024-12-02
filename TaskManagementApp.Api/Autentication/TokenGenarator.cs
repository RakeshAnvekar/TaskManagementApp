using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementApp.Api.Models.User;

namespace TaskManagementApp.Api.Autentication;

public sealed class TokenGenerator : ITokenGenerator
{
    private readonly IConfiguration _configuration;
    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;

    }
    public async Task<string?> GenerateTokenAsync(UserLogin user, CancellationToken cancellationToken)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim("UserEmailId",user.UserEmailId)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
            expires: DateTime.UtcNow.AddHours(1), signingCredentials: signin);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        if (string.IsNullOrEmpty(tokenValue)) return "";
        return tokenValue;
    }
}
 