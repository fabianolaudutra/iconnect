using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoVagasController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<GrupoVagasController> _logger;

        public GrupoVagasController(ILogger<GrupoVagasController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] GrupoVagasFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.GrupoVagas.GetGrupoVagasFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<GrupoVagasViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] GrupoVagasViewModel model)
        {
            return Ok(_service.GrupoVagas.SalvarGrupoVagas(model));
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public GrupoVagasViewModel Get(int id)
        {
            return _service.GrupoVagas.GetGrupoVagas(id);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.GrupoVagas.DeletarGrupoVagas(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] GrupoVagasFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return File(_service.GrupoVagas.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}")]
        public List<GrupoVagasViewModel> GetByCliente(int id)
        {
            return _service.GrupoVagas.GetGrupoVagasByCliente(id);
        }
    }
}