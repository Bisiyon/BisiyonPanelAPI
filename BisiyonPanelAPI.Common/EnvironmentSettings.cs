using System.ComponentModel;

namespace BisiyonPanelAPI.Common
{
    public static class EnvironmentSettings
    {
        [Description("JWT_VALID_ISSUER")]
        public static string JWTValidIssuer => "BisiyonApp";

        [Description("JWT_VALID_AUDIENCE")]
        public static string JWTValidAudience => "https://localhost:5001";

        [Description("JWT_SECRET")]
        public static string JWTSecret => "hD7J4#v8!k2Rp&@fE93lWyB1XzQM!oL5VqYz0!ASdfG^*JkLmN9p0QrsT2UvWxYz";

        [Description("JWT_EXPIRES_IN")]
        public static int JWTExpiresIn => Convert.ToInt32("3200");

        [Description("JWT_REFRESH_TOKEN_EXPIRES_IN")]
        public static int JWTRefreshTokenExpiresIn => Convert.ToInt32("3100");
    }
}