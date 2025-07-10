using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BisiyonPanelAPI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled exception: " + ex.ToString());
                File.AppendAllText("fatal-errors.log", ex.ToString());
                throw;
            }
            finally
            {
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var envSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("envsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var environment = envSettings["Environment"] ?? "Production";

            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", environment);

            return Host.CreateDefaultBuilder(args)
                            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                            .ConfigureAppConfiguration((hostingContext, config) =>
                            {
                                config.Sources.Clear();

                                config
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("envsettings.json", optional: false, reloadOnChange: true)
                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                                    .AddEnvironmentVariables();
                            })
                            .ConfigureLogging(config => config.ClearProviders())
                            .ConfigureWebHostDefaults(webBuilder =>
                            {
                                webBuilder.UseStartup<Startup>();
                            });
        }

    }
}

// var configurationBuilder = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("envsettings.json", optional: false, reloadOnChange: true);

// var envConfig = configurationBuilder.Build();
// var environment = envConfig["Environment"] ?? "Production";

// var builder = WebApplication.CreateBuilder(new WebApplicationOptions
// {
//     EnvironmentName = environment
// });

// builder.Configuration
//     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//     .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

// // builder.Services.AddIdentity<User, Role>(options =>
// // {
// //     // Identity ayarları
// // })
// // .AddEntityFrameworkStores<BisiyonAppContext>()
// // .AddDefaultTokenProviders();

// // Add services to the container.
// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.PropertyNamingPolicy = null;
// });

// builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
// {
//     // containerBuilder.Populate(builder.Services);  // IServiceCollection'daki servisleri Autofac'e taşı
//     containerBuilder.RegisterModule(new ModuleRegisterService(builder.Configuration));
// });

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//         ValidAudience = builder.Configuration["JwtSettings:Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(
//             Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])
//         ),
//         ClockSkew = TimeSpan.Zero
//     };

//     options.Events = new JwtBearerEvents
//     {
//         OnChallenge = context =>
//         {
//             // Default davranış olan 302'yi engelle
//             context.HandleResponse();
//             context.Response.StatusCode = 401;
//             context.Response.ContentType = "application/json";
//             return context.Response.WriteAsync("{\"error\": \"Unauthorized\"}");
//         }
//     };
// });

// builder.Services.AddAuthorization();

// builder.Services.ConfigureApplicationCookie(options =>
// {
//     options.Events.OnRedirectToLogin = context =>
//     {
//         context.Response.StatusCode = 401;
//         return Task.CompletedTask;
//     };
//     options.Events.OnRedirectToAccessDenied = context =>
//     {
//         context.Response.StatusCode = 403;
//         return Task.CompletedTask;
//     };
// });

// builder.Services.AddHttpContextAccessor();

// builder.Services.AddDbContext<BisiyonMainContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb"));
// });

// builder.Services.AddDbContext<BisiyonAppContext>(options =>
// {
//     options.ConfigureWarnings(builder =>
//                                     {
//                                         builder.Ignore(CoreEventId.NavigationBaseIncludeIgnored);
//                                     });
//     options.UseSqlServer(string.Empty, y =>
//     {
//         y.MigrationsAssembly(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BisiyonPanelAPI.Migration.dll")).FullName);
//         y.CommandTimeout(1200);
//         y.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
//     });

// }).AddIdentity<User, Role>().AddEntityFrameworkStores<BisiyonAppContext>().AddDefaultTokenProviders();

// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
//     {
//         Title = "BisiyonPanelAPI",
//         Version = "v1"
//     });

//     var securityScheme = new OpenApiSecurityScheme
//     {
//         Name = "Authorization",
//         Type = SecuritySchemeType.Http,
//         Scheme = "Bearer",
//         BearerFormat = "JWT",
//         In = ParameterLocation.Header,
//         Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
//     };

//     var securityRequirement = new OpenApiSecurityRequirement
//     {
//         {
//             securityScheme,
//             new string[] {}
//         }
//     };

//     c.AddSecurityDefinition("Bearer", securityScheme);
//     c.AddSecurityRequirement(securityRequirement);

// });


// var app = builder.Build();

// // Configure the HTTP request pipeline.
// // if (app.Environment.IsDevelopment())
// // {
// app.UseSwagger();
// app.UseSwaggerUI(c =>
// {
//     c.SwaggerEndpoint("/swagger/v1/swagger.json", "BisiyonPanelAPI v1");
//     c.RoutePrefix = string.Empty; // Swagger UI kök dizinde açılsın
// });
// // }

// app.UseHttpsRedirection();
// app.UseStaticFiles(new StaticFileOptions
// {
//     OnPrepareResponse = ctx =>
//     {
//         ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store");
//         ctx.Context.Response.Headers.Append("Pragma", "no-cache");
//         ctx.Context.Response.Headers.Append("Expires", "-1");
//     }
// });

// app.UseRouting();

// app.UseAuthentication();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();
