using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BisiyonPanelAPI.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace BisiyonPanelAPI.Service
{
    public static class InitStartupExtensions
    {
        public static void InitJWT(this IServiceCollection service, bool IsDevelopment)
        {
            service.AddAuthentication(x =>
                                {
                                    x.DefaultAuthenticateScheme = "AdminJwt";
                                    x.DefaultChallengeScheme = "AdminJwt";
                                    x.DefaultScheme = "AdminJwt";
                                }).AddJwtBearer("AdminJwt", x =>
                                {
                                    x.SaveToken = true;
                                    x.RequireHttpsMetadata = false;
                                    x.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,
                                        ValidateAudience = true,
                                        ValidIssuer = EnvironmentSettings.JWTValidIssuer,
                                        ValidAudience = EnvironmentSettings.JWTValidAudience,
                                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EnvironmentSettings.JWTSecret)),
                                        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                                    };
                                    x.IncludeErrorDetails = IsDevelopment;
                                    if (IsDevelopment)
                                        x.Events = new JwtBearerEvents
                                        {
                                            OnAuthenticationFailed = context =>
                                            {
                                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                                return Task.CompletedTask;
                                            },
                                            OnTokenValidated = context =>
                                            {
                                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                                return Task.CompletedTask;
                                            }
                                        };
                                });
            service.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder("AdminJwt");
                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser().AddAuthenticationSchemes("AdminJwt");
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        public static void InitSwagger(this IServiceCollection service, bool isDevelopment)
        {
            if (isDevelopment)
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

        public static void InitCORS(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  policy =>
                                  {
                                      policy
                                      .WithOrigins(
                                        "http://localhost:5173"
                                        )
                                      .AllowCredentials().AllowAnyHeader().AllowAnyMethod();
                                  });
            });
        }
    }
}