using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistribuidorController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<DistribuidorController> _logger;

        public DistribuidorController(ILogger<DistribuidorController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult InsertOrUpdate(DistribuidorViewModel model)
        {
            return Ok( _service.Distribuidor.InsertOrUpdate(model));
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] DistribuidorFilterModel filter)
        {
            var response = _service.Distribuidor.GetDistribuidorFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<DistribuidorViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Distribuidor.Deletar(id));
        }

        [HttpGet]
        [Authorize]
        [Route("buscar")]
        public IActionResult GetDistribuidor()
        {
            return Ok(_service.Distribuidor.GetDistribuidor());
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public DistribuidorViewModel GetDistribuidorEditar(int id)
        {
            return _service.Distribuidor.GetDistribuidorEditar(id);
        }
    }
}
