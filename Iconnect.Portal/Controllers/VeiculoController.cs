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
    public class VeiculoController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<VeiculoController> _logger;

        public VeiculoController(ILogger<VeiculoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] VeiculoFilterModel filter)
        {
            var response = _service.Veiculo.GetVeiculoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<VeiculoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] VeiculoViewModel model)
        {
            return Ok(_service.Veiculo.SalvarVeiculo(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Veiculo.DeletarVeiculo(id));
        }


        [HttpGet]
        [Authorize]
        [Route("deletarSemGrupo")]
        public IActionResult DeletarVeiculoSemGrupo()
        {
            return Ok(_service.Veiculo.DeletarVeiculoSemGrupo());
        }

        [HttpPost]
        [Authorize]
        [Route("getVeiculoBuscarFiltrado")]
        public IActionResult GetVeiculoBuscarFiltrado([FromBody] VeiculoFilterModel filter)
        {
            var response = _service.Veiculo.GetVeiculoBuscarFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<VeiculoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("getVeiculoGrupoFamiliar/{id}")]
        public IActionResult GetVeiculoGrupoFamiliar(int id)
        {
            return Ok(_service.Veiculo.GetVeiculoGrupoFamiliar(id));
        }
    }
}