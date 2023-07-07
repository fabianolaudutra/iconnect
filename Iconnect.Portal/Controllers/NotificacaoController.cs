using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using System;
using System.Collections.Generic;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificacaoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<NotificacaoController> _logger;

        public NotificacaoController(ILogger<NotificacaoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("listar")]
        public IActionResult ListarNotificacao([FromBody] NotificacaoFilterViewModel filter)
        {
            int.TryParse(IdUsuarioLogado, out int idUsuario);
            int.TryParse(PerfilLogado, out int perfil);
            filter.IdUsuario = idUsuario;
            filter.IdPerfil = perfil;

            var response = _service.Notificacao.ListarNotificacao(filter);
            return Ok(new PagedResponse<IPagedList<NotificacaoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("primeirasNotificacoes")]
        public List<NotificacaoViewModel> PrimeirasNotificacoes()
        {
            return _service.Notificacao.PrimeirasNotificacoes(Convert.ToInt32(IdUsuarioLogado), Convert.ToInt32(PerfilLogado));
        }


        [HttpGet]
        [Authorize]
        [Route("idPerfil")]
        public int IdPerfil()
        {
            return _service.Notificacao.IdPerfil(Convert.ToInt32(PerfilLogado));
        }

        [HttpPost]
        [Authorize]
        [Route("updateStatus")]
        public IActionResult UpdateStatus([FromBody] NotificacaoViewModel[] model)
        {
            int.TryParse(PerfilLogado, out int perfil);

            return Ok(_service.Notificacao.UpdateStatus(model, perfil));
        }

        [HttpPost]
        [Authorize]
        [Route("salvarNotificacao")]
        public IActionResult Post([FromBody] AvisoViewModel model)
        {
            return Ok(_service.Notificacao.SalvarAvisoNotificacao(model));
        }

        [HttpPost]
        [Authorize]
        [Route("salvarNotificacaoEmpresa")]
        public IActionResult Post([FromBody] AvisoEmpresaViewModel model)
        {
            return Ok(_service.Notificacao.SalvarAvisoEmpresaNotificacao(model));
        }

    }
}
