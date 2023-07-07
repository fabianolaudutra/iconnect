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
    public class SubCategoriaCatalogoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<CategoriaCatalogoController> _logger;

        public SubCategoriaCatalogoController(ILogger<CategoriaCatalogoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarCategoriaCatalogo([FromBody] SubCategoriaCatalogoViewModel model)
        {
            return Ok(_service.SubCategoriaCatalogo.InserOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] SubCategoriaCatalogoFilterModel filter)
        {
            var response = _service.SubCategoriaCatalogo.GetSubCategoriaCatalogoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<SubCategoriaCatalogoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public SubCategoriaCatalogoViewModel GetCategoriaCatalogo(int id)
        {
            return _service.SubCategoriaCatalogo.GetSubCategoriaCatalogo(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarDuvida(int id)
        {
            return Ok(_service.SubCategoriaCatalogo.DeletarSubCategoriaCatalogo(id));
        }

        [HttpGet]
        [Authorize]
        [Route("buscarPorCliente/{id}")]
        public List<SubCategoriaCatalogoViewModel> GetSubCategoriaCatalogoPorCliente(int id) 
        {
            return _service.SubCategoriaCatalogo.GetSubCategoriaCatalogoPorCliente(id);
        }

        [HttpGet]
        [Authorize]
        [Route("subCategoriaComboPorId/{id}")]
        public List<GenericList> GetSubCategoriaCatalogoComboPorId(int id) 
        {
            return _service.SubCategoriaCatalogo.GetSubCategoriaCatalogoComboPorId(id);
        }
    }
}
