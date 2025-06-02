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

        public virtual DbSet<Aidat> Aidat { get; set; }
        public virtual DbSet<Blok> Blok { get; set; }
        public virtual DbSet<Gorevli> Gorevli { get; set; }
        public virtual DbSet<Mesken> Mesken { get; set; }
        public virtual DbSet<MeskenTipi> MeskenTipi { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<UyeDurumTip> UyeDurumTip { get; set; }
        public virtual DbSet<UyeHareket> UyeHareket { get; set; }
    }
}