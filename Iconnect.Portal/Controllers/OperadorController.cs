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
    public class OperadorController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<OperadorController> _logger;

        public OperadorController(ILogger<OperadorController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] OperadorFilterModel filter)
        {

            var _user = User.Claims;
            filter.idEmp = _user.FirstOrDefault(x => x.Type == "idEmp").Value;
            var response = _service.Operador.GetOperadorFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<OperadorViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public OperadorViewModel Get(int id)
        {
            return _service.Operador.GetOperador(id);
        }

        [HttpGet]
        [Authorize]
        [Route("buscarByEmpresa/{id}")]
        public List<OperadorViewModel> GetOperadoresByEmpresa(int id)
        {
            return _service.Operador.GetOperadoresByEmpresa(id);
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public OperadorViewModel GetEditar(int id)
        {
            return _service.Operador.GetOperador(id);
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] OperadorViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                ret.Id = _service.Operador.SalvarOperador(model).ToString();
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
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Operador.DeletarOperador(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] OperadorFilterModel filter)
        {
            var _user = User.Claims;
            filter.idEmp = _user.FirstOrDefault(x => x.Type == "idEmp").Value;
            return File(_service.Operador.GeraExcel(filter), "application/ms-excel");
        }
        [HttpGet]
        [Authorize]
        [Route("buscaOperadores/{id}")]
        public List<GenericList> GetOperadoresCliente(int id)
        {
            return _service.Operador.GetOperadoresCliente(id);
        }

        [HttpGet]
        [Authorize]
        [Route("listarPerfis")]
        public List<GenericList> ListarPerfis()
        {
            return _service.Operador.ListarPerfis();
        }
    }
}