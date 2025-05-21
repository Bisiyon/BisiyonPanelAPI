using Microsoft.EntityFrameworkCore;

namespace BisiyonPanelAPI.Infrastructure
{
    public class BisiyonAppContext : DbContext
    {
        public BisiyonAppContext(DbContextOptions<BisiyonAppContext> options) : base(options)
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
    }
}