using System;
using System.Collections.Generic;
using System.Linq;

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
    public class ClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("ListarTodos")]
        public List<ClienteViewModel> ListarTodos()
        {
            var _user = User.Claims;
            int idEmp = Convert.ToInt32(_user.FirstOrDefault(x => x.Type == "idEmp").Value);
            string ids = _user.FirstOrDefault(x => x.Type == "idsCli").Value;

            var userIsAdmin = _user.FirstOrDefault(user => user.Type == "Perfil").Value;
            return _service.Cliente.ListarTodos(ids, userIsAdmin == "1");
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public List<ClienteViewModel> GetClientes(int id)
        {
            var _user = User.Claims;
            string clienteLiberados = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return _service.Cliente.GetClientes(id, clienteLiberados);
        }

        [HttpGet]
        [Authorize]
        [Route("buscarEmpresarial/{id}")]
        public List<ClienteViewModel> GetClienteEmpresarial(int id)
        {
            var _user = User.Claims;
            var clientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var retorno = _service.Cliente.GetClienteEmpresarial(id, clientes);
            return retorno;
        }

        [HttpPost]
        [Authorize]
        [Route("getClienteCnpj")]
        public List<ClienteViewModel> getClienteCnpj(ClienteViewModel model)
        {
            return _service.Cliente.getClienteCnpj(model);
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Post([FromBody] ClienteViewModel model)
        {
            _service.Modulo.InsertOrUpdate(model.Modulo);
            return Ok(_service.Cliente.InsertOrUpdate(model));
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public ClienteViewModel GetCliente(int id)
        {
            var _user = User.Claims;
            var userIsAdmin = _user.FirstOrDefault(x => x.Type == "Perfil").Value;

            var retorno = _service.Cliente.GetCliente(id, userIsAdmin == "1");
            return retorno;
        }

        [HttpGet]
        //[Authorize]
        [Route("getClienteQR/{id}")]
        public ClienteViewModel GetClienteQR(int id)
        {
            var retorno = _service.Cliente.GetClienteQR(id);
            return retorno;
        }

        [HttpGet]
        [Authorize]
        [Route("getTipoEmpresarial")]
        public List<ClienteViewModel> getTipoEmpresarial()
        {
            var retorno = _service.Cliente.getTipoEmpresarial();
            return retorno;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] ClienteFilterModel filter)
        {
            _service.Acesso.ExcluirTemporarios();
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.Cliente.GetClienteFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<ClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("listarTipos")]
        public List<TipoClienteViewModel> ListarTipos()
        {
            return _service.Cliente.ListarTipos();
        }

        [HttpPost]
        [Authorize]
        [Route("getClienteRel")]
        public List<ClienteViewModel> getClienteRel(EmpresaViewModel model)
        {
            return _service.Cliente.GetRelClientes(model);
        }

        [HttpPost]
        [Authorize]
        [Route("getClienteRelLicenca")]
        public List<ClienteViewModel> getClienteRelLicenca(ClienteViewModel model)
        {
            return _service.Cliente.GetRelClientesLicenca(model);
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] ClienteFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return File(_service.Cliente.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("gerarReferencia")]
        public IActionResult GerarReferencia()
        {
            return Ok(_service.Cliente.GerarCodigoReferencia());
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarZoneamento(int id)
        {
            return Ok(_service.Cliente.DeletarCliente(id));
        }

        [HttpPost]
        [Route("salvarLicenca")]
        public IActionResult SalvarLicenca([FromBody] ClienteViewModel model)
        {
            return Ok(_service.Cliente.UpdateLicenca(model, UsuarioLogado));
        }

        [HttpPost]
        [Route("salvarSerial")]
        public IActionResult SalvarSerial([FromBody] ClienteViewModel model)
        {
            return Ok(_service.Cliente.SalvarSerial(model));

        }

        [HttpGet]
        [Route("removerLicenca/{id}")]
        public IActionResult RemoverLicenca(int id)
        {
            return Ok(_service.Cliente.RemoverLicenca(id));
        }

        [HttpGet]
        [Route("getTipo/{id}")]
        public IActionResult ugetTipoploadFoto(int id)
        {
            try
            {

                var result = _service.Cliente.getTipo(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("getTipoAcessoGratuito/{id}")]
        public IActionResult GetTipoAcessoGratuito(int id)
        {
            try
            {
                var _user = User.Claims;
                var userIsAdmin = _user.FirstOrDefault(user => user.Type == "Perfil").Value;
                var result = _service.Cliente.GetTipo_FlagAcessoGratuito(id, userIsAdmin == "1");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("getModulo/{id}")]
        public IActionResult getModulo(int id)
        {
            try
            {
                var result = _service.Cliente.getModulo(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("salvaEmailSegTrabalho")]
        public IActionResult SalvaEmailSegTrabalho([FromBody] ClienteViewModel model)
        {
            return Ok(_service.Cliente.SalvaEmailSegTrabalho(model));
        }

        [HttpGet]
        [Authorize]
        [Route("comboCliente/{id}")]
        public List<ClienteViewModel> GetComboCliente(int idEmpresa)
        {
            return _service.Cliente.GetComboCliente(idEmpresa);
        }

        [HttpGet]
        [Authorize]
        [Route("filtraCliente/{id}")]
        public List<ClienteViewModel> FiltraCliente(string id)
        {
            return _service.Cliente.FiltraCliente(id);
        }

        [HttpGet]
        [Authorize]
        [Route("moduloCliente/{id}")]
        public ModuloViewModel GetModuloCliente(int id)
        {
            return _service.Cliente.GetModuloCliente(id);
        }

        [HttpGet]
        [Authorize]
        [Route("clienteComercial")]
        public IActionResult GetClienteComercial()
        {
            var _user = User.Claims;
            string ids = _user.FirstOrDefault(x => x.Type == "idsCli").Value;

            return Ok(_service.Cliente.GetClienteComercial(ids));
        }

        [HttpPost]
        [Route("salvarIdFotoFachada")]
        public IActionResult SalvarIdFotoFachada([FromBody] ClienteViewModel model)
        {
            return Ok(_service.Cliente.SalvarIdFotoFachada(model));
        }

        [HttpGet]
        [Authorize]
        [Route("getFotoFachada/{id}")]
        public List<ClienteViewModel> GetFotoFachada(int id)
        {
            return _service.Cliente.GetFotoFachada(id);
        }

        [HttpGet]
        [Authorize]
        [Route("getComboRelMovimentacaoCliente/{id}")]
        public List<ClienteViewModel> GetComboRelMovimentacaoCliente(int id)
        {
            var retorno = _service.Cliente.GetComboRelMovimentacaoCliente(id);
            return retorno;
        }
    }
}