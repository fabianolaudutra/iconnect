﻿
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Aplicacao.FilterModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvisoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<AvisoController> _logger;

        public AvisoController(ILogger<AvisoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] AvisoFilterModel filter)
        {
            var _user = User.Claims;
            filter.idEmp = _user.FirstOrDefault(x => x.Type == "idEmp").Value;
            var response = _service.Aviso.GetAvisoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<AvisoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] AvisoViewModel model)
        {
            return Ok(_service.Aviso.SalvarAviso(model));
        }

        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public AvisoViewModel Get(int id)
        {
            return _service.Aviso.GetAviso(id);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Aviso.DeletarAviso(id));
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] AvisoFilterModel filter)
        {
            var _user = User.Claims;
            filter.idEmp = _user.FirstOrDefault(x => x.Type == "idEmp").Value;
            return File(_service.Aviso.GeraExcel(filter), "application/ms-excel");
        }
    }
}