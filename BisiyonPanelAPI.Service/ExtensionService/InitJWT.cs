using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Service
{
    public static class InitJWT
    {
        public static void Init(IServiceCollection service)
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
                                    x.IncludeErrorDetails = EnvironmentSettings.IsDevelopment;
                                    if (EnvironmentSettings.IsDevelopment)
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
    }
}