using NZWalksApi.Repositories.Interfaces;
using NZWalksApi.Services.Interfaces;
using NZWalksApi.Services;

namespace NZWalksApi.Configuration
{
    public static class StartupConfiguration
    {
        public static void SetupServices(this IServiceCollection services)
        {
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IWalkService, WalkService>();
            services.AddScoped<IWalkDifficultyService, WalkDifficultyService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
