using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ICategorizacaoEventoService : IRepositoryBase<tb_cev_categorizacaoEvento>
    {
        IPagedList<CategorizacaoEventoViewModel> GetCategoFiltrado(CategorizacaoEventoFilterModel filter);
        CategorizacaoEventoViewModel GetCategorizacaoEvento(int id);
        int SalvarCategorizacaoEvento(CategorizacaoEventoViewModel model);
        bool DeletarCategorizacaoEvento(int id);
        byte[] GeraExcel(CategorizacaoEventoFilterModel filter);
        public List<CategorizacaoEventoViewModel> GetAll();
    }
}
