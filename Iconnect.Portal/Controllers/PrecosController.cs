using Iconnect.Aplicacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Aplicacao.FilterModel;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrecosController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<PrecosController> _logger;

        public PrecosController(ILogger<PrecosController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Salvar(PrecosViewModel model)
        {
            return Ok(_service.Precos.Salvar(model));
        }

        [HttpGet]
        [Authorize]
        [Route("getPrecos")]
        public IActionResult GetPrecos()
        {
            return Ok(_service.Precos.GetPrecos());
        }

        [HttpPost]
        [Authorize]
        [Route("getExcel")]
        public IActionResult GeraExcel(FaturamentoFilterModel filter)
        {
            return File(_service.Precos.GeraExcel(filter), "application/ms-excel");
        }
    }
}
