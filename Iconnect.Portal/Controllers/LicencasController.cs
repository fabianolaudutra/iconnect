using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class LicencasController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<LicencasController> _logger;

        public LicencasController(ILogger<LicencasController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarEmpresasFiltrado")]
        public IActionResult GetEmpresasFiltered([FromBody] EmpresaFilterModel filter)
        {
            var response = _service.Licencas.GetEmpresasFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<EmpresaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("buscarClientesFiltrado")]
        public IActionResult GetClientesFiltered([FromBody] ClienteFilterModel filter)
        {
            var response = _service.Licencas.GetClientesFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<ClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] EmpresaFilterModel filter)
        {
            return File(_service.Licencas.GeraExcel(filter), "application/ms-excel");
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcelCliente")]
        public IActionResult GerarExcelCliente([FromBody] ClienteFilterModel filter)
        {
            return File(_service.Licencas.GeraExcelCliente(filter), "application/ms-excel");
        }

        [HttpGet]
        [Route("clientesSemLicenca/{id}")]
        public IActionResult ClientesSemLicenca(int id)
        {
            return Ok(_service.Licencas.ClientesSemLicenca(id));
        }

        [HttpGet]
        [Route("todosClientesSemLicenca")]
        public IActionResult TodosClientesSemLicenca(int id)
        {
            return Ok(_service.Licencas.TodosClientesSemLicenca());
        }
    }
}