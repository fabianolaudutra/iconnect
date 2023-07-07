using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Enums;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Iconnect.Portal.HubConfigs
{
    public class ControleDeOcorrenciaHub : Hub
    {
        private readonly IServiceWrapper _service;


        public ControleDeOcorrenciaHub(IServiceWrapper service)
        {
            _service = service;
        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var clienteId = httpContext.Request.Query["idProp"];
            var dadosJson = httpContext.Request.Cookies["dados_usuario"];

            var dadosUsuario = JsonConvert.DeserializeObject<DadosClienteCookieViewModel>(dadosJson);

            var objSave = new SaveConnectionSignalRViewModel
            {
                ClienteId = clienteId,
                ConnectionId = Context.ConnectionId,
                IdsClientes = dadosUsuario?.idsCli,
                Perfil = dadosUsuario?.Perfil,
                UsuarioId = dadosUsuario?.idUsuario
            };

           // _service.ConnectionSignalR.IncluirAlterar(objSave, EnumHubs.ControleDeOcorrencia);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
           // _service.ConnectionSignalR.Remover(Context.ConnectionId, EnumHubs.ControleDeOcorrencia);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
