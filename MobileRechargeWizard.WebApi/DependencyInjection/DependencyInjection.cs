using MobileRechargeWizard.WebApi.Repository;
using MobileRechargeWizard.WebApi.Service;
using MobileRechargeWizard.WebApi.Services;

namespace MobileRechargeWizard.WebApi.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMobileRepository, MobileRepository>();
            services.AddScoped<IRechargePlanRepository, RechargePlanRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMobileService, MobileService>();
            services.AddScoped<IRechargePlanService, RechargePlanService>(); // Uncomment this line
        }
    }
}
