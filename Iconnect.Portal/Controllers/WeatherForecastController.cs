using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IServiceWrapper _service;
   
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IServiceWrapper service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            var clientes = _service.Cliente.ListarTodos("todos");
            List<WeatherForecast> ret = new List<WeatherForecast>();
            clientes.ForEach(x =>
            {
                ret.Add(new WeatherForecast()
                {
                    Date = x.cli_d_dataCriacao == null ? DateTime.Now : x.cli_d_dataCriacao.Value,
                    Summary = x.cli_c_nomeFantasia,
                    TemperatureC = Convert.ToInt32(x.cli_n_codigo)
                });
            });

            return ret;

            //return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
