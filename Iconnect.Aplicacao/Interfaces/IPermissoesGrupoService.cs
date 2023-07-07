using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IPermissoesGrupoService : IRepositoryBase<tb_pgp_permissoesGrupo>
    {
        public object InsertOrUpdate(PermissoesGrupoViewModel model);
    }
}
