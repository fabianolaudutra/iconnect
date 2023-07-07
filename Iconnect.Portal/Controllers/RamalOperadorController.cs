using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RamalOperadorController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<RamalOperadorController> _logger;

        public RamalOperadorController(ILogger<RamalOperadorController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult SalvarRamal([FromBody] RamalOperadorViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                _service.RamalOperador.SalvarRamal(model);
                retorno.status = "sucesso";
                retorno.conteudo = "Ramal atribuído com sucesso";
                return Ok(retorno);
            }
            catch (MensagemException ex)
            {
                retorno.status = "erro";
                retorno.conteudo = ex.Message;
                return Ok(retorno);
            }
            catch (Exception)
            {
                retorno.status = "erro";
                retorno.conteudo = "Ocorreu um erro ao atribuir o ramal";
                return Ok(retorno);
            }
        }
    }
}
