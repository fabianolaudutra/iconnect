using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Enums;
using Iconnect.Portal.HubConfigs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotivoOcorrenciaController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<MotivoOcorrenciaController> _logger;
        
        public MotivoOcorrenciaController(ILogger<MotivoOcorrenciaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarMotivo([FromBody] MotivoOcorrenciaViewModel model)
        {
            return Ok(_service.MotivoOcorrencia.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] MotivoOcorrenciaFilterModel filter)
        {
            var response = _service.MotivoOcorrencia.GetMotivoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<MotivoOcorrenciaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public MotivoOcorrenciaViewModel GetMotivo(int id)
        {
            return _service.MotivoOcorrencia.GetMotivo(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarMotivo(int id)
        {
            return Ok(_service.MotivoOcorrencia.DeletarMotivo(id));
        }
        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.MotivoOcorrencia.ExcluirTemporarios());
        }

        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}")]
        public List<MotivoOcorrenciaViewModel> GetMotivosByCliente(int id)
        {
            return _service.MotivoOcorrencia.GetMotivosByCliente(id);
        }
    }
}