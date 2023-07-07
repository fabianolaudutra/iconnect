using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
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
    public class GrupoPermissaoOperadorController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<GrupoPermissaoOperadorController> _logger;

        public GrupoPermissaoOperadorController(ILogger<GrupoPermissaoOperadorController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Authorize]
        [Route("buscar")]
        public List<tb_gpp_grupoPermissaoOperador> Get()
        {
            return _service.GrupoPermissaoOperador.ListarGrupoPermissaoOperador();
        }

        [HttpGet]
        [Authorize]
        [Route("ListarGrupoById/{id}")]
        public List<tb_gpp_grupoPermissaoOperador> ListarGrupoById(int id)
        {
            return _service.GrupoPermissaoOperador.ListarGrupoById(id);
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] GrupoPermissaoOperadorFilterViewModel filter)
        {
            var _user = User.Claims;
            filter.idEmp = _user.FirstOrDefault(x => x.Type == "idEmp").Value;
            var response = _service.GrupoPermissaoOperador.GetGrupoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<GrupoPermissaoOperadorViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarGrupo([FromBody] GrupoPermissaoOperadorViewModel model)
        {
            _service.Modulo.InsertOrUpdate(model.Modulo);
            return Ok(_service.GrupoPermissaoOperador.InsertOrUpdate(model, UsuarioLogado));
        }

        [HttpGet]
        [Route("editar/{id}")]
        public GrupoPermissaoOperadorViewModel GetGrupo(int id)
        {
            return _service.GrupoPermissaoOperador.GetGrupo(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.GrupoPermissaoOperador.DeletarGrupo(id));
        }

        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.GrupoPermissaoOperador.ExcluirTemporarios());
        }

        [HttpGet]
        [Authorize]
        [Route("buscaTipos")]
        public List<GenericList> BuscaTipos()
        {
            return _service.GrupoPermissaoOperador.BuscaTipos();
        }

        [HttpGet]
        [Route("permissoes/{id}")]
        public List<PermissoesGrupoViewModel> Permissoes(int id)
        {
            return _service.GrupoPermissaoOperador.BuscaPermissoes(id);
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] GrupoPermissaoOperadorFilterViewModel filter)
        {
            var _user = User.Claims;
            filter.idEmp = _user.FirstOrDefault(x => x.Type == "idEmp").Value;
            return File(_service.GrupoPermissaoOperador.GeraExcel(filter), "application/ms-excel");
        }
    }
}