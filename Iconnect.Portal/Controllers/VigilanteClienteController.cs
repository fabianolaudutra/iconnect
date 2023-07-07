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
    public class VigilanteClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<VigilanteClienteController> _logger;

        public VigilanteClienteController(ILogger<VigilanteClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] VigilanteClienteViewModel model)
        {
            return Ok(_service.VigilanteCliente.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] VigilanteClienteFilterModel filter)
        {
            var response = _service.VigilanteCliente.GetVigilanteFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<VigilanteClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public VigilanteClienteViewModel GetVigilante(int id)
        {
            return _service.VigilanteCliente.GetVigilante(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarVigilante(int id)
        {
            return Ok(_service.VigilanteCliente.DeletarVigilante(id));
        }
        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.VigilanteCliente.ExcluirTemporarios());
        }


        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}")]
        public List<VigilanteClienteViewModel> GetVigilantesByCliente(int id)
        {
            return _service.VigilanteCliente.GetVigilantesByCliente(id);
        }
    }
}