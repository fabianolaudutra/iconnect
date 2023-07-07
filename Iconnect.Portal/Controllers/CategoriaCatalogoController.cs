using Iconnect.Aplicacao;
using Microsoft.AspNetCore.Http;
using Iconnect.Aplicacao.FilterModel;
using Microsoft.AspNetCore.Authorization;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaCatalogoController : PadraoController
    {
        private readonly IServiceWrapper _service;
        
        private readonly ILogger<CategoriaCatalogoController> _logger;

        public CategoriaCatalogoController(ILogger<CategoriaCatalogoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarCategoriaCatalogo([FromBody] CategoriaCatalogoViewModel model)
        {
           return Ok(_service.CategoriaCatalogo.InserOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] CategoriaCatalogoFilterModel filter)
        {
            var response = _service.CategoriaCatalogo.GetCategoriaCatalogoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<CategoriaCatalogoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

      

        [HttpGet]
        [Route("editar/{id}")]
        public CategoriaCatalogoViewModel GetCategoriaCatalogo(int id)
        {
            return _service.CategoriaCatalogo.GetCategoriaCatalogo(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarDuvida(int id)
        {
            return Ok(_service.CategoriaCatalogo.DeletarCategoriaCatalogo(id));
        }

        [HttpGet]
        [Authorize]
        [Route("buscarPorCliente/{id}")]
        public List<CategoriaCatalogoViewModel> GetCategoriaCatalogoPorCliente(int id) 
        {
            return _service.CategoriaCatalogo.GetCategoriaCatalogoPorCliente(id);
        }

        [HttpGet]        
        [Route("categoriaCombo/{id}")]
        public List<GenericList> GetCategoriaComboBox(int id)
        {
            return _service.CategoriaCatalogo.GetCatalogoSemLink(id); 
        }

        [HttpGet]
        [Route("categoriaComboSemLink/{id}")]
        public List<CategoriaCatalogoViewModel> GetComboCatalogoSemLink(int id)
        {
            return _service.CategoriaCatalogo.GetComboCatalogoSemLink(id);
        }
        [HttpGet]
        [Authorize]
        [Route("categoriaComboPor/{id}")]
        public List<GenericList> GetCategoriaCatalogoComboPorId(int id)
        {
            return _service.CategoriaCatalogo.GetCategoriaCatalogoComboPorId(id);
        }
    }
}
