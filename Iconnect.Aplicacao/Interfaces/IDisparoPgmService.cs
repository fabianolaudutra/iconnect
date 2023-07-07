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
    public interface IDisparoPgmService : IRepositoryBase<tb_dpg_disparoPGM>
    {
        public bool SalvarDisparoPgm(DisparoPgmViewModel model);
    }
}