using BisiyonPanelAPI.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BisiyonPanelAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Service
{
    public class TenantDbContextFactory : ITenantDbContextFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BisiyonMainContext _mainContext;

        public TenantDbContextFactory(IConfiguration configuration
        , BisiyonMainContext mainContext
        , IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _mainContext = mainContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public BisiyonAppContext CreateDbContext()
        {
            if (!(_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false)) return default;
            var user = _httpContextAccessor.HttpContext?.User;
            var siteCodeClaim = user?.FindFirst("siteCode")?.Value;

            if (siteCodeClaim is null)
                throw new UnauthorizedAccessException("siteCode claim bulunamadı.");

            string siteCode = siteCodeClaim.ToString();

            MainSites? site = _mainContext.Sites.First(x => x.SiteCode == siteCode);
            if (site is null)
                throw new UnauthorizedAccessException("site bulunamadı.");

            return CreateDbContext(site.DatabaseInfo ?? "");
        }

        public BisiyonAppContext CreateDbContext(string cs)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BisiyonAppContext>();
            optionsBuilder.UseSqlServer(cs, y =>
            {
                y.MigrationsAssembly(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BisiyonPanelAPI.Migration.dll")).FullName);
                y.CommandTimeout(1200);
                y.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
            });

            BisiyonAppContext context = new BisiyonAppContext(optionsBuilder.Options);
            try
            {
                context.Database.Migrate();
            }
            catch (System.Exception)
            {

            }
            return context;
        }
    }

}