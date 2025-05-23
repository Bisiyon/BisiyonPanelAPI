using BisiyonPanelAPI.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BisiyonPanelAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Reflection;

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
            //siteCode'a göre mainContext'den site db'sine ulaşılacak.
            if (!(_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false)) return null;
            var user = _httpContextAccessor.HttpContext?.User;
            var siteCodeClaim = user?.FindFirst("siteCode")?.Value;

            if (siteCodeClaim is null)
                throw new UnauthorizedAccessException("siteCode claim bulunamadı.");

            string siteCode = siteCodeClaim.ToString();

            var connectionString = _configuration.GetConnectionString("AppDb")
                ?.Replace("{dbName}", siteCode)
                ?? throw new Exception("Bağlantı dizesi bulunamadı");

            return CreateDbContext(connectionString);
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
            //Migration çalıştırılacak. Try catch eklenebilir.
            return context;
        }
    }

}