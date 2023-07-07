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
    public class MoradorController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<MoradorController> _logger;

        public MoradorController(ILogger<MoradorController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("buscarFuncionarios/{id}")]
        public List<MoradorViewModel> GetFuncionariosByCliente(int id)
        {
            return _service.Morador.GetFuncionariosByCliente(id);
        }

        [HttpGet]
        [Authorize]
        [Route("buscarFuncionariosAtivos/{id}")]
        public List<MoradorViewModel> GetFuncionariosAtivosByCliente(int id)
        {
            return _service.Morador.GetFuncionariosAtivosByCliente(id);
        }

        [HttpGet]
        [Authorize]
        [Route("buscarByGrupoFamiliar/{id}")]
        public List<MoradorViewModel> Get(int id)
        {
            return _service.Morador.GetMoradoresByGrupoFamiliar(id);
        }

        [HttpGet]
        [Authorize]
        [Route("buscarBySalaComercial/{id}")]
        public List<MoradorViewModel> GetMoradoresBySalaComercial(int id)
        {
            return _service.Morador.GetMoradoresBySalaComercial(id);
        }
        

        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}")]
        public List<MoradorViewModel> GetByCliente(int id)
        {
            return _service.Morador.GetMoradoresByCliente(id);
        }

        [HttpGet]
        //[Authorize]
        [Route("buscarById/{id}")]
        public MoradorViewModel GetMorador(int id)
        {
            var retorno = _service.Morador.GetMorador(id);
            return retorno;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] MoradorViewModel model)
        {
            var retorno = new RetornoViewModel();
            try
            {
                var ret = _service.Morador.SalvarMorador(model);

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
                retorno.Error = "Ocorreu um erro ao salvar os dados.";
                return Ok(retorno);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _service.Morador.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {
                if (error.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    return StatusCode(547, "O registro não pôde ser removido por existirem registros atrelados a ele.");
                }
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] MoradorFilterModel filter)
        {
            var response = _service.Morador.GetMoradorFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<MoradorViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("ativarDesativar")]
        public bool? AtivarDesativar(int id)
        {
            return _service.Morador.AtivarDesativar(id);
        }

        [HttpPost]
        [Authorize]
        [Route("getMoradorBuscarFiltrado")]
        public IActionResult GetMoradorBuscarFiltrado([FromBody] MoradorFilterModel filter)
        {
            var response = _service.Morador.GetMoradorBuscarFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<MoradorViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}