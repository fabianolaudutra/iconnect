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
    public class CepController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<CepController> _logger;
        public CepController(ILogger<CepController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("buscarFiltrado/{cep}")]
        public CepVielModel GetClienteFiltrado(string cep)
        {
            return _service.Cep.BuscaCep(cep);
        }
    }
}