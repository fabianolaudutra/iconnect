using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategorizacaoAvisoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<CategorizacaoAvisoController> _logger;

        public CategorizacaoAvisoController(ILogger<CategorizacaoAvisoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] CategorizacaoAvisoFilterModel filter)
        {
            var response = _service.CategorizacaoAviso.GetAvisoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<CategorizacaoAvisoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] CategorizacaoAvisoViewModel model)
        {
            return Ok(_service.CategorizacaoAviso.SalvarAviso(model));
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public CategorizacaoAvisoViewModel Get(int id)
        {
            return _service.CategorizacaoAviso.GetAviso(id);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.CategorizacaoAviso.DeletarAviso(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] CategorizacaoAvisoFilterModel filter)
        {
            return File(_service.CategorizacaoAviso.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("getAll")]
        public List<CategorizacaoAvisoViewModel> GetAll()
        {
            return _service.CategorizacaoAviso.GetAll();
        }
    }
}