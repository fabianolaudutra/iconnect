using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Enums;
using Iconnect.Portal.HubConfigs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao.Interfaces.Queries;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonitoramentoControleAcessoController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly IMonitoramentoControleAcessoQuerie _monitoramentoControleAcessoQuerie;

        private readonly ILogger<MonitoramentoControleAcessoController> _logger;
        public IHubContext<ControleDeAcessoHub> _hub;

        public MonitoramentoControleAcessoController(ILogger<MonitoramentoControleAcessoController> logger, IServiceWrapper service, IHttpContextAccessor acessor, 
            IHubContext<ControleDeAcessoHub> hub, IMonitoramentoControleAcessoQuerie monitoramentoControleAcessoQuerie) : base(acessor)
        {
            _logger = logger;
            _service = service;
            _hub = hub;
            _monitoramentoControleAcessoQuerie = monitoramentoControleAcessoQuerie;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] MonitoramentoControleAcessoFilterModel filter)
        {
            var _user = User.Claims;
            filter.IdsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.MonitoramentoControleAcesso.GetMonitoramentoControleAcessoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<MonitoramentoControleAcessoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("aberturaRemota")]
        public IActionResult DispararAberturaRemota([FromBody] SolicitacaoAberturaRemotaViewModel model)
        {
            if (string.IsNullOrEmpty(model.sol_c_usuarioSolicitou))
            {
                model.sol_c_usuarioSolicitou = UsuarioLogado.ToUpper();
            }

            return Ok(_service.MonitoramentoControleAcesso.DispararAberturaRemota(model));
        }

        [HttpGet]
        [Authorize]
        [Route("buscarById/{id}")]
        public MonitoramentoControleAcessoViewModel GetAcesso(int id)
        {
            return _service.MonitoramentoControleAcesso.GetAcesso(id);
        }

        [HttpPost]
        [Authorize]
        [Route("salvarTratamentoPanico")]
        public IActionResult SalvarTratamentoPanico([FromBody] MonitoramentoControleAcessoViewModel model)
        {
            model.con_c_UsuarioTratamentoPanico = UsuarioLogado.ToUpper();

            return Ok(_service.MonitoramentoControleAcesso.SalvarTratamentoPanico(model));
        }

        [HttpPost]
        [Authorize]
        [Route("getRelControleAcesso")]
        public List<MonitoramentoControleAcessoViewModel> getRelControleAcesso(MonitoramentoControleAcessoViewModel model)
        {
            return _service.MonitoramentoControleAcesso.getRelatorioControleAcesso(model);
        }

        [HttpPost]
        [Authorize]
        [Route("getRelatorioDestino")]
        public List<MonitoramentoControleAcessoViewModel> getRelatorioDestino(MonitoramentoControleAcessoViewModel model)
        {
            return _service.MonitoramentoControleAcesso.getRelatorioDestino(model);
        }

        [HttpGet]
        [Route("atualizarControleDeAcesso")]
        public IActionResult AtualizarControleDeAcesso(string idCliente)
        {
            var connections = _service.ConnectionSignalR.ObterConnections(idCliente, EnumHubs.ControleDeAcesso);

            int.TryParse(idCliente, out int _idCliente);

            var acesso = _monitoramentoControleAcessoQuerie.GetAcessoAtualizacaoGrid(_idCliente);

            foreach (var connectionId in connections)
            {
                _hub.Clients.Client(connectionId).SendAsync("atualizarControleDeAcesso", acesso);
            }

            return Ok(new { Message = "Request Completed", Dados = acesso });
        }

        [HttpPost]
        [Authorize]
        [Route("getRelRefeitorio")]
        public IActionResult GetRelRefeitorio([FromBody] MonitoramentoControleAcessoViewModel model)
        {
            return File(_service.MonitoramentoControleAcesso.GetRelRefeitorio(model), "application/ms-excel");
        }

        [HttpPost]
        [Authorize]
        [Route("getAcessosPorPessoa")]
        public IActionResult GetAcessosPorPessoa([FromBody] MonitoramentoControleAcessoFilterModel filter)
        {
            var response = _service.MonitoramentoControleAcesso.GetAcessosPorPessoa(filter);
            return Ok(new PagedResponse<IPagedList<MonitoramentoControleAcessoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}