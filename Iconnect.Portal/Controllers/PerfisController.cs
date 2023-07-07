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
    public class PerfisController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<PerfisController> _logger;
        public PerfisController(ILogger<PerfisController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("getAllPerfis")]
        public List<PerfilViewModel> GetAllPerfis()
        {
            return _service.Perfil.GetAllPerfis();
        }
    }
}