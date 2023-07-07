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
    public interface ILimpezaClienteService : IRepositoryBase<tb_pec_processoExclusaoCliente>
    {
        public object SalvarLimpeza(LimpezaClienteViewModel model);
        public bool LimpezaAccessByCliente(int idCliente);
        public bool DeletarLimpeza(int id);
        IPagedList<LimpezaClienteViewModel> ListarLimpezas(LimpezaClienteFilterModel filter);

    }
}
