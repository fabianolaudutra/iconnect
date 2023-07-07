using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZeladorClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<ZeladorClienteController> _logger;

        public ZeladorClienteController(ILogger<ZeladorClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] ZeladorClienteFilterModel filter)
        {
            var response = _service.ZeladorCliente.GetZeladorFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<ZeladorClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] ZeladorClienteViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                _service.Acesso.InsertOrUpdate(model.Acesso);

                //Validar erros no futuro
                _service.Modulo.InsertOrUpdate(model.Modulo);

                _service.ZeladorCliente.InsertOrUpdate(model);

                ret.Success = "Dados salvos com sucesso.";

                return Ok(ret);
            }
            catch(MensagemException ex)
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
        [Route("editar/{id}")]
        public ZeladorClienteViewModel GetZelador(int id)
        {
            return _service.ZeladorCliente.GetZelador(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.ZeladorCliente.DeletarZelador(id));
        }

        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.ZeladorCliente.ExcluirTemporarios());
        }

        [HttpGet]
        [Authorize]
        [Route("buscaZeladoresCliente/{id}")]
        public List<GenericList> GetZeladoresCliente(int id)
        {
            return _service.ZeladorCliente.GetZeladoresCliente(id);
        }
    }
}