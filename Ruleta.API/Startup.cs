using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IDocumentTypeServices, DocumentTypeServices>();
            services.AddScoped<IBetTypeServices, BetTypeServices>();
            services.AddScoped<IRouletteServices, RouletteServices>();
            services.AddScoped<IRouletteTransactions, RouletteTransactions>();
            services.AddSingleton(Configuration);

            StartupServices.ConfigureServices(services, connectionString);
            StartupTransactions.ConfigureServices(services, connectionString);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
