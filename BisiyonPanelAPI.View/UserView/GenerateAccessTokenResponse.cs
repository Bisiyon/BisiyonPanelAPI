namespace BisiyonPanelAPI.View
{
    public class GenerateAccessTokenResponse
    {
        public required string BearerToken { get; set; }
        public required string RefreshToken { get; set; }
        public required DateTime RefreshTokenExpiry { get; set; }
    }
}