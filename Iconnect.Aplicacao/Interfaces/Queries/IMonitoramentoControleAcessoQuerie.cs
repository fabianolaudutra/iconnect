using Iconnect.Aplicacao.Dtos;

namespace Iconnect.Aplicacao.Interfaces.Queries
{
    public interface IMonitoramentoControleAcessoQuerie
    {
        MonitoramentoControleAcessoDto GetAcessoAtualizacaoGrid(int clienteId);
    }
}