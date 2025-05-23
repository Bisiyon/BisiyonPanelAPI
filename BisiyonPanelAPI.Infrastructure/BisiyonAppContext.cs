using BisiyonPanelAPI.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BisiyonPanelAPI.Infrastructure
{
    public class BisiyonAppContext : IdentityDbContext<User, Role, Guid>
    {

        public BisiyonAppContext(DbContextOptions<BisiyonAppContext> options) : base(options)
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("BisiyonAppContext OnConfiguring");
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
    }
}