using System;
using Microsoft.Extensions.DependencyInjection;
using Ruleta.Domain.BusinessLayer;
using Ruleta.Domain.BusinessLayer.Interfaces;

namespace PAI.Domain.Services
{
    public class StartupServices
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ITestBL, TestBL>();
            services.AddScoped<IDocumentTypeBL, DocumentTypeBL>();
            
            StartupBusinessLayer.ConfigureServices(services, connectionString);
        }
    }
}
