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
    public class PontosAcessoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<PontosAcessoController> _logger;

        public PontosAcessoController(ILogger<PontosAcessoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("listarPontos/{id}")]
        public IActionResult ListarPontosAcesso(int id)
        {
            return Ok(_service.PontosAcesso.ListarPontosAcesso(id));
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] PontosAcessoFilterModel filter)
        {
            var response = _service.PontosAcesso.GetPontosAcessoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PontosAcessoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] PontosAcessoViewModel model)
        {
            return Ok(_service.PontosAcesso.SalvarPontosAcesso(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.PontosAcesso.DeletarPontosAcesso(id));
        }

        [HttpGet]
        [Authorize]
        [Route("deletarSemControladora")]
        public IActionResult DeletarPontosAcessoSemControladora()
        {
            return Ok(_service.PontosAcesso.DeletarPontosAcessoSemControladora());
        }

        [HttpGet]
        [Authorize]
        [Route("pontoEntrada/{cliente}")]
        public IActionResult pontoEntrada(int cliente)
        {
            return Ok(_service.PontosAcesso.pontoEntrada(cliente));
        }

        [HttpGet]
        [Authorize]
        [Route("pontoSaida/{cliente}")]
        public IActionResult pontoSaida(int cliente)
        {
            return Ok(_service.PontosAcesso.pontoSaida(cliente));
        }

    }
}