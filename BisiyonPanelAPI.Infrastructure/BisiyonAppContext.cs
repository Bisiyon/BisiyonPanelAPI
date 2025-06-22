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

            builder.Entity<Ilce>()
                .HasOne(x => x.Il)
                .WithMany()
                .HasForeignKey(x => x.IlId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Uye>()
                .HasOne(x => x.Il)
                .WithMany()
                .HasForeignKey(x => x.IlId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Uye>()
                .HasOne(x => x.Ilce)
                .WithMany()
                .HasForeignKey(x => x.IlceId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public virtual DbSet<Aidat> Aidat { get; set; }
        public virtual DbSet<AidatGrup> AidatGrup { get; set; }
        public virtual DbSet<Arac> Arac { get; set; }
        public virtual DbSet<Blok> Blok { get; set; }
        public virtual DbSet<Il> Il { get; set; }
        public virtual DbSet<Ilce> Ilce { get; set; }
        public virtual DbSet<Mesken> Mesken { get; set; }
        public virtual DbSet<MeskenTipi> MeskenTipi { get; set; }
        public virtual DbSet<MeskenUye> MeskenUye { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<UyeDurumTip> UyeDurumTip { get; set; }
        public virtual DbSet<UyeHareket> UyeHareket { get; set; }
        public virtual DbSet<UyeHareket> UyeDurumHareket { get; set; }
        public virtual DbSet<Demirbas> Demirbas { get; set; }
    }
}