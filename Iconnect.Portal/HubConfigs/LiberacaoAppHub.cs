using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Enums;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Iconnect.Portal.HubConfigs
{
    public class LiberacaoAppHub : Hub
    {
        private readonly IServiceWrapper _service;
        public LiberacaoAppHub(IServiceWrapper service)
        {
            _service = service;
        }

        public Task SendMessage(string idCliente)
        {
            return Clients.All.SendAsync("atualizarControleDeAcesso", new { IdCliente = idCliente });
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

            _service.ConnectionSignalR.IncluirAlterar(objSave, EnumHubs.LiberacaoApp);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _service.ConnectionSignalR.Remover(Context.ConnectionId, EnumHubs.LiberacaoApp);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
