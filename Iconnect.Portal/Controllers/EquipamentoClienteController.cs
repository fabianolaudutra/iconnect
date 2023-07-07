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
    public class EquipamentoClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<EquipamentoClienteController> _logger;

        public EquipamentoClienteController(ILogger<EquipamentoClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([System.Web.Http.FromBody] EquipamentoClienteViewModel model)
        {
            var result = _service.EquipamentoCliente.InsertOrUpdate(model);
            return Ok(result);
        }
        [HttpGet]
        [Route("buscar/{id}")]
        public EquipamentoClienteViewModel GetEquipamento(int id)
        {
            return _service.EquipamentoCliente.GetEquipamento(id);
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] EquipamentoClienteFiltermodel filter)
        {
            var response = _service.EquipamentoCliente.GetEquipamentoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<EquipamentoClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.EquipamentoCliente.DeletarEquipamento(id));
        }

        [HttpGet]
        [Route("listarCentrais/{id}")]
        public IActionResult ListarCentrais(int id)
        {
            var retorno = _service.EquipamentoCliente.ListarCentrais(id);
            return Ok(retorno);
        }

        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.EquipamentoCliente.ExcluirTemporarios());
        }

    }
}