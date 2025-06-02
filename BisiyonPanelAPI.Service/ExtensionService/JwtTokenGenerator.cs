using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.IdentityModel.Tokens;

namespace BisiyonPanelAPI.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfigurationService _configService;

        public JwtTokenGenerator(IConfigurationService configService)
        {
            _configService = configService;
        }

        public GenerateAccessTokenResponse GenerateToken(Guid userId, string userName, string siteCode)
        {
            SecurityToken token;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim("siteCode", siteCode.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var key = Encoding.UTF8.GetBytes(_configService.GetFromSection(Enum_ConfigSection.JwtSettings, Enum_ConfigSetting.JWTSecret, EnvironmentSettings.JWTSecret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configService.GetFromSection(Enum_ConfigSection.JwtSettings, Enum_ConfigSetting.JWTValidIssuer, EnvironmentSettings.JWTValidIssuer),
                Audience = _configService.GetFromSection(Enum_ConfigSection.JwtSettings, Enum_ConfigSetting.JWTValidAudience, EnvironmentSettings.JWTValidAudience),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            string expiresIn = _configService.GetFromSection(Enum_ConfigSection.JwtSettings, Enum_ConfigSetting.JWTExpiresIn, EnvironmentSettings.JWTExpiresIn.ToString());
            if (int.TryParse(expiresIn, out int expiresOut))
                tokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(expiresOut);

            var tokenHandler = new JwtSecurityTokenHandler();
            token = tokenHandler.CreateToken(tokenDescriptor);
            var bearerToken = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            DateTime RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(expiresOut);
            string refreshTokenExpiresIn = _configService.GetFromSection(Enum_ConfigSection.JwtSettings, Enum_ConfigSetting.JWTRefreshTokenExpiresIn, EnvironmentSettings.JWTRefreshTokenExpiresIn.ToString());
            if (int.TryParse(refreshTokenExpiresIn, out int refreshTokenExpiresOut))
                RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(refreshTokenExpiresOut);

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