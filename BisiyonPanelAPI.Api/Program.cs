using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("envsettings.json", optional: false, reloadOnChange: true);

var envConfig = configurationBuilder.Build();
var environment = envConfig["Environment"] ?? "Production";

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = environment
});

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ModuleRegisterService(builder.Configuration));
});

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddDbContext<BisiyonMainContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb"));
});

builder.Services.AddDbContext<BisiyonAppContext>(options =>
{
    options.ConfigureWarnings(builder =>
                                    {
                                        builder.Ignore(CoreEventId.NavigationBaseIncludeIgnored);
                                    });
    options.UseSqlServer(string.Empty, y =>
    {
        y.MigrationsAssembly(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BisiyonPanelAPI.Migration.dll")).FullName);
        y.CommandTimeout(1200);
        y.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
    });

});

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store");
        ctx.Context.Response.Headers.Append("Pragma", "no-cache");
        ctx.Context.Response.Headers.Append("Expires", "-1");
    }
});


app.UseAuthorization();

app.MapControllers();

app.Run();
