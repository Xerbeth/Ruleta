using Microsoft.Extensions.DependencyInjection;
using Ruleta.Domain.DAL.Repository;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer
{
    public class StartupBusinessLayer
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

            ////Dependencias internas de la capas de negocio de Administracion
            ////Contexto de Administracion
            //services.AddDbContext<PedidosContext>(config =>
            //{
            //    config.UseSqlServer(connectionString);
            //});
        }
    }
}
