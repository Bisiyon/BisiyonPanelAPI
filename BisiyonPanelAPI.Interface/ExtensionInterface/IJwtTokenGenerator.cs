using BisiyonPanelAPI.View;

namespace BisiyonPanelAPI.Interface
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string userName, string siteCode);
        GenerateAccessTokenResponse GenerateToken2(Guid userId, string userName, string siteCode);

    }
}