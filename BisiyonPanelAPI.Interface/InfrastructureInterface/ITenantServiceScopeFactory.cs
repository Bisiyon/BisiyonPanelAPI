using Microsoft.Extensions.DependencyInjection;

namespace BisiyonPanelAPI.Interface
{
    public interface ITenantServiceScopeFactory
    {
        IServiceScope CreateScope(string siteCode);
    }
}