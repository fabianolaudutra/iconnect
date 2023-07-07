
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
    public class ZoneamentoClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<ZoneamentoClienteController> _logger;

        public ZoneamentoClienteController(ILogger<ZoneamentoClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] ZoneamentoClienteViewModel model)
        {
            return Ok(_service.ZoneamentoCliente.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] ZoneamentoClienteFilterModel filter)
        {
            var response = _service.ZoneamentoCliente.GetZoneamentoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<ZoneamentoClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public ZoneamentoClienteViewModel GetZoneamento(int id)
        {
            return _service.ZoneamentoCliente.GetZoneamento(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarZoneamento(int id)
        {
            return Ok(_service.ZoneamentoCliente.DeletarZoneamento(id));
        }
        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.ZoneamentoCliente.ExcluirTemporarios());
        }
    }
}