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
    public class CatalogoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<CatalogoController> _logger;

        public CatalogoController(ILogger<CatalogoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        
        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarCatalogo([FromBody] CatalogoViewModel model)
        { 
            return Ok(_service.Catalogo.InserOrUpdate(model));
        }

        [HttpPost]
        [Route("updateStatus")]
        public IActionResult UpdateStatus([FromBody] CatalogoViewModel model)
        {
            return Ok(_service.Catalogo.UpdateStatus(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] CatalogoFilterModel filter)
        {
            var response = _service.Catalogo.GetCatalogoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<CatalogoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("getFilteredByGrupoFamiliar")]
        public IActionResult GetFilteredByGrupoFamiliar([FromBody] CatalogoFilterModel filter)
        {
            var response = _service.Catalogo.GetFilteredByGrupoFamiliar(filter);
            return Ok(new PagedResponse<IPagedList<CatalogoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public CatalogoViewModel GetCatalogo(int id)
        {
            return _service.Catalogo.GetCatalogo(id);
        }

        [HttpGet]
        [Route("editarCatalog/{id}")]
        public CatalogoViewModel GetCatalogoGrupoFamiliar(int id)
        {
            return _service.Catalogo.GetCatalogoGrupo(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarCatalogo(int id)
        {
            return Ok(_service.Catalogo.DeletarCatalogo(id));
        }

        [HttpGet]
        [Authorize]
        [Route("buscarPorCliente/{id}")]
        public List<CatalogoViewModel> GetCategoriaCatalogoPorCliente(int id)
        {
            return _service.Catalogo.GetCatalogoPorCliente(id);
        }

        [HttpGet]
        [Route("getCatalogoByGrupoFamiliar/{id}")]
        public List<CatalogoViewModel> getCatalogoByGrupoFamiliar(int id)
        {
            return _service.Catalogo.GetCatalogoByGrupo(id);
        }

        [HttpGet]
        [Route("validaQuantidadeCatalogos/{id}")]
        public IActionResult validaQuantidadeCatalogos(int id)
        {
            return Ok(_service.Catalogo.validaQuantidadeCatalogos(id));
        }

        [HttpGet]
        [Route("validaPrimeiroCatalogo/{idGrupo}/{idCal}")]
        public IActionResult validaPrimeiroCatalogo(int idGrupo, int idCal)
        {
            return Ok(_service.Catalogo.validaPrimeiroCatalogo(idGrupo, idCal));
        }
    }
}
