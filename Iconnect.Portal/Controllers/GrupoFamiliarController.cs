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
    public class GrupoFamiliarController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<GrupoFamiliarController> _logger;

        public GrupoFamiliarController(ILogger<GrupoFamiliarController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("buscarByCliente/{id}")]
        public List<GrupoFamiliarViewModel> Get(int id)
        {
            var _user = User.Claims;
            var perfil = _user.FirstOrDefault(x => x.Type == "Perfil");

            if (perfil.Value == "9" || perfil.Value == "10")
            {
                var response = _service.GrupoFamiliar.GetGruposFamiliarByCliente(id);
                var filtro = _user.FirstOrDefault(x => x.Type == "sub");
                return response.Where(x => x.grf_n_codigo.Contains(filtro.Value)).ToList();
            }
            else
            {
                return _service.GrupoFamiliar.GetGruposFamiliarByCliente(id);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("buscarRespByCliente/{id}")]
        public List<GrupoFamiliarViewModel> buscarRespByCliente(int id)
        {
            return _service.GrupoFamiliar.GetResponsavelByCliente(id);
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public GrupoFamiliarViewModel GetGrupoFamiliar(int id)
        {
            return _service.GrupoFamiliar.GetGrupoFamiliar(id);
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] GrupoFamiliarFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.GrupoFamiliar.GetGrupoFamiliarFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<GrupoFamiliarViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("gerarExcel")]
        public IActionResult gerarExcel([FromBody] GrupoFamiliarFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return File(_service.GrupoFamiliar.GeraExcel(filter), "application/ms-excel");
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] GrupoFamiliarViewModel model)
        {
            var result = _service.GrupoFamiliar.SalvarGrupoFamiliar(model);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.GrupoFamiliar.DeletarGrupoFamiliar(id));
        }

        [HttpGet]
        [Authorize]
        [Route("resetSenha/{id}")]
        public IActionResult resetSenha(int id)
        {
            return Ok(_service.GrupoFamiliar.GetResetSenha(id));
        }

        [HttpGet]
        [Authorize]
        [Route("getGruposByMorador/{id}")]
        public GrupoFamiliarViewModel GetGruposByMorador(int id)
        {
            return _service.GrupoFamiliar.GetGruposByMorador(id);
        }

        [HttpPost]
        [Authorize]
        [Route("verificaEmail")]
        public IActionResult verificaEmail([FromBody] GrupoFamiliarViewModel model)
        {
            return Ok(_service.GrupoFamiliar.verificaEmail(model));
        }

        [HttpPost]
        [Authorize]
        [Route("verificaRamal")]
        public IActionResult verificaRamal([FromBody] GrupoFamiliarViewModel model)
        {
            return Ok(_service.GrupoFamiliar.verificaRamal(model));
        }

        [HttpGet]
        [Route("salaComercial/{id}")]
        public IActionResult SalaComercial(int id)
        {
            return Ok(_service.GrupoFamiliar.SalaComercial(id));
        }

        [HttpPost]
        [Authorize]
        [Route("verificaRgEstado")]
        public IActionResult verificaRgEstado([FromBody] GrupoFamiliarViewModel model)
        {
            return Ok(_service.GrupoFamiliar.verificaRgEstado(model));
        }

        [HttpPost]
        [Authorize]
        [Route("verificaCpf")]
        public IActionResult verificaCpf([FromBody] GrupoFamiliarViewModel model)
        {
            return Ok(_service.GrupoFamiliar.verificaCpf(model));
        }

        [HttpPost]
        [Authorize]
        [Route("upload/{id}")]
        public IActionResult UploadFoto(string id)
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] ImageByte = null;
                if (file == null) throw new Exception("File is null");
                if (file.Length == 0) throw new Exception("File is empty");

                using (Stream stream = file.OpenReadStream())
                {
                    using var binaryReader = new BinaryReader(stream);
                    ImageByte = binaryReader.ReadBytes((int)file.Length);
                }
                var result = _service.FotoDependencia.uploadFoto(id, ImageByte);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        [Route("membrosGrupoFamiliar")]
        public IActionResult GetMembrosGrupoFamiliar([FromBody] GrupoFamiliarFilterModel filter)
        {
            var response = _service.GrupoFamiliar.GetMembrosGrupoFamiliar(filter);
            return Ok(new PagedResponse<IPagedList<MembrosGrupoFamiliarViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("getGrupoFamiliarBuscar")]
        public IActionResult GetGrupoFamiliarBuscar([FromBody] GrupoFamiliarFilterModel filter)
        {
            var _user = User.Claims;
            filter.idsClientes = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            var response = _service.GrupoFamiliar.GetGrupoFamiliarBuscarFiltrador(filter);
            return Ok(new PagedResponse<IPagedList<GrupoFamiliarViewModel>>() { Data = response, Total = response.TotalItemCount });
        }
    }
}