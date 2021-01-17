using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer
{
    public class StartupBusinessLayer
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            //services.AddScoped<ITestBL, TestBL>();

            ////Dependencias internas de la capas de negocio de Administracion
            ////Contexto de Administracion
            //services.AddDbContext<PedidosContext>(config =>
            //{
            //    config.UseSqlServer(connectionString);
            //});
        }
    }
}
