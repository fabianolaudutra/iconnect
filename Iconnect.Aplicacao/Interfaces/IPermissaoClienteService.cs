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
    public interface IPermissaoClienteService : IRepositoryBase<tb_pec_permissaoCliente>
    {
        IPagedList<PermissaoClienteViewModel> GetPermissaoClienteFiltrado(PermissaoClienteFilterModel filter);
        
        public bool SalvarPermissaoCliente(PermissaoClienteViewModel model);

        public bool DeletarPermissaoCliente(int id);

        public bool DeletarPermissaoClienteSemOperador();

        public bool VincularPermissoes(int idOperador);
    }
}