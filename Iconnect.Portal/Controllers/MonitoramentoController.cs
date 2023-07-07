using System;
using System.Collections.Generic;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Aplicacao.FilterModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Iconnect.Portal.HubConfigs;
using Iconnect.Infraestrutura.Enums;
using Iconnect.Portal.Helpers.HubConfigs;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonitoramentoController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<MonitoramentoController> _logger;
        public IHubContext<ConnectGuardHub> _hub;
        public IHubContext<ComboClienteGuardHub> _hubCombo;

        public MonitoramentoController(ILogger<MonitoramentoController> logger, IServiceWrapper service,
            IHttpContextAccessor acessor, IHubContext<ConnectGuardHub> hub, IHubContext<ComboClienteGuardHub> hubCombo) : base(acessor)
        {
            _logger = logger;
            _service = service;
            _hub = hub;
            _hubCombo = hubCombo;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] MonitoramentoFilterModel filter)
        {
            var response = _service.Monitoramento.GetMonitoramentoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<MonitoramentoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public MonitoramentoViewModel Get(int id)
        {
            return _service.Monitoramento.GetMonitoramento(id);
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] MonitoramentoViewModel model)
        {
            return Ok(_service.Monitoramento.SalvarMonitoramento(model));
        }

        [HttpPost]
        [Authorize]
        [Route("getRelatorioMonitoramento")]
        public IActionResult getRelatorioMonitoramento([FromBody] MonitoramentoViewModel model)
        {
            try
            {
                return File(_service.Monitoramento.getRelatorioMonitoramento(model), "application/ms-excel");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("obterClientesComAlerta")]
        public IActionResult ObterClientesComAlerta([FromBody] IList<int> idsClientes)
        {
            return Ok(_service.Monitoramento.ClientesComAlerta(idsClientes));
        }

        [HttpGet]
        [Route("atualizarGridEventosGuard")]
        public IActionResult AtualizarGridEventosGuard(string idCliente)
        {
            var connections = _service.ConnectionSignalR.ObterConnections(idCliente, EnumHubs.Monitoramento);

            var ret = _service.Monitoramento.GetMonitoramentoAtualizacaoGrid(idCliente, "1");

            if (ret != null)
            {
                foreach (var connectionId in connections)
                {
                    _hub.Clients.Client(connectionId).SendAsync("atualizarGridEventosGuard", ret);
                }
            }

            return Ok(new { Message = "Request Completed" });
        }

        [HttpGet]
        [Route("atualizarComboClienteGuard")]
        public IActionResult AtualizarComboClienteGuard([FromQuery] string idUsuario, [FromQuery] string idCliente)
        {
            var connections = _service.ConnectionSignalR.ObterConnections(idUsuario, EnumHubs.ComboClienteGuard);

            foreach (var connectionId in connections)
            {
                _hubCombo.Clients.Client(connectionId).SendAsync("atualizarComboClienteGuard", idCliente);
            }

            return Ok(new { Message = "Request Completed" });
        }
    }
}