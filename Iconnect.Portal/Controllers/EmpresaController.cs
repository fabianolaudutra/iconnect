using System;
using System.Collections.Generic;
using System.IO;
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
    public class EmpresaController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(ILogger<EmpresaController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] EmpresaFilterModel filter)
        {
            _service.Acesso.ExcluirTemporarios();
            var response = _service.Empresa.GetEmpresaFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<EmpresaViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpGet]
        [Authorize]
        [Route("buscar")]
        public List<EmpresaViewModel> Get()
        {
            return _service.Empresa.GetEmpresas();
        }

        [HttpGet]
        [Authorize]
        [Route("obterComboEmpresaPorPerfil")]
        public IActionResult ObterComboEmpresaPorPerfil()
        {
            try
            {
                var _user = User.Claims;
                string idsEmpresas = _user.FirstOrDefault(x => x.Type == "idsEmp").Value;
                string idEmp = _user.FirstOrDefault(x => x.Type == "idEmp").Value;

                var ret = new List<ComboEmpresaViewModel>();

                if (!string.IsNullOrEmpty(idsEmpresas))
                    ret = _service.Empresa.ObterComboEmpresa(idsEmpresas);
                else
                    ret = _service.Empresa.ObterComboEmpresa(idEmp);

                return Ok(ret);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Post([FromBody] EmpresaViewModel model)
        {
            _service.Modulo.InsertOrUpdate(model.Modulo);
            return Ok(_service.Empresa.InsertOrUpdate(model));
        }

        [HttpGet]
        [Route("editar/{id}")]
        public EmpresaViewModel Get(int id)
        {
            return _service.Empresa.GetEmpresa(id);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Empresa.DeletarEmpresa(id));
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
                var result = _service.FotoEmpresa.uploadFoto(id, ImageByte);
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
        public byte[] GetFoto(int id)
        {
            return _service.FotoEmpresa.GetFoto(id);
        }

        [HttpGet]
        [Route("deleteFoto/{id}")]
        public IActionResult DeleteFoto(int id)
        {

            return Ok(_service.FotoEmpresa.DeletarFoto(id));
        }

        [HttpPost]
        [Authorize]
        [Route("getEmpRel")]
        public List<EmpresaViewModel> getEmpRel([FromBody] DistribuidorViewModel filter)
        {
            List<EmpresaViewModel> resp = _service.Empresa.GetRelEmpresa(filter);
            return resp;
        }

        [HttpPost]
        [Authorize]
        [Route("getEmpresaCnpj")]
        public List<EmpresaViewModel> getEmpresaCnpj(EmpresaViewModel model)
        {
            return _service.Empresa.getEmpresaCnpj(model);
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] EmpresaFilterModel filter)
        {
            return File(_service.Empresa.GeraExcel(filter), "application/ms-excel");
        }

        [HttpGet]
        [Authorize]
        [Route("comboEmpresa/{id}")]
        public List<EmpresaViewModel> GetComboEmpresa(int id)
        {
            return _service.Empresa.GetComboEmpresa(id);
        }
        
        [Route("getByDistribuidor/{id}")]
        public List<EmpresaViewModel> GetEmpresaByDistribuidor(int id)
        {
            return _service.Empresa.GetEmpresaByDistribuidor(id);
        }

        [HttpGet]
        [Authorize]
        [Route("getComboRelMovimentacao")]
        public List<ComboEmpresaViewModel> ComboIntegradorRelMovimentacao()
        {
            return _service.Empresa.ComboIntegradorRelMovimentacao();
        }

        [HttpGet]
        [Authorize]
        [Route("ramais/{id}")]
        public string[] GetRamaisEmpresa(int id)
        {
            return _service.Empresa.GetRamaisEmpresa(id);
        }
    }
}
