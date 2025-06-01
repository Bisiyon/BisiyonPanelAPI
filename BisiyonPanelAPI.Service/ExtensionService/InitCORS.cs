using Microsoft.Extensions.DependencyInjection;

namespace BisiyonPanelAPI.Service
{
    public static class InitCORS
    {
        public static void Init(IServiceCollection service)
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