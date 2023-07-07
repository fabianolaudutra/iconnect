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
    public class PetController : PadraoController
    {

        private readonly IServiceWrapper _service;

        private readonly ILogger<PetController> _logger;

        public PetController(ILogger<PetController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] PetFilterModel filter)
        {
            var response = _service.Pet.GetPetFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<PetViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] PetViewModel model)
        {
            return Ok(_service.Pet.SalvarPet(model));
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.Pet.DeletarPet(id));
        }


        [HttpGet]
        [Authorize]
        [Route("deletarSemGrupo")]
        public IActionResult DeletarPetSemGrupo()
        {
            return Ok(_service.Pet.DeletarPetSemGrupo());
        }
    }
}