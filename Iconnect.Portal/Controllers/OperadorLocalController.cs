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
using System.Linq;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperadorLocalController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<OperadorLocalController> _logger;

        public OperadorLocalController(ILogger<OperadorLocalController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] OperadorLocalFilterModel filter)
        {
            var _user = User.Claims;
            filter.idEmp = _user.FirstOrDefault(x => x.Type == "idEmp").Value;
            var response = _service.OperadorLocal.GetOperadorLocalFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<OperadorLocalViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] OperadorLocalViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                ret.Id = _service.OperadorLocal.SalvarOperadorLocal(model).ToString();
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
        [Authorize]
        [Route("editar/{id}")]
        public OperadorLocalViewModel Get(int id)
        {
            return _service.OperadorLocal.GetOperadorLocal(id);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.OperadorLocal.DeletarOperadorLocal(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] OperadorLocalFilterModel filter)
        {
            return File(_service.OperadorLocal.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("getOpeLocalCliente/{id}")]
        public IActionResult GetOperadorLocalCliente(int id)
        {
            return Ok(_service.OperadorLocal.GetOperadorLocalCliente(id));
        }
    }
}