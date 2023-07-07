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
    public class LayoutController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<LayoutController> _logger;

        public LayoutController(ILogger<LayoutController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            _service.Layout.ExcluirTemporarios();

            return Ok(_service.DispositivoCFTV.ExcluirTemporarios());
        }
    }
}