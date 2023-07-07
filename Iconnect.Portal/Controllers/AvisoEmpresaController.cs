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
    public class AvisoEmpresaController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<AvisoEmpresaController> _logger;

        public AvisoEmpresaController(ILogger<AvisoEmpresaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] AvisoEmpresaFilterModel filter)
        {
            var response = _service.AvisoEmpresa.GetAvisoEmpresaFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<AvisoEmpresaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public AvisoEmpresaViewModel Get(int id)
        {
            return _service.AvisoEmpresa.GetAvisoEmpresa(id);
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] AvisoEmpresaViewModel model)
        {
            return Ok(_service.AvisoEmpresa.SalvarAvisoEmpresa(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.AvisoEmpresa.DeletarAvisoEmpresa(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] AvisoEmpresaFilterModel filter)
        {
            return File(_service.AvisoEmpresa.GeraExcel(filter), "application/ms-excel");
        }
    }
}