using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Aplicacao.FilterModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Iconnect.Aplicacao.Interfaces;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PgmController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<PgmController> _logger;

        public PgmController(ILogger<PgmController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetPgcFiltrado([FromBody] PgcFiltermodel filter)
       {
            var response = _service.Pgm.GetPgcFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PgcViewModel>>() { Data = response, Total = response.TotalItemCount });

        }

        [HttpGet]
        [Route("listarPgm/{id}")]
        public IActionResult ListarPgm(int id)
        {
            return Ok(_service.Pgm.ListarPgm(id));
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([System.Web.Http.FromBody] PgcViewModel model)
        {
            var result = _service.Pgm.InsertOrUpdate(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("editarPgc/{id}")]
        public PgcViewModel GetPgc(int id)
        {
            var result = _service.Pgm.GetPgc(id);
            return result;
        }

        [HttpGet]
        [Route("deletarPgc/{id}")]
      
        public IActionResult DeletarPgc(int id)
        {
            return Ok(_service.Pgm.DeletarPgc(id));
        }
        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            _service.ZeladorCliente.ExcluirTemporarios();

            return Ok(_service.DispositivoCFTV.ExcluirTemporarios());
        }

        [HttpGet]
        [Route("listarPgmByEquipamento/{id}")]
        public IActionResult GetPgcByEquipamento(int id)
        {
            return Ok(_service.Pgm.GetPgcByEquipamento(id));
        }
    }
}