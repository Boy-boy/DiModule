using Microsoft.Extensions.DependencyInjection;

namespace AspDotNetCoreDiModule
{
    public static class DiServiceCollectionExtensions
    {
        public static void AddModule<TStartupModule>(this IServiceCollection services)
            where TStartupModule : class
        {
            services.AddSingleton(new DiBootstrapper(typeof(TStartupModule), services));
        }
    }
}
