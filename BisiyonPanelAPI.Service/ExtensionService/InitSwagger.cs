using BisiyonPanelAPI.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace BisiyonPanelAPI.Service
{
    public static class InitSwagger
    {
        public static void Init(IServiceCollection service)
        {
            if (EnvironmentSettings.IsDevelopment)
            {
                service.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "BisiyonPanelAPI",
                        Version = "v1",
                    });
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme."
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement{{
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}}});
                });
            }
        }
    }
}