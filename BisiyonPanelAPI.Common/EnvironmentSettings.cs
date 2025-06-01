using System.ComponentModel;

namespace BisiyonPanelAPI.Common
{
    public static class EnvironmentSettings
    {
        [Description("ASPNETCORE_ENVIRONMENT")]
        public static string ASPNETCORE_ENVIRONMENT => GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

        [Description("IsDevelopment")]
        public static bool IsDevelopment => ASPNETCORE_ENVIRONMENT == "Development";

        [Description("JWT_VALID_ISSUER")]
        public static string JWTValidIssuer => GetEnvironmentVariable("JWT_VALID_ISSUER", "BisiyonApp");

        [Description("JWT_VALID_AUDIENCE")]
        public static string JWTValidAudience => GetEnvironmentVariable("JWT_VALID_AUDIENCE", "https://localhost:5001");

        [Description("JWT_SECRET")]
        public static string JWTSecret => GetEnvironmentVariable("JWT_VALID_AUDIENCE", "hD7J4#v8!k2Rp&@fE93lWyB1XzQM!oL5VqYz0!ASdfG^*JkLmN9p0QrsT2UvWxYz");

        [Description("JWT_EXPIRES_IN")]
        public static int JWTExpiresIn => Convert.ToInt32(GetEnvironmentVariable("JWT_EXPIRES_IN", "3200"));

        [Description("JWT_REFRESH_TOKEN_EXPIRES_IN")]
        public static int JWTRefreshTokenExpiresIn => Convert.ToInt32(GetEnvironmentVariable("JWT_REFRESH_TOKEN_EXPIRES_IN", "3100"));

        public static string GetEnvironmentVariable(string name, string defaultValue = "")
        {
            var value = Environment.GetEnvironmentVariable(name);
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
    }
}