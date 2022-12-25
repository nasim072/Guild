using Infrastracture.EFCore;
using Infrastracture.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pricing_Application;
using Pricing_contract.PricingAgg;
using Pricing_contract.ThingAgg;
using Pricing_Entity.Pricing.Application;

namespace Pricing_Configuration
{
    public class PricingBootsrapper
    {
        public static void Configure(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IPricingApplication, PricingApplication>();
            services.AddTransient<IPricingRepository, PricingRepository>();
            services.AddTransient<IThingApplication, ThingApplication>();
            services.AddTransient<IThingRepository, ThingRepository>();
            services.AddDbContext<PricingThingContext>(x => x.UseSqlServer(connectionString));
        }
    }
}