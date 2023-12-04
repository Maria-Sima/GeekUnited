using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly byte[] _keyBytes; // The 512-bit key

    public TokenService(IConfiguration config)
    {
        _config = config;
        _keyBytes = GenerateRandomKey(64); // 64 bytes for a 512-bit key
    }

    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
        };

        var creds = new SigningCredentials(new SymmetricSecurityKey(_keyBytes), SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1), // Adjust expiration as needed
            SigningCredentials = creds,
            Issuer = _config["Token:Issuer"], // Optionally, specify the audience
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private byte[] GenerateRandomKey(int length)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            var keyBytes = new byte[length];
            rng.GetBytes(keyBytes);
            return keyBytes;
        }
    }
}
