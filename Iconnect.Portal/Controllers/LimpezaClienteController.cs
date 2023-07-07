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
    [Authorize]
    [Route("[controller]")]
    public class LimpezaClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<LimpezaClienteController> _logger;

        public LimpezaClienteController(ILogger<LimpezaClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] LimpezaClienteViewModel model)
        {
            var result = _service.LimpezaCliente.SalvarLimpeza(model);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("salvarByCliente/{idCliente}")]
        public IActionResult SalvayByCliente(int idCliente)
        {
            var result = _service.LimpezaCliente.LimpezaAccessByCliente(idCliente);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.LimpezaCliente.DeletarLimpeza(id));
        }

        [HttpPost]
        [Authorize]
        [Route("buscar")]
        public IActionResult Get([FromBody] LimpezaClienteFilterModel filter)
        {
            var response = _service.LimpezaCliente.ListarLimpezas(filter);
            return Ok(new PagedResponse<IPagedList<LimpezaClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}