using BisiyonPanelAPI.View;

namespace BisiyonPanelAPI.Interface
{
    public interface IJwtTokenGenerator
    {
        GenerateAccessTokenResponse GenerateToken(Guid userId, string userName, string siteCode);
    }
}