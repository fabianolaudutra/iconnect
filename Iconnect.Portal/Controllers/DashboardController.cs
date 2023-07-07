using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Aplicacao.FilterModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DashboardController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("RelAcessosPorPeriodo")]
        public DashboardViewModel RelAcessosPorPeriodo(DashboardFilterModel model)
        {
            return _service.Dashboard.RelAcessosPorPeriodo(model);
        }

        [HttpPost]
        [Authorize]
        [Route("RelAcessosPorPessoa")]
        public DashboardViewModel RelAcessosPorPessoa(DashboardFilterModel model)
        {
            return _service.Dashboard.RelAcessosPorPessoa(model);
        }

        [HttpPost]
        [Authorize]
        [Route("RelAcessosPorCliente")]
        public DashboardViewModel RelAcessosPorCliente(DashboardFilterModel model)
        {
            return _service.Dashboard.RelAcessosPorCliente(model);
        }

        [HttpPost]
        [Authorize]
        [Route("RelMonitoramentoTempoMedioAtendimento")]
        public DashboardViewModel RelMonitoramentoTempoMedioAtendimento(DashboardFilterModel model)
        {
            return _service.Dashboard.RelMonitoramentoTempoMedioAtendimento(model);
        }

        [HttpPost]
        [Authorize]
        [Route("RelMonitoramentoTempoMedioCliente")]
        public DashboardViewModel RelMonitoramentoTempoMedioCliente(DashboardFilterModel model)
        {
            return _service.Dashboard.RelMonitoramentoTempoMedioCliente(model);
        }

        [HttpPost]
        [Authorize]
        [Route("RelMonitoramentoPorCategoria")]
        public DashboardViewModel RelMonitoramentoPorCategoria(DashboardFilterModel model)
        {
            return _service.Dashboard.RelMonitoramentoPorCategoria(model);
        }

        [HttpPost]
        [Authorize]
        [Route("RelMonitoramentoPorDia")]
        public DashboardViewModel RelMonitoramentoPorDia(DashboardFilterModel model)
        {
            return _service.Dashboard.RelMonitoramentoPorDia(model);
        }

        [HttpPost]
        [Authorize]
        [Route("RelTotalizadores")]
        public DashboardViewModel RelTotalizadores(DashboardFilterModel model)
        {
            return _service.Dashboard.RelTotalizadores(model);
        }
    }
}