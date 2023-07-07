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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddAutoMapper();
            // services.AddAutoMapper(typeof(Startup), cfg =>
            // {
            //     cfg.CreateMap<DateTimeOffset, DateTime>().ConvertUsing<DateTimeOffsetConverter>();
            //     cfg.CreateMap<DateTime, DateTimeOffset>().ConvertUsing<DateTimeConverter>();
            //     cfg.CreateMap<DateTimeOffset?, DateTime?>().ConvertUsing<NullableDateTimeOffsetConverter>();
            //     cfg.CreateMap<DateTime?, DateTimeOffset?>().ConvertUsing<NullableDateTimeConverter>();
            // });
            services.AddScoped<IconnectCoreContext>();
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IMonitoramentoControleAcessoQuerie, MonitoramentoControleAcessoQuerie>();
        }
    }
}
