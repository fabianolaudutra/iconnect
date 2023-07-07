using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using System;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProprietarioController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<ProprietarioController> _logger;

        public ProprietarioController(ILogger<ProprietarioController> logger, IServiceWrapper service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] ProprietarioFilterModel filter)
        {
            var response = _service.Proprietario.GetProprietarioFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<ProprietarioViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Post([FromBody] ProprietarioViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                AcessoViewModel acesso = new AcessoViewModel
                {
                    ace_c_login = model.pro_ace_login,
                    ace_c_senha = model.pro_ace_senha,
                    ace_per_n_codigo = 1,
                    ace_n_codigo = Convert.ToInt32(model.pro_ace_n_codigo)
                };

                _service.Acesso.InsertOrUpdate(acesso);
                model.pro_ace_n_codigo = acesso.ace_n_codigo.ToString();

                ret.Id = _service.Proprietario.SalvarProprietario(model).ToString();
                
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
                ret.Error = "Ocorreu um erro ao salvar os dados do Proprietário";
                return Ok(ret);
            }
        }

        [HttpGet]
        [Route("editar/{id}")]
        public ProprietarioViewModel Get(int id)
        {
            return _service.Proprietario.GetProprietario(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Proprietario.DeletarProprietario(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] ProprietarioFilterModel filter)
        {
            return File(_service.Proprietario.GeraExcel(filter), "application/ms-excel");
        }
    }
}