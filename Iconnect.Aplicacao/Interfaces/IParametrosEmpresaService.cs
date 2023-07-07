using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IParametrosEmpresaService : IRepositoryBase<tb_par_parametrosEmpresa>
    {
        public object InsertOrUpdate(ParametrosEmpresaViewModel model);
        public ParametrosEmpresaViewModel FindParametrosEmpresa(ParametrosEmpresaViewModel parametros);
    }
}
