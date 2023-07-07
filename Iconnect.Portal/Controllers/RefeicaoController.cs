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
    public class RefeicaoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<RefeicaoController> _logger;

        public RefeicaoController(ILogger<RefeicaoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult InsertOrUpdate([FromBody] RefeicaoViewModel model)
        {
            return Ok(_service.Refeicao.InsertOrUpdate(model));
        }

        [HttpPost]
        [Authorize]
        [Route("grid")]
        public IActionResult GetFiltrado(RefeicaoFilterModel filter)
        {
            var response = _service.Refeicao.GetFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<RefeicaoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult DeletarRefeicao(int id)
        {
            return Ok(_service.Refeicao.DeletarRefeicao(id));
        }
    }
}