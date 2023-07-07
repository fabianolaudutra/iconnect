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
    public class SolicitacaoAberturaRemotaController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<SolicitacaoAberturaRemotaController> _logger;

        public SolicitacaoAberturaRemotaController(ILogger<SolicitacaoAberturaRemotaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("exibirSolicitacaoAberturaRemota")]
        public IActionResult ExibirSolicitacaoAberturaRemota([FromBody] SolicitacaoAberturaRemotaFilterModel filter)
        {
            var response = _service.SolicitacaoAberturaRemota.ExibirSolicitacaoAberturaRemota(filter);
            return Ok(new PagedResponse<IPagedList<SolicitacaoAberturaRemotaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("excluirSolicitacoes")]
        public IActionResult ExcluirSolicitacoes()
        {
            return Ok(_service.SolicitacaoAberturaRemota.ExcluirSolicitacoes());
        }

        [HttpGet]
        [Authorize]
        [Route("getFoto/{id}")]
        public RetornoFotoViewModel GetFoto(int id)
        {
            return _service.Foto.GetFoto(id);
        }
    }
}
