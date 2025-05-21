using BisiyonPanelAPI.Infrastructure;

namespace BisiyonPanelAPI.Interface
{
    public interface ITenantDbContextFactory
    {
        BisiyonAppContext CreateDbContext(string siteCode);
    }
}