using System.Reflection;
using BisiyonPanelAPI.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BisiyonPanelAPI.Infrastructure
{
    public class BisiyonAppContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;

        public BisiyonAppContext(DbContextOptions<BisiyonAppContext> options) : base(options)
        {
            // _configuration = configuration;
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("BisiyonAppContext OnConfiguring");
            if (!optionsBuilder.IsConfigured)
            {
                // Console.WriteLine("if (!optionsBuilder.IsConfigured)");
                // var connStr = _configuration.GetConnectionString("AppDb");
                // Console.WriteLine(connStr);

                // if (string.IsNullOrEmpty(connStr))
                //     throw new InvalidOperationException("Connection string not found for development environment!");

                // optionsBuilder.UseSqlServer(connStr, y =>
                // {
                //     y.MigrationsAssembly(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BisiyonPanelAPI.Migration.dll")).FullName);
                //     y.CommandTimeout(1200);
                //     y.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                // });
            }
        }
    }
}