using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IPermissionamentoService : IRepositoryBase<tb_per_permissionamento>
    {
        public List<PermissionamentoViewModel> ListarPermissionamentos();

        public List<PermissionamentoViewModel> ObterDadosPermissionamento(Guid id);
        public bool SalvarPermissionamento(PermissionamentoViewModel model);
        IPagedList<PermissionamentoViewModel> GetPermissionamentosFiltrado(PermissionamentoFilterModel filter);
        public bool DeletarPermissionamento(Guid id);

    }
}
