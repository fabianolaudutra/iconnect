using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisparoPgmController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<DisparoPgmController> _logger;

        public DisparoPgmController(ILogger<DisparoPgmController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] DisparoPgmViewModel model)
        {
            return Ok(_service.DisparoPgm.SalvarDisparoPgm(model));
        }
    }
}