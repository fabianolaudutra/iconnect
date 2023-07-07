

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
    public class EstadoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<EstadoController> _logger;

        public EstadoController(ILogger<EstadoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Authorize]
        [Route("buscar")]
        public List<EstadoViewModel> Get()
        {
            return _service.Estado.ListarEstados();
        }

        [HttpGet]
        [Authorize]
        [Route("buscarFiltrado")]
        public List<EstadoViewModel> GetEstadosFiltrado()
        {
            return _service.Estado.ListarEstadosFiltrado();
        }
    }
}