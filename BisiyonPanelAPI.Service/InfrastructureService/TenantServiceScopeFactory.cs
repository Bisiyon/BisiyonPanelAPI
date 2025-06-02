using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BisiyonPanelAPI.Service
{
    public class TenantServiceScopeFactory : ITenantServiceScopeFactory
    {

        public IServiceScope CreateScope(string cs)
        {
            var services = new ServiceCollection();

            services.AddDbContext<BisiyonAppContext>(options =>
                options.UseSqlServer(cs)).AddIdentity<User, Role>().AddEntityFrameworkStores<BisiyonAppContext>();

            services.AddScoped<UserManager<User>>();

            var sp = services.BuildServiceProvider();
            return sp.CreateScope();
        }
    }
}