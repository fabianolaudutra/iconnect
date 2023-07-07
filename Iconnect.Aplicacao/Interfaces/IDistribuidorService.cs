using Iconnect.Infraestrutura.Models;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using Iconnect.Aplicacao.FilterModel;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IDistribuidorService : IRepositoryBase<tb_dis_distribuidor>
    {
        object InsertOrUpdate(DistribuidorViewModel model);
        IPagedList<DistribuidorViewModel> GetDistribuidorFiltrado(DistribuidorFilterModel filter);
        bool Deletar(int id);
        List<DistribuidorViewModel> GetDistribuidor();
        DistribuidorViewModel GetDistribuidorEditar(int id);
        string VerificaDuplicado(string cnpj, string email);
    }
}
