using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Enums;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnect.Portal.Helpers.HubConfigs
{
    public class ComboClienteGuardHub : Hub
    {
        private readonly IServiceWrapper _service;
        public ComboClienteGuardHub(IServiceWrapper service)
        {
            _service = service;
        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var usuarioId = httpContext.Request.Query["idProp"];
            var dadosJson = httpContext.Request.Cookies["dados_usuario"];

            var dadosUsuario = JsonConvert.DeserializeObject<DadosClienteCookieViewModel>(dadosJson);

            var objSave = new SaveConnectionSignalRViewModel
            {
                ClienteId = usuarioId,
                ConnectionId = Context.ConnectionId,
                IdsClientes = dadosUsuario?.idsCli,
                Perfil = dadosUsuario?.Perfil,
                UsuarioId = usuarioId
            };

            _service.ConnectionSignalR.IncluirAlterar(objSave, EnumHubs.ComboClienteGuard);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _service.ConnectionSignalR.Remover(Context.ConnectionId, EnumHubs.ComboClienteGuard);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
