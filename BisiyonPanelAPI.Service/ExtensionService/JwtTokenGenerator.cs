using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BisiyonPanelAPI.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Guid userId, string userName, string siteCode)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? "hD7J4#v8!k2Rp&@fE93lWyB1XzQM!oL5VqYz0!ASdfG^*JkLmN9p0QrsT2UvWxYz"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim("siteCode", siteCode.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public GenerateAccessTokenResponse GenerateToken2(Guid userId, string userName, string siteCode)
        {
            SecurityToken token;
            var claims = new[] {
                                        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim("siteCode", siteCode.ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };
            var key = Encoding.UTF8.GetBytes(EnvironmentSettings.JWTSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = EnvironmentSettings.JWTValidIssuer,
                Audience = EnvironmentSettings.JWTValidAudience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(EnvironmentSettings.JWTExpiresIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            token = tokenHandler.CreateToken(tokenDescriptor);
            var bearerToken = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();
            var RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(EnvironmentSettings.JWTRefreshTokenExpiresIn);
            return new GenerateAccessTokenResponse()
            {
                BearerToken = bearerToken,
                RefreshToken = refreshToken,
                RefreshTokenExpiry = RefreshTokenExpiry
            };
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}