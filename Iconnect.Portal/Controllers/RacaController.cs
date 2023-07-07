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
    public class RacaController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<RacaController> _logger;

        public RacaController(ILogger<RacaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] RacaFilterModel filter)
        {
            var response = _service.Raca.GetRacaFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<RacaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] RacaViewModel model)
        {
            return Ok(_service.Raca.SalvarRaca(model));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] RacaFilterModel filter)
        {
            return File(_service.Raca.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public RacaViewModel Get(int id)
        {
            return _service.Raca.GetRaca(id);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Raca.DeletarRaca(id));
        }
        
        [HttpGet]
        [Authorize]
        [Route("getAll")]
        public List<RacaViewModel> Get()
        {
            return _service.Raca.GetAllRaca();
        }
    }
}