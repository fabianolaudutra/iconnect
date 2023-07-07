using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentoMoradorController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<DocumentoMoradorController> _logger;

        public DocumentoMoradorController(ILogger<DocumentoMoradorController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarDocumentoMorador([FromBody] DocumentoMoradorViewModel[] model)
        {
            return Ok(_service.DocumentoMorador.InsertOrUpdate(model));
        }
    }
}