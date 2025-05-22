using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BisiyonPanelAPI.Infrastructure
{
    public class BisiyonAppContextFactory : IDesignTimeDbContextFactory<BisiyonAppContext>
    {
        public BisiyonAppContext CreateDbContext(string[] args)
        {
            Console.WriteLine("BisiyonAppContextFactory CreateDbContext");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // migration projesinin base path'i olabilir, doğru yol vermen gerekebilir
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BisiyonAppContext>();

            var connectionString = configuration.GetConnectionString("AppDb");

            optionsBuilder.UseSqlServer(connectionString, y =>
            {
                y.MigrationsAssembly(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BisiyonPanelAPI.Migration.dll")).FullName);
                y.CommandTimeout(1200);
                y.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
            });

            return new BisiyonAppContext(optionsBuilder.Options);
        }
    }

}