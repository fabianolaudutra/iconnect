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
using Iconnect.Portal.HubConfigs;
using Microsoft.AspNetCore.SignalR;
using Iconnect.Infraestrutura.Enums;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioAppController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<UsuarioAppController> _logger;
        public IHubContext<LiberacaoAppHub> _hub;

        public UsuarioAppController(ILogger<UsuarioAppController> logger, IServiceWrapper service, IHttpContextAccessor acessor, IHubContext<LiberacaoAppHub> hub) : base(acessor)
        {
            _logger = logger;
            _service = service;
            _hub = hub;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([System.Web.Http.FromBody] UsuarioAppFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.UsuarioApp.GetUsuarioAppFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<UsuarioAppViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
        [HttpPost]
        [Authorize]
        [Route("salvarLiberacoesUsuario")]
        public IActionResult SalvarLiberacoesUsuario([FromBody] UsuarioAppViewModel model)
        {
            return Ok(_service.UsuarioApp.SalvarLiberacoesUsuario(model));
        }
        [HttpGet]
        [Authorize]
        [Route("buscarById/{id}")]
        public UsuarioAppViewModel GetLiberacoesUsuario(int id)
        {
            var retorno = _service.UsuarioApp.GetLiberacoesUsuario(id);
            return retorno;
        }

        [HttpGet]
        [Authorize]
        [Route("deleteUsuario/{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            return Ok(_service.UsuarioApp.deleteUsuario(id));
        }

        [HttpGet]
        [Route("atualizarLiberacaoApp")]
        public IActionResult AtualizarLiberacaoApp(string idCliente)
        {
            var connections = _service.ConnectionSignalR.ObterConnections(idCliente, EnumHubs.LiberacaoApp);

            int.TryParse(idCliente, out int _idCliente);
            var dados = _service.UsuarioApp.GetLiberacaoAtualizacaoGrid(_idCliente);

            foreach (var connectionId in connections)
            {
                _hub.Clients.Client(connectionId).SendAsync("atualizarLiberacaoApp", dados);
            }

            return Ok(new { Message = "Request Completed" });
        }
    }
}