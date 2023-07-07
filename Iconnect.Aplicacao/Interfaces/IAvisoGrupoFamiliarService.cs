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
    public interface IAvisoGrupoFamiliarService : IRepositoryBase<tb_avg_avisoGrupoFamiliar>
    {
        IPagedList<AvisoGrupoFamiliarViewModel> GetAvisoGrupoFamiliarFiltrado(AvisoGrupoFamiliarFilterModel filter);
        
        public bool SalvarAvisoGrupoFamiliar(AvisoGrupoFamiliarViewModel model);

        public bool DeletarAvisoGrupoFamiliar(int id);

        public bool DeletarAvisoGrupoFamiliarSemGrupo();

        public bool VincularAvisos(int idGrupo);
    }
}