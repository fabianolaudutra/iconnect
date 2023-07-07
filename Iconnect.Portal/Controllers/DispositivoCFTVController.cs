
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
    public class DispositivoCFTVController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<DispositivoCFTVController> _logger;

        public DispositivoCFTVController(ILogger<DispositivoCFTVController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarDispositivo([FromBody] DispositivoCFTVViewModel model)
        {
            return Ok(_service.DispositivoCFTV.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] DispositivoCFTVFilterModel filter)
        {
            var response = _service.DispositivoCFTV.GetDispositivoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<DispositivoCFTVViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public DispositivoCFTVViewModel GetDispositivo(int id)
        {
            return _service.DispositivoCFTV.GetDispositivo(id);
        }

        [HttpGet]
        [Route("GetDispositivoByLayout/{id}")]
        public DispositivoCFTVViewModel GetDispositivoByLayout(int id)
        {
            return _service.DispositivoCFTV.GetDispositivoByLayout(id);
        }

        
        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarVigilante(int id)
        {
            return Ok(_service.DispositivoCFTV.DeletarDispositivo(id));
        }

        [HttpGet]
        [Route("listarDispositivos/{id}")]
        public IActionResult listarDispositivos(int id)
        {
            return Ok(_service.DispositivoCFTV.ListarDispositivos(id));
        }

        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            _service.ZeladorCliente.ExcluirTemporarios();

            return Ok(_service.DispositivoCFTV.ExcluirTemporarios());
        }


    }
}