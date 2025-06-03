using BisiyonPanelAPI.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                IMutableProperty? property = entityType.FindProperty("ConcurrencyToken");
                if (property != null)
                {
                    property.SetColumnType("ROWVERSION");
                    property.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                    property.IsConcurrencyToken = true;
                }
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