using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class DuvidasAppClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<DuvidasAppClienteController> _logger;

        public DuvidasAppClienteController(ILogger<DuvidasAppClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] DuvidasAppViewModel model)
        {
            return Ok(_service.DuvidasApp.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] DuvidasAppFilterModel filter)
        {
            var response = _service.DuvidasApp.GetDuvidasFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<DuvidasAppViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public DuvidasAppViewModel GetDuvida(int id)
        {
            return _service.DuvidasApp.GetDuvida(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarDuvida(int id)
        {
            return Ok(_service.DuvidasApp.DeletarDuvida(id));
        }

        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.DuvidasApp.ExcluirTemporarios());
        }


        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}")]
        public List<DuvidasAppViewModel> GetDuvidasByCliente(int id)
        {
            return _service.DuvidasApp.GetDuvidasByCliente(id);
        }
    }
}