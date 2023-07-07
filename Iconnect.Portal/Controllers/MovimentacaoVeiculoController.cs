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

    public class MovimentacaoVeiculoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<MovimentacaoVeiculoController> _logger;

        public MovimentacaoVeiculoController(ILogger<MovimentacaoVeiculoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] MovimentacaoVeiculoViewModel model)
        {
            return Ok(_service.MovimentacaoVeiculo.SalvarMovimentacao(model, UsuarioLogado));
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] MovimentacaoVeiculoFilterModel filter)
        {
            var response = _service.MovimentacaoVeiculo.GetMovimentacaoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<MovimentacaoVeiculoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        //[HttpGet]
        //[Route("editar/{id}")]
        //public MovimentacaoVeiculoViewModel GetVeiculo(int id)
        //{
        //    return _service.MovimentacaoVeiculo.GetMovimentacao(id);
        //}
        [HttpGet]
        [Route("buscarUltima/{id}")]
        public IActionResult GetUltima(int id)
        {
            return Ok(_service.MovimentacaoVeiculo.GetUltimaMovimentacao(id));
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.MovimentacaoVeiculo.DeletarMovimentacao(id));
        }

        [HttpPost]
        [Authorize]
        [Route("relatorioAnalitico")]
        public List<RelatorioMovimentacao> RelatorioAnalitico(MovimentacaoVeiculoViewModel model)
        {
            return _service.MovimentacaoVeiculo.RelatorioAnalitico(model);
        }

        [HttpPost]
        [Authorize]
        [Route("relatorioMacro")]
        public List<RelatorioMovimentacao> RelatorioMacro(MovimentacaoVeiculoViewModel model)
        {
            return _service.MovimentacaoVeiculo.RelatorioMacro(model);
        }
    }
}