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
    public class ResponsavelLocacaoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<ResponsavelLocacaoController> _logger;

        public ResponsavelLocacaoController(ILogger<ResponsavelLocacaoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] ResponsavelLocacaoFilterModel filter)
        {
            var response = _service.ResponsavelLocacao.GetFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<ResponsavelLocacaoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Salvar([FromBody] ResponsavelLocacaoViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                var _user = User.Claims;
                model.rel_usu_n_responsavel = _user.FirstOrDefault(x => x.Type == "id").Value;
                _service.ResponsavelLocacao.InsertOrUpdate(model);

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
        [Route("editar/{id}")]
        public ResponsavelLocacaoViewModel GetResponsavel(int id)
        {
            return _service.ResponsavelLocacao.GetResponsavel(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.ResponsavelLocacao.Deletar(id));
        }

        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.ZeladorCliente.ExcluirTemporarios());
        }
    }
}