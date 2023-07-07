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

    public class AtendimentoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<AtendimentoController> _logger;

        public AtendimentoController(ILogger<AtendimentoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("GetTotalizadoresSolution")]
        public AtendimentoViewModel GetTotalizadoresSolution()
        {
            var _user = User.Claims;
            var idClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            AtendimentoFilterModel model = new AtendimentoFilterModel();
            model.usuario_filter = IdUsuarioLogado;
            model.perfil_filter = PerfilLogado;
            return _service.Atendimento.GetTotalizadoresSolution(model, idClientes);
        }

        [HttpPost]
        [Authorize]
        [Route("FinalizarAtendimento")]
        public IActionResult FinalizarAtendimento(AtendimentoViewModel model)
        {
            return Ok(_service.Atendimento.FinalizarAtendimento(model));
        }

        [HttpPost]
        [Authorize]
        [Route("CancelarAtendimento")]
        public IActionResult CancelarAtendimento(AtendimentoViewModel model)
        {
            return Ok(_service.Atendimento.CancelarAtendimento(model));
        }

        [HttpPost]
        [Authorize]
        [Route("AlterarStatusAtendimento")]
        public IActionResult AlterarStatusAtendimento(AtendimentoViewModel model)
        {
            return Ok(_service.Atendimento.AlterarStatusAtendimento(model));
        }

        [HttpGet]
        [Authorize]
        [Route("ListarClientesSolution")]
        public AtendimentoViewModel ListarClientesSolution()
        {
            AtendimentoFilterModel model = new AtendimentoFilterModel();
            model.usuario_filter = IdUsuarioLogado;
            model.perfil_filter = PerfilLogado;

            return _service.Atendimento.ListarClientesSolution(model);
        }


        [HttpPost]
        [Authorize]
        [Route("TransferirAtendimento")]
        public IActionResult TransferirAtendimento(AtendimentoViewModel model)
        {
            return Ok(_service.Atendimento.TransferirAtendimento(model, PerfilLogado));
        }
    }
}