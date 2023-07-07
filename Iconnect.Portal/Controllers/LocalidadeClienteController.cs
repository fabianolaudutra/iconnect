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
using System.Collections.Generic;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalidadeClienteController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<LocalidadeClienteController> _logger;

        public LocalidadeClienteController(ILogger<LocalidadeClienteController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult SalvarAcesso([FromBody] LocalidadeClienteViewModel model)
        {
            return Ok(_service.LocalidadeCliente.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetLocalidadeFiltered([FromBody] LocalidadeClienteFilterModel filter)
        {
            var response = _service.LocalidadeCliente.GetLocalidadeFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<LocalidadeClienteViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Route("editar/{id}")]
        public LocalidadeClienteViewModel GetLocalidade(int id)
        {
            return _service.LocalidadeCliente.GetLocalidade(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult DeletarLocalidae(int id)
        {
            return Ok(_service.LocalidadeCliente.DeletarLocalidade(id));
        }

        [HttpGet]
        [Route("excluirTemp")]
        public IActionResult ExcluirTemporarios()
        {
            return Ok(_service.LocalidadeCliente.ExcluirTemporarios());
        }

        [HttpGet]
        [Authorize]
        [Route("getLocalidades/{id}")]
        public List<GenericList> GetLocalidades(int id)
        {
            return _service.LocalidadeCliente.GetLocalidades(id);
        }

        [HttpGet]
        [Route("getBlocos/{id}")]
        public List<LocalidadeClienteViewModel> GetBlocos(int id)
        {
            return _service.LocalidadeCliente.GetLocalidadeByTipo(id, "BLOCO-QUADRA");
        }

        [HttpGet]
        [Route("getLotes/{id}")]
        public List<LocalidadeClienteViewModel> GetLotes(int id)
        {
            return _service.LocalidadeCliente.GetLocalidadeByTipo(id, "LOTE-APTO");
        }

        [HttpGet]
        [Route("getTorres/{id}")]
        public List<LocalidadeClienteViewModel> GetTorres(int id)
        {
            return _service.LocalidadeCliente.GetLocalidadeByTipo(id, "TORRE");
        }

        [HttpGet]
        [Route("getSalas/{id}")]
        public List<LocalidadeClienteViewModel> GetSalas(int id)
        {
            return _service.LocalidadeCliente.GetLocalidadeByTipo(id, "SALA");
        }

        [HttpGet]
        [Route("GetLocalidadeComboByTipo/{id}/{tipo}")]
        public List<GenericList> GetLocalidadeComboByTipo(int id, string tipo)
        {
            return _service.LocalidadeCliente.GetLocalidadeComboByTipo(id, tipo);
        }

        [HttpGet]
        [Authorize]
        [Route("getLocalidadeByIds/{id}")]
        public GenericList GetLocalidadeByIds(string id)
        {
            return _service.LocalidadeCliente.GetLocalidadeByIds(id);
        }
    }
}