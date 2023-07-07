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
using System.IO;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AfastamentoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<AfastamentoController> _logger;

        public AfastamentoController(ILogger<AfastamentoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] AfastamentoFilterModel filter)
        {
            var response = _service.Afastamento.GetFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<AfastamentoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult InsertOrUpdate([FromBody] AfastamentoViewModel model)
        {
            return Ok(_service.Afastamento.InsertOrUpdate(model));
        }

        [HttpPost]
        [Route("salvarPorGrupo")]
        public IActionResult InsertOrUpdateByGrupo([FromBody] AfastamentoViewModel model)
        {
            return Ok(_service.Afastamento.InsertOrUpdateByGrupo(model));
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public AfastamentoViewModel GetClientes(int id)
        {
            return _service.Afastamento.GetAfastamento(id);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Afastamento.Deletar(id));
        }

        [HttpPost]
        [Authorize]
        [Route("getAfastamentoRel")]
        public List<AfastamentoViewModel> GetAfastamentoRel([FromBody] AfastamentoViewModel model)
        {
            return _service.Afastamento.GetAfastamentoRel(model);
        }
        public class Upload
        {
            public string data { get; set; }
            public IFormFile file { get; set; }
        }

        [HttpPost]
        [Authorize]
        [Route("upload/{id}")]
        public IActionResult uploadFoto(string id)
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] ImageByte = null;
                if (file == null) throw new Exception("File is null");
                if (file.Length == 0) throw new Exception("File is empty");

                using (Stream stream = file.OpenReadStream())
                {
                    using (var binaryReader = new BinaryReader(stream))
                    {
                        ImageByte = binaryReader.ReadBytes((int)file.Length);
                    }
                }
                var result = _service.FotoDependencia.uploadFoto(id, ImageByte);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getFoto/{id}")]
        public RetornoFotoViewModel GetFoto(int id)
        {
            return _service.Dependencias.GetFoto(id);
        }
    }
}