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

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] PessoaFilterModel filter)
        {
            try
            {
                var _user = User.Claims;
                filter.IdsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
                var response = _service.Pessoa.GetPessoaFiltrado(filter);
                return Ok(new PagedResponse<IPagedList<PessoaViewModel>>() { Data = response, Total = response.TotalItemCount });
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] PessoaFilterModel filter)
        {
            var _user = User.Claims;
            filter.IdsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return File(_service.Pessoa.GeraExcel(filter), "application/ms-excel");
        }

        [HttpPost]
        [Authorize]
        [Route("getPessoaRel")]
        public List<PessoaViewModel> getPessoaRel(PessoaViewModel model)
        {
            return _service.Pessoa.GetRelPessoas(model);
        }

        [HttpGet]
        [Route("listarPessoasCombo/{id}")]
        public IActionResult GetPessoasCombo(int id)
        {
            return Ok(_service.Pessoa.GetPessoasCombo(id, UsuarioLogado));
        }

        [HttpGet]
        [Route("listarPessoasComboFiltro/{id}/{pesquisa}")]
        public IActionResult GetPessoasComboFiltro(int id, string pesquisa)
        {
            return Ok(_service.Pessoa.GetPessoasComboFiltro(id, UsuarioLogado, pesquisa));
        }

        [HttpGet]
        [Route("listPessoasComboFiltrado/{id}/{tipo}")]
        public IActionResult GetPessoasComboFiltrado(int id,string tipo)
        {
            return Ok(_service.Pessoa.GetPessoasComboFiltrado(id, tipo));
        }
    }
}