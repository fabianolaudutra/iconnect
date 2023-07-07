using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IMonitoramentoControleAcessoService : IRepositoryBase<tb_con_monitoramentoControleAcesso>
    {
        IPagedList<MonitoramentoControleAcessoViewModel> GetMonitoramentoControleAcessoFiltrado(MonitoramentoControleAcessoFilterModel filter);
        bool DispararAberturaRemota(SolicitacaoAberturaRemotaViewModel sol);
        MonitoramentoControleAcessoViewModel GetAcesso(int id);
        bool SalvarTratamentoPanico(MonitoramentoControleAcessoViewModel model);
        List<MonitoramentoControleAcessoViewModel> getRelatorioDestino(MonitoramentoControleAcessoViewModel model);
        List<MonitoramentoControleAcessoViewModel> getRelatorioControleAcesso(MonitoramentoControleAcessoViewModel model);
        byte[] GetRelRefeitorio(MonitoramentoControleAcessoViewModel model);
        IPagedList<MonitoramentoControleAcessoViewModel> GetAcessosPorPessoa(MonitoramentoControleAcessoFilterModel filter);
    }
}