using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Iconnect.Aplicacao.FilterModel;
using PagedList;
using System.Linq;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcorrenciasOperadorController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger _logger;

        public OcorrenciasOperadorController(ILogger<OcorrenciasOperadorController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Salvar([FromBody] OcorrenciasOperadorViewModel model)
        {
            return Ok(_service.OcorrenciasOperador.Salvar(model));
        }

        [HttpPost]
        [Authorize]
        [Route("getOcorrenciasOperadorFiltrado")]
        public IActionResult GetOcorrenciasOperadorFiltrado([FromBody] OcorrenciasOperadorFilterModel filter)
        {
            var _user = User.Claims;
            string idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.OcorrenciasOperador.GetOcorrenciasOperadorFiltrado(filter, idsClientes);
            return Ok(new PagedResponse<IPagedList<OcorrenciasOperadorViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("getOcorrenciaOperador/{id}")]
        public IActionResult GetOcorrenciaOperador(int id)
        {
            return Ok(_service.OcorrenciasOperador.GetOcorrenciaOperador(id));
        }

        [HttpPost]
        [Authorize]
        [Route("getRelatorioOcorrenciasOperador")]
        public IActionResult GetRelatorioOcorrenciasOperador([FromBody] OcorrenciasOperadorViewModel model)
        {
            var _user = User.Claims;
            string idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return Ok(_service.OcorrenciasOperador.GetRelatorioOcorrenciasOperador(model, idsClientes));
        }
    }
}