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
    public class PermissaoClienteController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<PermissaoClienteController> _logger;

        public PermissaoClienteController(ILogger<PermissaoClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] PermissaoClienteFilterModel filter)
        {
            var response = _service.PermissaoCliente.GetPermissaoClienteFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PermissaoClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] PermissaoClienteViewModel model)
        {
            return Ok(_service.PermissaoCliente.SalvarPermissaoCliente(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.PermissaoCliente.DeletarPermissaoCliente(id));
        }


        [HttpGet]
        [Authorize]
        [Route("deletarSemOperador")]
        public IActionResult DeletarPermissaoClienteSemOperador()
        {
            return Ok(_service.PermissaoCliente.DeletarPermissaoClienteSemOperador());
        }
    }
}