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
    public interface ILayoutService : IRepositoryBase<tb_lay_layout>
    {
        public LayoutViewModel InsertOrUpdate(LayoutViewModel model);
        public bool Deletar(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);
    }
}
