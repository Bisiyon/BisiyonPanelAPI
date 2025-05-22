using BisiyonPanelAPI.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BisiyonPanelAPI.Infrastructure;


namespace BisiyonPanelAPI.Service
{
    public class TenantDbContextFactory : ITenantDbContextFactory
    {
        private readonly IConfiguration _configuration;
        private readonly BisiyonMainContext _mainContext;

        public TenantDbContextFactory(IConfiguration configuration, BisiyonMainContext mainContext)
        {
            _configuration = configuration;
            _mainContext = mainContext;
        }

        public BisiyonAppContext CreateDbContext(string siteCode)
        {
            //siteCode'a göre mainContext'den site db'sine ulaşılacak.
            var dbName = $"Saas_Site_{siteCode:N}";
            var connectionString = _configuration.GetConnectionString("TenantTemplate")
                ?.Replace("{dbName}", dbName)
                ?? throw new Exception("Bağlantı dizesi bulunamadı");

            var optionsBuilder = new DbContextOptionsBuilder<BisiyonAppContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BisiyonAppContext(optionsBuilder.Options);
        }
    }

}