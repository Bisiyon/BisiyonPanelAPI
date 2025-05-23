using BisiyonPanelAPI.Infrastructure;

namespace BisiyonPanelAPI.Interface
{
    public interface ITenantDbContextFactory
    {
        BisiyonAppContext CreateDbContext();
        BisiyonAppContext CreateDbContext(string cs);
    }
}