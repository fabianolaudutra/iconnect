using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using System;
using System.Linq;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AjudaController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<AjudaController> _logger;

        public AjudaController(ILogger<AjudaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] AjudaViewModel model)
        {
            var ret = new Retorno();
            try
            {
                ret.id = _service.Ajuda.InsertOrUpdate(model);
                ret.status = "sucesso";
                ret.conteudo = "Dados salvos com sucesso.";

                return Ok(ret);
            }
            catch (Exception e)
            {
                ret.status = "erro";
                ret.conteudo = "Ocorreu um erro ao salvar os dados";
                return Ok(ret);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getAjuda/{id}")]
        public IActionResult GetAjuda(int id)
        {
           return Ok(_service.Ajuda.GetAjuda(id));
        }

        [HttpPost]
        [Authorize]
        [Route("getAjudaFiltrado")]
        public IActionResult GetAjudaFiltrado([FromBody] AjudaFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return Ok(_service.Ajuda.GetAjudaFiltrado(filter));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var retorno = new Retorno();
            try
            {
                _service.Ajuda.Deletar(id);
                retorno.status = "sucesso";
                retorno.conteudo = "Dados excluídos com sucesso";
                return Ok(retorno);
            }
            catch(Exception e)
            {
                retorno.status = "erro";
                retorno.conteudo = "Ocorreu um erro ao excluir os dados";
                return Ok(retorno);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("getCadastroAjudaFiltrado")]
        public IActionResult GetCadastroAjudaFiltrado([FromBody] AjudaFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.Ajuda.GetCadastroAjudaFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<AjudaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}
