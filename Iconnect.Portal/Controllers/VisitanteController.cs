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
using Iconnect.Infraestrutura.Exceptions;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitanteController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<VisitanteController> _logger;

        public VisitanteController(ILogger<VisitanteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("buscarById/{id}")]
        public VisitanteViewModel GetVisitante(int id)
        {
            return _service.Visitante.GetVisitante(id);
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] VisitanteViewModel model)
        {
            var retorno = new RetornoViewModel();
            try
            {
                var ret = _service.Visitante.SalvarVisitante(model);
                retorno.Success = "Dados salvos com sucesso.";
                retorno.Entidade = ret;
                return Ok(retorno);
            }
            catch (MensagemException ex)
            {
                retorno.Error = ex.Message;
                retorno.Entidade = null;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.Error = "Ocorreu um erro ao salvar os dados do Visitante.";
                return Ok(retorno);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var agendamentos = _service.Agenda.AgendamentosVisitante(id);
            foreach (var agendamento in agendamentos)
            {
                _service.Agenda.DeletarAgendamento(agendamento);
            }
            return Ok(_service.Visitante.Deletar(id));
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] VisitanteFilterModel filter)
        {
            var response = _service.Visitante.GetVisitanteFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<VisitanteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("GetVisitanteCPF")]
        public IActionResult GetVisitanteCPF([FromBody] VisitanteViewModel model)
        {
            return Ok(_service.Visitante.GetVisitanteCPF(model));
        }

        [HttpGet]
        [Authorize]
        [Route("ativarDesativar/{id}")]
        public bool? AtivarDesativar(int id)
        {
            return _service.Visitante.AtivarDesativar(id);
        }

        [HttpPost]
        [Authorize]
        [Route("getVisitanteBuscarFiltrado")]
        public IActionResult GetVisitanteBuscarFiltrado([FromBody] VisitanteFilterModel filter)
        {
            var response = _service.Visitante.GetVisitanteBuscarFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<VisitanteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}