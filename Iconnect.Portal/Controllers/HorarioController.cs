using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorarioController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<HorarioController> _logger;

        public HorarioController(ILogger<HorarioController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }
        
        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] HorarioFilterModel filter)
        {
            var response = _service.Horario.GetHorarioFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<HorarioViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] HorarioViewModel model)
        {
            return Ok(_service.Horario.SalvarHorario(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                return Ok(_service.Horario.DeletarHorario(id));
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint")) {
                    return StatusCode(500, "Não foi possível remover o registro de horário por existirem perfis relacionados a ele.");
                }
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("listarHorarios/{id}")]
        public IActionResult ListarHorarios(int id)
        {
            return Ok(_service.Horario.ListarHorarios(id));
        }
    }
}