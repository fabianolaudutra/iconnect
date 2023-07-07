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
    public class AvisoGrupoFamiliarController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<AvisoGrupoFamiliarController> _logger;

        public AvisoGrupoFamiliarController(ILogger<AvisoGrupoFamiliarController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] AvisoGrupoFamiliarFilterModel filter)
        {
            var response = _service.AvisoGrupoFamiliar.GetAvisoGrupoFamiliarFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<AvisoGrupoFamiliarViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] AvisoGrupoFamiliarViewModel model)
        {
            return Ok(_service.AvisoGrupoFamiliar.SalvarAvisoGrupoFamiliar(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.AvisoGrupoFamiliar.DeletarAvisoGrupoFamiliar(id));
        }


        [HttpGet]
        [Authorize]
        [Route("deletarSemGrupo")]
        public IActionResult DeletarAvisoGrupoFamiliarSemGrupo()
        {
            return Ok(_service.AvisoGrupoFamiliar.DeletarAvisoGrupoFamiliarSemGrupo());
        }
    }
}