
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RamalLayoutController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<RamalLayoutController> _logger;

        public RamalLayoutController(ILogger<RamalLayoutController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarRamalLAyout([FromBody] RamalLayoutViewModel model)
        {
            return Ok(_service.RamalLayout.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] RamalLayoutFilterModel filter)
        {
            var response = _service.RamalLayout.GetRamalLayoutFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<RamalLayoutViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public RamalLayoutViewModel GetRamalLayout(int id)
        {
            return _service.RamalLayout.GetRamalLayout(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarRamalLayout(int id)
        {
            return Ok(_service.RamalLayout.DeletarRamalLayout(id));
        }

    }
}