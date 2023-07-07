using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ICategorizacaoAvisoService : IRepositoryBase<tb_cav_categorizacaoAviso>
    {
        IPagedList<CategorizacaoAvisoViewModel> GetAvisoFiltrado(CategorizacaoAvisoFilterModel filter);
        CategorizacaoAvisoViewModel GetAviso(int id);
        int SalvarAviso(CategorizacaoAvisoViewModel model);
        bool DeletarAviso(int id);
        byte[] GeraExcel(CategorizacaoAvisoFilterModel filter);
        public List<CategorizacaoAvisoViewModel> GetAll();
    }
}
