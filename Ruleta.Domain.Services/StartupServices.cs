using System;
using Microsoft.Extensions.DependencyInjection;
using Ruleta.Domain.BusinessLayer;
using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Services;
using Ruleta.Domain.Services.Interfaces;

namespace PAI.Domain.Services
{
    public class StartupServices
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDocumentTypeBL, DocumentTypeBL>();
            services.AddScoped<IBetTypeBL, BetTypeBL>();
            services.AddScoped<IRouletteBL, RouletteBL>();
            services.AddScoped<IRouletteConfigurationBL, RouletteConfigurationBL>();
            services.AddScoped<IPlayerBL,PlayerBL>();
            services.AddScoped<IBetBL, BetBL>();            

            StartupBusinessLayer.ConfigureServices(services, connectionString);
        }
    }
}
