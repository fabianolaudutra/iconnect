using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<AgendaController> _logger;

        public AgendaController(ILogger<AgendaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Post([FromBody] AgendaViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                var user = User.Claims;
                var usuarioLogado = user.FirstOrDefault(x => x.Type == "name").Value;
                _service.Agenda.SalvarAgendamento(model, usuarioLogado);
                ret.Success = "Dados salvos com sucesso.";

                return Ok(ret);
            }
            catch (MensagemException ex)
            {
                ret.Error = ex.Message;
                return Ok(ret);
            }
            catch (Exception ex)
            {
                ret.Error = "Ocorreu um erro ao salvar os dados";
                return Ok(ret);
            }
        }
        
        [HttpGet]
        [Authorize]
        [Route("getAllAgenda/{id}")]
        public List<AgendaViewModel> GetAllAgenda(int id)
        {
            return _service.Agenda.GetAllAgenda(id);
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public AgendaViewModel GetAgenda(int id)
        {
            return _service.Agenda.GetAgenda(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarAgendamento(int id)
        {
            return Ok(_service.Agenda.DeletarAgendamento(id));
        }

        [HttpPost]
        [Route("disponivel")]
        public IActionResult GetProximoDisponivel(AgendaViewModel model)
        {
            return Ok(_service.Agenda.GetProximoDisponivel(model));
        }
    }
}