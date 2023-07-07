using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ISolicitarZeladorService : IRepositoryBase<tb_soz_solicitarZelador>
    {
        IPagedList<SolicitarZeladorViewModel> GetSolicitarZeladorFiltrado(SolicitarZeladorFilterModel filter);
        byte[] GeraExcel(SolicitarZeladorFilterModel filter);
        SolicitarZeladorViewModel GetOcorrencia(int id);
        bool SalvarTratamentoOcorrencia(SolicitarZeladorViewModel model);
        byte[] GetFoto(int id);
        SolicitacaoZeladorSignalRViewModel GetOcorrenciaAtualizacaoGrid(int ocorrenciaId);
    }
}