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
    public class PermissionamentoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<PermissionamentoController> _logger;

        public PermissionamentoController(ILogger<PermissionamentoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public PermissionamentoViewModel Get(Guid id)
        {
            return _service.Permissionamento.ObterDadosPermissionamento(id).FirstOrDefault();
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] PermissionamentoViewModel model)
        {
            return Ok(_service.Permissionamento.SalvarPermissionamento(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(Guid id)
        {
            return Ok(_service.Permissionamento.DeletarPermissionamento(id));
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult Get([FromBody] PermissionamentoFilterModel filter)
        {
            var response = _service.Permissionamento.GetPermissionamentosFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PermissionamentoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}