using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladoraController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<ControladoraController> _logger;

        public ControladoraController(ILogger<ControladoraController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] ControladoraFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.Controladora.GetControladoraFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<ControladoraViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] ControladoraFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return File(_service.Controladora.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public ControladoraViewModel GetControladora(int id)
        {
            return _service.Controladora.GetControladora(id);
        }

        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}")]
        public List<ControladoraViewModel> GetControladoraByCliente(int id)
        {
            return _service.Controladora.GetControladoraByCliente(id);
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] ControladoraViewModel model)
        {
            return Ok(_service.Controladora.SalvarControladora(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Controladora.DeletarControladora(id));
        }

        [HttpPost]
        [Authorize]
        [Route("excluirTodosPontosAcesso")]
        public IActionResult ExcluirTodosPontosAcesso([FromBody] ControladoraViewModel model)
        {
            return Ok(_service.Controladora.ExcluirTodosPontosAcesso(model));
        }

        [HttpPost]
        [Authorize]
        [Route("rebindComboPorta")]
        public List<GenericList> RebindComboPorta([FromBody] ControladoraViewModel model)
        {
            return _service.Controladora.RebindComboPorta(model);
        }

        [HttpPost]
        [Authorize]
        [Route("rebindComboFluxo")]
        public List<GenericList> RebindComboFluxo([FromBody] ControladoraViewModel model)
        {
            return _service.Controladora.RebindComboFluxo(model);
        }

        [HttpGet]
        [Authorize]
        [Route("sincronizarControladora/{id}/{idsControladoras}")]
        public bool SalvarSincronizacaoPlacasExterna(int id, string idsControladoras)
        {
            return _service.Controladora.SincronizarAlteracoesPlacas(id, idsControladoras);
        }
    }
}