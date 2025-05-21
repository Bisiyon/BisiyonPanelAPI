namespace BisiyonPanelAPI.Interface
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string userName, string siteCode);

    }
}