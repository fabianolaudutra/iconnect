using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgenteComercialController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<AgenteComercialController> _logger;

        public AgenteComercialController(ILogger<AgenteComercialController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult InsertOrUpdate([FromBody] AgenteComercialViewModel model)
        {
            var ret = new RetornoViewModel();

            try
            { 
                AcessoViewModel acesso = new AcessoViewModel
                {
                    ace_c_login = model.age_ace_login,
                    ace_c_senha = model.age_ace_senha,
                    ace_n_codigo = Convert.ToInt32(model.age_ace_n_codigo),
                    ace_per_n_codigo = 13,
                };
                _service.Acesso.InsertOrUpdate(acesso);

                model.age_ace_n_codigo = acesso.ace_n_codigo.ToString();

                ret.Id = _service.AgenteComercial.InsertOrUpdate(model).ToString();
   
                ret.Success = "Dados salvos com sucesso";

                return Ok(ret);
            }
            catch (MensagemException ex)
            {
                _service.Acesso.DeletarAcesso(Convert.ToInt32(model.age_ace_n_codigo));
                ret.Error = ex.Message;
                return Ok(ret);
            }
            catch (Exception)
            {
                ret.Error = "Ocorreu um erro ao salvar os dados do Agente Comercial";
                return Ok(ret);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] AgenteComercialFilterModel filter)
        {
            var response = _service.AgenteComercial.GetFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<AgenteComercialViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("getAgente/{id}")]
        public IActionResult GetAgenteComercial(int id)
        {
            return Ok(_service.AgenteComercial.GetAgenteComercial(id));
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.AgenteComercial.Deletar(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] AgenteComercialFilterModel filter)
        {
            return File(_service.AgenteComercial.GerarExcel(filter), "application/ms-excel");
        }
    }
}
