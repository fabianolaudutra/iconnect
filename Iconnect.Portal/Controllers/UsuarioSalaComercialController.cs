using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
using Iconnect.Infraestrutura.Models;
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
    public class UsuarioSalaComercialController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<UsuarioSalaComercialController> _logger;

        public UsuarioSalaComercialController(ILogger<UsuarioSalaComercialController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] UsuarioSalaComercialFilterModel filter)
        {
            _service.Acesso.ExcluirTemporarios();
            var response = _service.UsuarioSalaComercial.GetUsuarioSalaFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<UsuarioSalaComercialViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] UsuarioSalaComercialViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                _service.Acesso.InsertOrUpdate(model.Acesso);

                _service.UsuarioSalaComercial.InsertOrUpdate(model);

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
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.UsuarioSalaComercial.DeletarUsuario(id));
        }

        [HttpGet]
        [Authorize]
        [Route("buscaUsuariosbyId/{id}")]
        public UsuarioSalaComercialViewModel GetUsuarioById(int id)
        {
            return _service.UsuarioSalaComercial.GetUsuarioById(id);
        }
        
    }
}