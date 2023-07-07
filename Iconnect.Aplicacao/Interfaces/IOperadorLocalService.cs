using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IOperadorLocalService : IRepositoryBase<tb_opl_operadorLocal>
    {
        IPagedList<OperadorLocalViewModel> GetOperadorLocalFiltrado(OperadorLocalFilterModel filter);
        OperadorLocalViewModel GetOperadorLocal(int id);
        int SalvarOperadorLocal(OperadorLocalViewModel model);
        bool DeletarOperadorLocal(int id);
        byte[] GeraExcel(OperadorLocalFilterModel filter);
        List<GenericList> GetOperadorLocalCliente(int id);
    }
}
