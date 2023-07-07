
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
    public class ModuloController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<ModuloController> _logger;

        public ModuloController(ILogger<ModuloController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public ModuloViewModel GetModulos(int id)
        {
            return _service.Modulo.GetModulos(id);
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Post([FromBody] ModuloViewModel model)
        {
            return Ok(_service.Modulo.InsertOrUpdate(model));
        }
    }
}