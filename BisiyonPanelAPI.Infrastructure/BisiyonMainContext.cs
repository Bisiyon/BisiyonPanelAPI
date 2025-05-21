using Microsoft.EntityFrameworkCore;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Infrastructure
{
    public class BisiyonMainContext : DbContext
    {
        public BisiyonMainContext(DbContextOptions<BisiyonMainContext> options) : base(options)
        {

        }

        public DbSet<MainSites> Sites { get; set; }
    }
}