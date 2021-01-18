using Microsoft.Extensions.DependencyInjection;
using PAI.Domain.Services;
using Ruleta.Domain.Services;
using Ruleta.Domain.Services.Interfaces;

namespace Ruleta.Domain.Transactions
{
    public class StartupTransactions
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IRouletteServices, RouletteServices>();
            services.AddScoped<IRouletteConfigurationServices, RouletteConfigurationServices>();
            services.AddScoped<IPlayerServices, PlayerServices>(); 
            services.AddScoped<IBetTypeServices, BetTypeServices>();
            services.AddScoped<IBetServices, BetServices>();

            StartupServices.ConfigureServices(services, connectionString);
        }
    }
}
