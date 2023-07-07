using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;
namespace Iconnect.Aplicacao.Interfaces
{
    public interface IUsuarioSalaComercialService : IRepositoryBase<tb_usc_usuarioSalaComercial>
    {
        IPagedList<UsuarioSalaComercialViewModel> GetUsuarioSalaFiltrado(UsuarioSalaComercialFilterModel filter);
        public void InsertOrUpdate(UsuarioSalaComercialViewModel model);
        public UsuarioSalaComercialViewModel GetUsuarioById(int id);
        public bool DeletarUsuario(int id);
    }
}
