using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
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
    public class RegistroSalaoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<RegistroSalaoController> _logger;

        public RegistroSalaoController(ILogger<RegistroSalaoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Salvar([FromBody] RegistroSalaoViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                var _user = User.Claims;
                int perfil = Convert.ToInt32(_user.FirstOrDefault(x => x.Type == "Perfil").Value);

                _service.RegistroSalao.InsertOrUpdate(model, perfil);

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
                ret.Error = "Ocorreu um erro ao salvar os dados";
                return Ok(ret);
            }
        }

        [HttpGet]
        [Route("editar/{id}")]
        public RegistroSalaoViewModel GetReserva(int id)
        {
            return _service.RegistroSalao.GetReserva(id);
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{id}")]
        public List<RegistroSalaoViewModel> GetReservas(int id)
        {
            var _user = User.Claims;
            int idEmp = Convert.ToInt32(_user.FirstOrDefault(x => x.Type == "idEmp").Value);
            string ids = _user.FirstOrDefault(x => x.Type == "idsCli").Value;
            return _service.RegistroSalao.GetReservas(id);
        }

        [HttpPost]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] RegistroSalaoFilterModel filter)
        {
            var _user = User.Claims;
            int idEmp = Convert.ToInt32(_user.FirstOrDefault(x => x.Type == "idEmp").Value);
            string ids = _user.FirstOrDefault(x => x.Type == "idsCli").Value;

            var response = _service.RegistroSalao.GetFiltrado(filter, ids);
            return Ok(new PagedResponse<IPagedList<RegistroSalaoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Route("buscarByData")]
        public IActionResult GetByData([FromBody] RegistroSalaoFilterModel filter)
        {
            var response = _service.RegistroSalao.GetByData(filter);
            return Ok(response);
        }

        [HttpGet]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.RegistroSalao.Deletar(id));
        }

        [HttpGet]
        [Route("aprovar/{id}")]
        public IActionResult Aprovar(int id)
        {
            return Ok(_service.RegistroSalao.Aprovar(id));
        }
    }
}