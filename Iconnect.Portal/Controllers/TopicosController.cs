using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using Iconnect.Aplicacao.FilterModel;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicosController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<TopicosController> _logger;

        public TopicosController(ILogger<TopicosController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Salvar([FromBody] TopicoViewModel model)
        {
            var retorno = new Retorno();
            try
            {
                _service.Topicos.Insert(model);
                retorno.status = "sucesso";
                retorno.conteudo = "Dados salvos com sucesso";
                return Ok(retorno);
            }
            catch (Exception e)
            {
                retorno.status = "erro";
                retorno.conteudo = "Ocorreu um erro ao salvar os dados";
                return Ok(retorno);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getTopicos")]
        public IActionResult GetTopicos()
        {
            return Ok(_service.Topicos.GetTopicos());
        }

        [HttpPost]
        [Authorize]
        [Route("getListaTopicos")]
        public IActionResult GetListaTopicos([FromBody] TopicosFilterModel filter)
        {
            var response = _service.Topicos.GetListaTopicos(filter);
            return Ok(new PagedResponse<IPagedList<TopicoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var retorno = new Retorno();
            try
            {
                _service.Topicos.Deletar(id);
                retorno.status = "sucesso";
                retorno.conteudo = "Dado excluído com sucesso";
                return Ok(retorno);
            }
            catch (Exception e)
            {
                retorno.status = "erro";
                retorno.conteudo = "Ocorreu um erro ao excluir o dado";
                return Ok(retorno);
            }
        }
    }
}
