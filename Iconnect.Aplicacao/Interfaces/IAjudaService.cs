using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IAjudaService
    {
        int InsertOrUpdate(AjudaViewModel model);
        AjudaViewModel GetAjuda(int idAjuda);
        List<AjudaViewModel> GetAjudaFiltrado(AjudaFilterModel filter);
        void Deletar(int id);
        IPagedList<AjudaViewModel> GetCadastroAjudaFiltrado(AjudaFilterModel filter);
    }
}
