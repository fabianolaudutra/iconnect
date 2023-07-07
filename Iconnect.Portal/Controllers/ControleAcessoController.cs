using Iconnect.Aplicacao;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Exceptions;
using Iconnect.Portal.HubConfigs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleAcessoController : PadraoController
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<ControleAcessoController> _logger;
        private readonly IHubContext<BiometriaHub> _hub;

        public ControleAcessoController(ILogger<ControleAcessoController> logger, IServiceWrapper service, IHttpContextAccessor acessor, IHubContext<BiometriaHub> hub) : base(acessor)
        {
            _logger = logger;
            _service = service;
            _hub = hub;
        }

        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] ControleAcessoFilterModel filter)
        {
            var response = _service.ControleAcesso.GetControleAcessoFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<ControleAcessoViewModel>>() { Data = response, Total = response.TotalItemCount });
        }

        [HttpPost]
        [Authorize]
        [Route("salvar")]
        public IActionResult Post([FromBody] ControleAcessoViewModel model)
        {
            var ret = new RetornoViewModel();
            try
            {
                ret.Entidade = _service.ControleAcesso.SalvarControleAcesso(model, true);
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
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.ControleAcesso.DeleteComSincronizacao(id));
        }

        [HttpGet]
        [Authorize]
        [Route("deletarSemGrupo")]
        public IActionResult DeletarControleAcessoSemPessoa()
        {
            return Ok(_service.ControleAcesso.DeletarControleAcessoSemPessoa());
        }

        [HttpPost]
        [Authorize]
        [Route("reutilizaNumeroCartao")]
        public IActionResult ReutilizaNumeroCartao(ControleAcessoViewModel model)
        {
            try
            {
                foreach (var item in model.cacOld.Distinct())
                {
                    _service.ControleAcesso.DeleteComSincronizacao(item);
                }

                //Adiciono novo registro na cac
                string idAux = null;
                switch (model.origem)
                {
                    case "MORADOR":
                        idAux = !string.IsNullOrEmpty(model.cac_mor_n_codigo) && !model.cac_mor_n_codigo.Equals("0") ? model.cac_mor_n_codigo : null;
                        break;
                    case "PRESTADOR":
                        idAux = !string.IsNullOrEmpty(model.cac_pse_n_codigo) && !model.cac_pse_n_codigo.Equals("0") ? model.cac_pse_n_codigo : null;
                        break;
                    case "VISITANTE":
                        idAux = !string.IsNullOrEmpty(model.cac_vis_n_codigo) && !model.cac_vis_n_codigo.Equals("0") ? model.cac_vis_n_codigo : null;
                        break;
                }

                if (idAux == null)
                {
                    var _user = User.Claims;
                    model.cac_usu_n_codigo = _user.FirstOrDefault(x => x.Type == "id").Value;
                }

                model.cac_d_modificacao = DateTime.Now.ToString();
                _service.ControleAcesso.SalvarControleAcesso(model, true);

                return Ok(true);
            }
            catch (Exception)
            {
                return Ok(false);
            }
        }

        [HttpGet]
        [Route("notificarBiometria")]
        public IActionResult NotificarBiometria(string idBiometria, string mensagem, string chave)
        {
            _hub.Clients.All.SendAsync("notificarBiometria", new { IdBiometria = idBiometria, Mensagem = mensagem, Chave = chave });
            return Ok(new { Message = "Request Completed" });
        }

        [HttpPost]
        [Route("solicitacaoBiometria")]
        public IActionResult SolicitacaoBiometria([FromBody] SolicitacaoBiometricaViewModel obj)
        {
            try
            {
                _ = obj ?? throw new Exception();

                var ret = _service.ControleAcesso.SolicitacaoBiometria(obj.ClienteId, obj.ControladoraId);

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return Ok(0);
            }
        }

        [HttpGet]
        [Route("carregaComboDispositivoBiometrico/{cli_n_codigo}")]
        public IActionResult CarregaComboDispositivoBiometrico(int cli_n_codigo)
        {
            try
            {
                var ret = _service.ControleAcesso.CarregaComboDispositivoBiometrico(cli_n_codigo);

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return Ok("");
            }
        }

        [HttpGet]
        [Route("getImagemBiometria/{bio_n_codigo}")]
        public IActionResult GetImagemBiometria(int bio_n_codigo)
        {
            var ret = new RetornoViewModel();
            try
            {
                var img = _service.ControleAcesso.GetImagemBiometria(bio_n_codigo);
                ret.Entidade = img;
                ret.Success = "Imagem digital";

                return Ok(ret);
            }
            catch (MensagemException ex)
            {
                return Ok(ret.Error = ex.Message);
            }
            catch (Exception)
            {
                return Ok(ret.Error = "Não foi possível obter imagem da digital.");
            }
        }
        
        [HttpGet]
        [Authorize]
        [Route("gerarQrCodeLiberacaoApp/{id}")]
        public IActionResult GerarQrCodeLiberacaoApp(int id)
        {
            return Ok(_service.ControleAcesso.GerarQrCodeLiberacaoApp(id));
        }

        [HttpGet]
        [Authorize]
        [Route("criptografar/{parametro}")]
        public IActionResult Criptografar(string parametro)
        {
            var ret = new RetornoViewModel();
            try
            {
                ret.Entidade = _service.ControleAcesso.Criptografar(parametro);
                ret.Success = "";
                return Ok(ret);
            }
            catch (MensagemException ex)
            {
                return Ok(ret.Error = ex.Message);
            }
            catch (Exception)
            {
                return Ok(ret.Error = "");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("descriptografar/{parametro}")]
        public IActionResult Descriptografar(string parametro)
        {
            var ret = new RetornoViewModel();
            try
            {
                ret.Entidade = _service.ControleAcesso.Descriptografar(parametro);
                ret.Success = "";
                return Ok(ret);
            }
            catch (MensagemException ex)
            {
                return Ok(ret.Error = ex.Message);
            }
            catch (Exception)
            {
                return Ok(ret.Error = "");
            }
        }

        [HttpGet]
        [Route("getAcessoByGuid/{guid}")]
        public IActionResult GetAcessoByGuid(string guid)
        {
            return Ok(_service.ControleAcesso.GetAcessoByGuid(guid));
        }

        [HttpGet]
        [Route("getAcessoVisitanteQR/{id}")]
        public IActionResult GetAcessoVisitanteQR(int id)
        {
            return Ok(_service.ControleAcesso.GetAcessoVisitanteQR(id));
        }
    }
}