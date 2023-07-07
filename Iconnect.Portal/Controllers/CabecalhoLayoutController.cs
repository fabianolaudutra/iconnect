using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CabecalhoLayoutController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<CabecalhoLayoutController> _logger;

        public CabecalhoLayoutController(ILogger<CabecalhoLayoutController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("listarLayout/{id}")]
        public IActionResult listarLayout(int id)
        {

            return Ok(_service.CabecalhoLayout.ListarLayout(id));
        }
        [HttpGet]
        [Route("listarDispositivoCanal/{id}")]
        public IActionResult ListarDispositivoCanal(int id)
        {

            return Ok(_service.CabecalhoLayout.ListarDispositivoCanal(id));
        }
        [HttpGet]
        [Route("listarCanais/{id}")]
        public IActionResult listarCanais(int id)
        {

            return Ok(_service.CabecalhoLayout.ListarCanais(id)); 
        }
        [HttpGet]
        [Route("listarCanaisByLayout/{id}")]
        public IActionResult listarByLayoutCanais(int id)
        {

            return Ok(_service.CabecalhoLayout.ListarCanaisByLayout(id));
        }
        [HttpPost]
        [Route("listarCanaisByDispositivo")]
        public IActionResult listarByLayoutCanaisDispositivo([FromBody] CabecalhoLayoutViewModel model)
        {
            return Ok(_service.CabecalhoLayout.ListarCanaisByDispositivo(model));
        }
        [HttpPost]
        [Route("salvar")]
        public IActionResult InsertOrUpdate([FromBody] CabecalhoLayoutViewModel model)
        {

            return Ok(_service.CabecalhoLayout.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetLayoutFiltrado([FromBody] CabecalhoLayoutFilterModel filter)
        {
            var response = _service.CabecalhoLayout.GetLayoutFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<CabecalhoLayoutViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public CabecalhoLayoutViewModel GetLayout(int id)
        {
            return _service.CabecalhoLayout.GetLayout(id);
        }


        [HttpGet]
        [Route("getLayoutPadrao/{id}")]
        public List<CabecalhoLayoutViewModel> GetLayoutPadrao(int id)
        {
            return _service.CabecalhoLayout.GetLayoutPadrao(id);
        }

        
        [HttpGet]
        [Route("getLayoutPadraoFiltered/{id}")]
        public List<CabecalhoLayoutViewModel> GetLayoutPadraoFiltered(int id)
        {
            return _service.CabecalhoLayout.GetLayoutPadraoFiltered(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarLayout(int id)
        {
            return Ok(_service.CabecalhoLayout.DeletarLayout(id));
        }

        [HttpGet]
        [Route("GetLayoutGuardByCliente/{id}")]
        public IActionResult GetLayoutGuardByCliente(int id)
        {

            return Ok(_service.CabecalhoLayout.GetLayoutGuardByCliente(id));
        }

        [HttpGet]
        [Route("GetLayoutGuardByLayout/{id}")]
        public IActionResult GetLayoutGuardByLayout(int id)
        {

            return Ok(_service.CabecalhoLayout.GetLayoutGuardByLayout(id));
        }

        [HttpGet]
        [Route("GetLayoutsGuardModalByCliente/{id}")]
        public IActionResult GetLayoutsGuardModalByCliente(int id)
        {

            return Ok(_service.CabecalhoLayout.GetLayoutsGuardModalByCliente(id));
        }

        [HttpGet]
        [Route("GetLayoutsViewModalByCliente/{id}")]
        public IActionResult GetLayoutsViewModalByCliente(int id)
        {

            return Ok(_service.CabecalhoLayout.GetLayoutsViewModalByCliente(id));
        }
    }
}