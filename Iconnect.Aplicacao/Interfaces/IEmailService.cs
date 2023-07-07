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
    public interface IEmailService : IRepositoryBase<tb_ema_email>
    {
        public object InsertOrUpdate(EmailViewModel model);
        public ParametrosEmpresaViewModel FindParametrosEmpresa(ParametrosEmpresaViewModel parametros);

    }
}
