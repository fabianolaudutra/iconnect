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
    public class PessoasRecintoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<PessoasRecintoController> _logger;

        public PessoasRecintoController(ILogger<PessoasRecintoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] PessoasRecintoFilterModel filter)
        {
            var response = _service.PessoasRecinto.GetPessoasRecintoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PessoasRecintoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] PessoasRecintoFilterModel filter)
        {
            return File(_service.PessoasRecinto.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("getPessoaRecinto/{id}")]
        public PessoasRecintoViewModel getPessoaRecinto(int id)
        {
            return _service.PessoasRecinto.GetPessoaRecinto(id);
        }
        
       
        [HttpPost]
        [Authorize]
        [Route("limpaRecintoGeral")]
        public IActionResult limpaRecintoGeral([FromBody] PessoasRecintoViewModel model)
        {
            return Ok(_service.PessoasRecinto.limpaRecintoGeral(model));
        }

        [HttpPost]
        [Authorize]
        [Route("limpaRecintoIndividual")]
        public IActionResult limpaRecintoIndividual([FromBody] PessoasRecintoViewModel model)
        {
            return Ok(_service.PessoasRecinto.limpaRecintoIndividual(model));
        }

    }
}