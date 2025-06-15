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
        public DbSet<Aidat> Aidat { get; set; }
        public DbSet<AidatGrup> AidatGrup { get; set; }
        public DbSet<Arac> Arac { get; set; }
        public DbSet<Blok> Blok { get; set; }
        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Mesken> Mesken { get; set; }
        public DbSet<MeskenTipi> MeskenTipi { get; set; }
        public DbSet<MeskenUye> MeskenUye { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Uye> Uye { get; set; }
        public DbSet<UyeDurumTip> UyeDurumTip { get; set; }
        public DbSet<UyeHareket> UyeDurumHareket { get; set; }
    }
}