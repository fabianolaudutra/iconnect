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
    public class FrotaController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<FrotaController> _logger;

        public FrotaController(ILogger<FrotaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] FrotaViewModel model)
        {
            return Ok(_service.Frota.SalvarVeiculo(model));
        }

        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}")]
        public List<GenericList> GetByCliente(int id)
        {
            return _service.Frota.GetByCliente(id);
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] FrotaFilterModel filter)
        {
            var response = _service.Frota.GetVeiculoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<FrotaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public FrotaViewModel GetVeiculo(int id)
        {
            return _service.Frota.GetVeiculo(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Frota.DeletarVeiculo(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] FrotaFilterModel filter)
        {
            return File(_service.Frota.GeraExcel(filter), "application/ms-excel");
        }

        [HttpPost]
        [Authorize]
        [Route("getVeiculoBuscarFiltrado")]
        public IActionResult GetVeiculoBuscarFiltrado([FromBody] FrotaFilterModel filter)
        {
            var response = _service.Frota.GetVeiculoBuscarFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<FrotaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}