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

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilHorarioController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<PerfilHorarioController> _logger;

        public PerfilHorarioController(ILogger<PerfilHorarioController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}/{tipoPessoa}")]
        public List<PerfilHorarioViewModel> Get(int id, string tipoPessoa)
        {
            return _service.PerfilHorario.GetPerfilHorarioByCliente(id, tipoPessoa);
        }
        [HttpGet]
        [Authorize]
        [Route("getByClienteFilter/{id}")]
        public List<PerfilHorarioViewModel> getByClienteFilter(int id)
        {
            return _service.PerfilHorario.GetPerfilHorarioFilter(id);
        }
        [HttpGet]
        [Authorize]
        [Route("getByClienteFiltrado/{id}")]
        public List<PerfilHorarioViewModel> getByClienteFiltrado(int id)
        {
            return _service.PerfilHorario.GetPerfilHorarioByClienteFiltrado(id);
        }
        
        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] PerfilHorarioFilterModel filter)
        {
            var response = _service.PerfilHorario.GetPerfilHorarioFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PerfilHorarioViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] PerfilHorarioViewModel model)
        {
            return Ok(_service.PerfilHorario.SalvarPerfilHorario(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                return Ok(_service.PerfilHorario.DeletarPerfilHorario(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getPerfilHorario/{id}")]
        public PerfilHorarioViewModel getPerfilHorario(string id)
        {
            return _service.PerfilHorario.GetPerfilHorario(id);
        }
    }
}