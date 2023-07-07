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

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategorizacaoEventoController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<CategorizacaoEventoController> _logger;

        public CategorizacaoEventoController(ILogger<CategorizacaoEventoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] CategorizacaoEventoFilterModel filter)
        {
            var response = _service.CategorizacaoEvento.GetCategoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<CategorizacaoEventoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] CategorizacaoEventoViewModel model)
        {
            return Ok(_service.CategorizacaoEvento.SalvarCategorizacaoEvento(model));
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public CategorizacaoEventoViewModel Get(int id)
        {
            return _service.CategorizacaoEvento.GetCategorizacaoEvento(id);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.CategorizacaoEvento.DeletarCategorizacaoEvento(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] CategorizacaoEventoFilterModel filter)
        {
            return File(_service.CategorizacaoEvento.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("getAll")]
        public List<CategorizacaoEventoViewModel> GetAll()
        {
            return _service.CategorizacaoEvento.GetAll();
        }
    }
}