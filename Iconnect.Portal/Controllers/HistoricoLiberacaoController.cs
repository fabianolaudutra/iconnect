using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoLiberacaoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<HistoricoLiberacaoController> _logger;
        public HistoricoLiberacaoController(ILogger<HistoricoLiberacaoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] HistoricoLiberacaoViewModel model)
        {
            return Ok(_service.HistoricoLiberacao.SalvarHistorico(model));
        }

    }
}