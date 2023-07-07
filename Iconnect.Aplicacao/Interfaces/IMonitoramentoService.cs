using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IMonitoramentoService : IRepositoryBase<tb_mon_monitoramento>
    {
        IPagedList<MonitoramentoViewModel> GetMonitoramentoFiltrado(MonitoramentoFilterModel filter);
        MonitoramentoViewModel GetMonitoramento(int id);
        bool SalvarMonitoramento(MonitoramentoViewModel model);
        byte[] getRelatorioMonitoramento(MonitoramentoViewModel model);
        IList<int?> ClientesComAlerta(IList<int> idsClientes);
        MonitoramentoViewModel GetMonitoramentoAtualizacaoGrid(string clienteId, string statusCod);
    }
}