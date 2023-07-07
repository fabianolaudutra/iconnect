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
    public class InformacoesClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<InformacoesClienteController> _logger;

        public InformacoesClienteController(ILogger<InformacoesClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] InformacoesClienteFilterModel filter)
        {
            var response = _service.InformacoesCliente.GetInformacoesClienteFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<InformacoesClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("buscarById/{id}")]
        public InformacoesClienteViewModel GetInformacoesCliente(int id)
        {
            var retorno = _service.InformacoesCliente.GetInformacoesCliente(id);
            return retorno;
        }

        [HttpPost]
        [Authorize]
        [Route("salvarInformacoesCliente")]
        public IActionResult SalvarTratamentoOcorrencia([FromBody] InformacoesClienteViewModel model)
        {
            return Ok(_service.InformacoesCliente.SalvarInformacoesCliente(model));
        }
    }
}