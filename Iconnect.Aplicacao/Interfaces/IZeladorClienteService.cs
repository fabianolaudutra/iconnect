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
    public interface IZeladorClienteService : IRepositoryBase<tb_zec_zeladorCliente>
    {
        public void InsertOrUpdate(ZeladorClienteViewModel model);
        IPagedList<ZeladorClienteViewModel> GetZeladorFiltrado(ZeladorClienteFilterModel filter);
        public ZeladorClienteViewModel GetZelador(int id);
        public bool DeletarZelador(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);
        public List<GenericList> GetZeladoresCliente(int id);
    }
}
