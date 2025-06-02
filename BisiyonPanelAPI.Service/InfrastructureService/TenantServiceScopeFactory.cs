using System.Reflection;
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

            services.AddDbContext<BisiyonAppContext>(
                options =>
                options.UseSqlServer(cs, y =>
                {
                    y.MigrationsAssembly(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BisiyonPanelAPI.Migration.dll")).FullName);
                    y.CommandTimeout(1200);
                    y.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                })).AddIdentityCore<User>().AddRoles<Role>().AddEntityFrameworkStores<BisiyonAppContext>();

            services.AddScoped<UserManager<User>>();

            var sp = services.BuildServiceProvider();
            return sp.CreateScope();
        }
    }
}