using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IEmpresaService : IRepositoryBase<tb_emp_empresa>
    {
        IPagedList<EmpresaViewModel> GetEmpresaFiltrado(EmpresaFilterModel filter);
        public List<EmpresaViewModel> GetEmpresas();
        public object InsertOrUpdate(EmpresaViewModel model);
        public EmpresaViewModel GetEmpresa(int id);
        public bool DeletarEmpresa(int id);
        public List<EmpresaViewModel> getEmpresaCnpj(EmpresaViewModel model);
        public List<EmpresaViewModel> GetRelEmpresa(DistribuidorViewModel model);
        byte[] GeraExcel(EmpresaFilterModel filter);
        List<ComboEmpresaViewModel> ObterComboEmpresa(string empresasId);
        List<EmpresaViewModel> GetComboEmpresa(int idDistribuidor);
        List<EmpresaViewModel> GetEmpresaByDistribuidor(int id);
        List<ComboEmpresaViewModel> ComboIntegradorRelMovimentacao();
        string[] GetRamaisEmpresa(int id);
    }
}
