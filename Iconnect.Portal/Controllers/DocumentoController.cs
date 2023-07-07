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
    public class DocumentoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<DocumentoController> _logger;

        public DocumentoController(ILogger<DocumentoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] DocumentoFilterModel filter)
        {
            var response = _service.Documento.GetDocumentoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<DocumentoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] DocumentoViewModel model)
        {
            return Ok(_service.Documento.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("getsegTrabalhoRel")]
        public IActionResult getSegTrabalhoRel([FromBody] DocumentoFilterModel model)
        {
            return Ok(_service.Documento.GetSegTrabalhoRel(model));
        }

        [HttpGet]
        [Route("editar/{id}")]
        public DocumentoViewModel GetZelador(int id)
        {
            return _service.Documento.GetDocumento(id);
        }

       [HttpGet]
       [Route("getDocSegTrabalho/{id}")] 
       public List<DocumentoViewModel> GetDocSegTrabalho(int id)
        {
            return _service.Documento.GetDocSegTrabalho(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Documento.DeletarDocumento(id));
        }

        [HttpPost]
        [Authorize]
        [Route("getDocumentosByCliMor")]
        public List<DocumentoViewModel> GetDocumentosByCliMor([FromBody] DocumentoFilterModel filter)
        {
            return _service.Documento.GetDocumentosByCliMor(filter);
        }

        [HttpPost]
        [Route("ativarDesativarMon")]
        public IActionResult AtivarDesativarMonitoramentoDocumento([FromBody] DocumentoViewModel model)
        {
            return Ok(_service.Documento.AtivarDesativarMonitoramentoDocumento(model));
        }

        //[HttpGet]
        //[Route("excluirTemp")]
        //public IActionResult ExcluirTemporarios()
        //{
        //    return Ok(_service.Documento.ExcluirTemporarios());
        //}

    }
    }