using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<CidadeController> _logger;

        public CidadeController(ILogger<CidadeController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Authorize]
        [Route("buscar")]
        public List<CidadeViewModel> Get()
        {
            return _service.Cidade.ListarCidades();
        }

        [HttpGet]
        [Authorize]
        [Route("buscarFiltrado/{id}")]
        public List<CidadeViewModel> GetCidadesFiltrado(int id)
        {
            return _service.Cidade.ListarCidadesFiltrado(id);
        }
    }
}