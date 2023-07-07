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
    public class PrestadorServicoController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<PrestadorServicoController> _logger;

        public PrestadorServicoController(ILogger<PrestadorServicoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("buscarById/{id}")]
        public PrestadorServicoViewModel GetPrestadorServico(int id)
        {
            return _service.PrestadorServico.GetPrestadorServico(id);
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] PrestadorServicoViewModel model)
        {
            var retorno = new RetornoViewModel();
            try
            {
                var ret = _service.PrestadorServico.SalvarPrestadorServico(model);

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
                retorno.Error = "Ocorreu um erro ao salvar os dados do Prestador de Serviço.";
                return Ok(retorno);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.PrestadorServico.Deletar(id));
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] PrestadorServicoFilterModel filter)
        {
            var response = _service.PrestadorServico.GetPrestadorFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PrestadorServicoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("getPrestadorByFilter")]
        public IActionResult GetPrestadorByFilter([FromBody] PrestadorServicoFilterModel filter)
        {
            var response = _service.PrestadorServico.GetPrestadorByFilter(filter);
            return Ok(new PagedResponse<IPagedList<PrestadorServicoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
        [HttpGet]
        [Authorize]
        [Route("ativarDesativar/{id}")]
        public bool? AtivarDesativar(int id)
        {
            return _service.PrestadorServico.AtivarDesativar(id);
        }

        [HttpPost]
        [Authorize]
        [Route("salvarHoraio")]
        public IActionResult salvarHoraio([FromBody] PrestadorServicoViewModel model)
        {
            return Ok(_service.PrestadorServico.salvarHoraio(model));
        }

        [HttpPost]
        [Authorize]
        [Route("getPrestadorBuscarFiltrado")]
        public IActionResult GetPrestadorBuscarFiltrado([FromBody] PrestadorServicoFilterModel filter)
        {
            var response = _service.PrestadorServico.GetPrestadorBuscarFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PrestadorServicoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}