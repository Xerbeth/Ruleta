using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PAI.Domain.Services;
using Ruleta.Domain.Services;
using Ruleta.Domain.Services.Interfaces;
using Ruleta.Domain.Transactions;
using Ruleta.Domain.Transactions.Interfaces;

namespace Ruleta.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {                      
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IDocumentTypeServices, DocumentTypeServices>();
            services.AddScoped<IBetTypeServices, BetTypeServices>();
            services.AddScoped<IRouletteServices, RouletteServices>();
            services.AddScoped<IRouletteTransactions, RouletteTransactions>();
            services.AddScoped<IRouletteConfigurationServices, RouletteConfigurationServices>();
            services.AddSingleton(Configuration);

            StartupServices.ConfigureServices(services, connectionString);
            StartupTransactions.ConfigureServices(services, connectionString);           

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ROULETTE API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.CustomSchemaIds(type => type.ToString());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ROULETTE API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
