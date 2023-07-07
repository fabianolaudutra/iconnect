using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapeamentoPontoAcessoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<MapeamentoPontoAcessoController> _logger;

        public MapeamentoPontoAcessoController(ILogger<MapeamentoPontoAcessoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarMapeamento([FromBody] MapeamentoPontoAcessoViewModel model)
        {
            return Ok(_service.MapeamentoPontoAcesso.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] MapeamentoPontoAcessoFilterModel filter)
        {
            var response = _service.MapeamentoPontoAcesso.GetMapeamentoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<MapeamentoPontoAcessoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public MapeamentoPontoAcessoViewModel GetMapeamento(int id)
        {
            var reultado = _service.MapeamentoPontoAcesso.GetMapeamento(id);
            return reultado;
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarMapeamento(int id)
        {
            return Ok(_service.MapeamentoPontoAcesso.DeletarMapeamento(id));
        }

    }
}