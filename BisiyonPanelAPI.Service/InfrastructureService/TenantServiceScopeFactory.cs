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
        private readonly IServiceProvider _serviceProvider;

        public TenantServiceScopeFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IServiceScope CreateScope(string cs)
        {
            var services = new ServiceCollection();

            services.AddDbContext<BisiyonAppContext>(options =>
                options.UseSqlServer(cs));

            services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<BisiyonAppContext>();

            services.AddScoped<UserManager<User>>();

            var sp = services.BuildServiceProvider();
            return sp.CreateScope();
        }
    }
}