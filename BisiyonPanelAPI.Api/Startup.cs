using System.Reflection;
using Autofac;
using BisiyonPanelAPI.Common.MappingConfigs;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Service;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using BisiyonPanelAPI.Api.Middlewares;


namespace BisiyonPanelAPI.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment _env)
        {
            Configuration = configuration;
            env = _env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            MapsterConfig.RegisterMappings();
            var mvcBuilder = services.AddControllers(mvcOptions =>
                    {
                        mvcOptions.EnableEndpointRouting = false;
                        mvcOptions.AllowEmptyInputInBodyModelBinding = true;
                    }).AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddDbContext<BisiyonMainContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MainDb"));
            });

            services.AddDbContext<BisiyonAppContext>(options =>
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
            }).AddIdentity<User, Role>().AddEntityFrameworkStores<BisiyonAppContext>().AddDefaultTokenProviders();

            services.InitJWT(env.IsDevelopment());
            services.InitSwagger(env.IsDevelopment());
            services.InitCORS();
            services.AddHttpContextAccessor();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleRegisterService(Configuration));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.EnableDeepLinking();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BisiyonPanelAPI v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}