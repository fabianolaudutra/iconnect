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
    public interface ICanalLayoutService : IRepositoryBase<tb_can_canalLayout>
    {
        public object InsertOrUpdate(CanalLayoutViewModel model);
        public bool Deletar(int id);
        public bool DeleteCanaisByLayout(int id);
    }
}
