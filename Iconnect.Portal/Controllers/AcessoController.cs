using System;
using System.Collections.Generic;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<AcessoController> _logger;

        public AcessoController(ILogger<AcessoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] AcessoFilterModel filter)
        {
            var response = _service.Acesso.GetAcessoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<AcessoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] AcessoViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                _service.Acesso.InsertOrUpdate(model);

                ret.Success = "Dados salvos com sucesso.";

                return Ok(ret);
            }
            catch (MensagemException ex)
            {
                ret.Error = ex.Message;
                return Ok(ret);
            }
            catch (Exception)
            {
                ret.Error = "Ocorreu um erro ao salvar os dados";
                return Ok(ret);
            }
        }

        [HttpGet]
        [Route("getAllAcessos")]
        public List<AcessoViewModel> Get()
        {
            return _service.Acesso.GetAllAcessos();
        }

        [HttpGet]
        [Route("editar/{id}")]
        public AcessoViewModel Get(int id)
        {
            return _service.Acesso.GetAcesso(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        { 
            return Ok(_service.Acesso.DeletarAcesso(id));
        }

        [HttpPost]
        [Route("validacao")]
        public bool ValidaUsuario([FromBody] AcessoFilterModel filter)
        {

            return (_service.Acesso.ValidaUsuario(filter.ace_c_login_filter, filter.ace_n_codigo_filter));
        }

        [HttpPost]
        [Route("esqueciSenha")]
        public object EsqueciSenha([FromBody] UsuarioViewModel model)
        {
            return (_service.Acesso.EsqueciSenha(model));
        }
    }
}