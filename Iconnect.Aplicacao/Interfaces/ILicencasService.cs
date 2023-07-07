using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ILicencasService : IRepositoryBase<vw_licencas>
    {

        // IPagedList<ZoneamentoClienteViewModel> GetZoneamentoFiltrado(ZoneamentoClienteFilterModel filter);
        // public ZoneamentoClienteViewModel InsertOrUpdate(ZoneamentoClienteViewModel model);
        // public ZoneamentoClienteViewModel GetZoneamento(int id);
        // public bool DeletarZoneamento(int id);

        public IPagedList<EmpresaViewModel> GetEmpresasFiltrado(EmpresaFilterModel filter);
        public IPagedList<ClienteViewModel> GetClientesFiltrado(ClienteFilterModel filter);
        byte[] GeraExcel(EmpresaFilterModel filter);
        byte[] GeraExcelCliente(ClienteFilterModel filter);
        public List<GenericList> ClientesSemLicenca(int codigo);
        List<GenericList> TodosClientesSemLicenca();
        void MontaEmailNovoCliente();
        void MontaEmailAlteracaoCliente(ClienteViewModel cliente);
        void MontaEmailAlteracaoModulos(ModuloViewModel cliente);
    }
}