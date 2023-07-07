using System;
using System.Collections.Generic;
using System.IO;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DependenciasController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<DependenciasController> _logger;

        public DependenciasController(ILogger<DependenciasController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] DependenciaFilterModel filter)
        {
            var response = _service.Dependencias.GetFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<DependenciaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Salvar([FromBody] DependenciaViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                _service.Dependencias.InsertOrUpdate(model);
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
                ret.Error = "Ocorreu um erro ao salvar os dados da Dependência.";
                return Ok(ret);
            }
        }

        [HttpGet]
        [Route("editar/{id}")]
        public DependenciaViewModel GetResponsavel(int id)
        {
            return _service.Dependencias.GetDependencia(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var ret = new RetornoViewModel();
            try
            {
                _service.Dependencias.Deletar(id);
                ret.Success = "Dependência removida com sucesso.";

                return Ok(ret);
            }
            catch (MensagemException ex)
            {
                ret.Error = ex.Message;
                return Ok(ret);
            }
            catch (Exception)
            {
                ret.Error = "Ocorreu um erro ao remover a Dependência.";
                return Ok(ret);
            }
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

        [HttpGet]
        [Route("deleteFoto/{id}")]
        public IActionResult DeleteFoto(int id)
        {
            return Ok(_service.FotoDependencia.DeletarFoto(id));
        }

        #region Arquivo
        [HttpPost]
        [Authorize]
        [Route("uploadArquivo/{id}")]
        public IActionResult uploadArquivo(string id)
        {
            try
            {
                var file = Request.Form.Files[0];
                string nome = "";
                byte[] ImageByte = null;
                if (file == null) throw new Exception("File is null");
                if (file.Length == 0) throw new Exception("File is empty");

                nome = file.FileName;
                using (Stream stream = file.OpenReadStream())
                {
                    using (var binaryReader = new BinaryReader(stream))
                    {
                        ImageByte = binaryReader.ReadBytes((int)file.Length);

                    }
                }
                var result = _service.ArquivoDependencia.uploadArquivo(id, nome, ImageByte);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("deleteArquivo/{id}")]
        public IActionResult DeleteArquivo(int id)
        {
            return Ok(_service.ArquivoDependencia.DeletarArquivo(id));
        }

        [HttpGet]
        [Authorize]
        [Route("getArquivo/{id}")]
        public IActionResult GetArquivo(int id)
        {

          return File(_service.ArquivoDependencia.GetArquivo(id), "application/pdf");

        }

        [HttpGet]
        [Authorize]
        [Route("getImg/{id}")]
        public IActionResult GetImg(int id)
        {
            return File(_service.ArquivoDependencia.GetImg(id), "image/jpg");
        }
        #endregion
    }
}