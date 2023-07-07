using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using PagedList;
using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalidadeGrupoFamiliarController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<LocalidadeGrupoFamiliarController> _logger;

        public LocalidadeGrupoFamiliarController(ILogger<LocalidadeGrupoFamiliarController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("getLocalidade")]
        public IActionResult GetLocalidade([FromBody] LocalidadeGrupoFamiliarFilterModel filter)
        {
            var response = _service.LocalidadeGrupoFamiliar.GetLocalidade(filter);
            return Ok(new PagedResponse<IPagedList<LocalidadeGrupoFamiliarViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult SalvarLocalidade([FromBody] LocalidadeGrupoFamiliarViewModel model)
        {
            var result = _service.LocalidadeGrupoFamiliar.SalvarLocalidade(model);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult DeletarLocalidade(int id)
        {
            return Ok(_service.LocalidadeGrupoFamiliar.DeletarLocalidade(id));
        }

        [HttpGet]
        [Authorize]
        [Route("deletarSemGrupo")]
        public IActionResult DeletarLocalidadeSemGrupo()
        {
            return Ok(_service.LocalidadeGrupoFamiliar.DeletarLocalidadeSemGrupo());
        }
    }
}
