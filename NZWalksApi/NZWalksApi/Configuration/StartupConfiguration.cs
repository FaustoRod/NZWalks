using NZWalksApi.Repositories.Interfaces;
using NZWalksApi.Services.Interfaces;
using NZWalksApi.Services;

namespace NZWalksApi.Configuration
{
    public static class StartupConfiguration
    {
        public static void SetupServices(this IServiceCollection services)
        {
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IWalkService, WalkService>();
        }
    }
}
