using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Aplicacao.FilterModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Iconnect.Infraestrutura.Enums;
using Iconnect.Portal.Helpers.HubConfigs;
using Microsoft.AspNetCore.SignalR;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolicitarZeladorController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<SolicitarZeladorController> _logger;
        public IHubContext<ControleOcorrenciaHub> _hub;

        public SolicitarZeladorController(ILogger<SolicitarZeladorController> logger, IServiceWrapper service, IHttpContextAccessor acessor, IHubContext<ControleOcorrenciaHub> hub) : base(acessor)
        {
            _logger = logger;
            _service = service;
            _hub = hub;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] SolicitarZeladorFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.SolicitarZelador.GetSolicitarZeladorFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<SolicitarZeladorViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] SolicitarZeladorFilterModel filter)
        {
            return File(_service.SolicitarZelador.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("buscarById/{id}")]
        public SolicitarZeladorViewModel GetOcorrencia(int id)
        {
            var retorno = _service.SolicitarZelador.GetOcorrencia(id);
            return retorno;
        }

        [HttpPost]
        [Authorize]
        [Route("salvarTratamentoOcorrencia")]
        public IActionResult SalvarTratamentoOcorrencia([FromBody] SolicitarZeladorViewModel model)
        {
            //model.con_c_UsuarioTratamentoPanico = UsuarioLogado.ToUpper(); salvar quem fez o atendimento
            return Ok(_service.SolicitarZelador.SalvarTratamentoOcorrencia(model));
        }

        [Authorize]
        [Route("getFoto/{id}")]
        public byte[] GetFoto(int id)
        {
            return _service.SolicitarZelador.GetFoto(id);
        }

        [HttpGet]
        [Route("atualizarControleOcorrencia")]
        public IActionResult AtualizarControleDeOcorrencia(string ocorrenciaId)
        {
            int.TryParse(ocorrenciaId, out int _ocorrenciaId);

            var ocorrencia = _service.SolicitarZelador.GetOcorrenciaAtualizacaoGrid(_ocorrenciaId);

            if (ocorrencia != null)
            {
                var connections = _service.ConnectionSignalR.ObterConnections(ocorrencia.cli_n_codigo.ToString(), EnumHubs.ControleOcorrencia);
                foreach (var connectionId in connections)
                {
                    _hub.Clients.Client(connectionId).SendAsync("atualizarControleOcorrencia", ocorrencia);
                }
                return Ok(new { Message = "Request Completed" });
            }
            else
            {
                return NotFound(new { Message = "Not Found " });
            }
        }
    }
}