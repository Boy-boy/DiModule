using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspDotNetCoreDiModule
{
    public static class DiApplicationBuilderExtensions
    {
        public static void UseModule(this IApplicationBuilder app)
        {
            var diBootstrapper = app.ApplicationServices.GetRequiredService<DiBootstrapper>();
            diBootstrapper.Initialize();
            app.Use(async (context, next) => { await next(); });
        }
    }
}
