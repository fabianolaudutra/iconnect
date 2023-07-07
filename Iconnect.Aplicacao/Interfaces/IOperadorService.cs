using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IOperadorService : IRepositoryBase<tb_ope_operador>
    {
        IPagedList<OperadorViewModel> GetOperadorFiltrado(OperadorFilterModel filter);
        List<OperadorViewModel> GetOperadoresByEmpresa(int idEmpresa);
        OperadorViewModel GetOperador(int id);
        int SalvarOperador(OperadorViewModel model);
        bool DeletarOperador(int id);
        byte[] GeraExcel(OperadorFilterModel filter);
        public List<GenericList> GetOperadoresCliente(int id);
        public List<GenericList> ListarPerfis();
    }
}