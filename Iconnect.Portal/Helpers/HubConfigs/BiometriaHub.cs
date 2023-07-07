using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Iconnect.Portal.HubConfigs
{
    public class BiometriaHub : Hub
    {
        public Task SendMessage(string idBiometria, string mensagem, string chave)
        {
            return Clients.All.SendAsync("notificarBiometria", new { IdBiometria = idBiometria, Mensagem = mensagem, Chave = chave });
        }
    }
}
