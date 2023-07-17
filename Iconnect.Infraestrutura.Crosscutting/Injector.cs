using System;
using AutoMapper;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.Interfaces.Queries;
using Iconnect.Aplicacao.Queries;
using Iconnect.Dominio.Helpers;
using Iconnect.Infraestrutura.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Iconnect.Infraestrutura.Crosscutting
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services, AppSettings settings)
        {
            // services.AddAutoMapper(System.AppDomain.CurrentDomain.GetAssemblies());
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();           
            // services.AddScoped<IconnectCoreContext>();
            // services.AddScoped<IServiceWrapper, ServiceWrapper>();
            // services.AddScoped<IMonitoramentoControleAcessoQuerie, MonitoramentoControleAcessoQuerie>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddAutoMapper();
            services.AddScoped<IconnectCoreContext>();
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IMonitoramentoControleAcessoQuerie, MonitoramentoControleAcessoQuerie>();
        }


    }
}
