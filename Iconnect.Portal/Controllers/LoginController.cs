using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("auth")]
        public IActionResult Logar(LoginViewModel dados)
        {
            try
            {
                var user = _service.Acesso.Logar(dados.usuario, dados.senha);
                return Ok(new UsuarioViewModel()
                {
                    idUsuario = user.idUsuario,
                    nomeUsuario = user.nomeUsuario
                });
            }
            catch (MensagemException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception)
            {
                return Ok("Ocorreu um erro ao salvar os dados");
            }
        }
    }
}
