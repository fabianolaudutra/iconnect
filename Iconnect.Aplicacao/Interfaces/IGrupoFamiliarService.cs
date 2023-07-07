using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IGrupoFamiliarService : IRepositoryBase<tb_grf_grupoFamiliar>
    {
        List<GrupoFamiliarViewModel> GetGruposFamiliar();
        GrupoFamiliarViewModel GetGrupoFamiliar(int id);
        List<GrupoFamiliarViewModel> GetGruposFamiliarByCliente(int idCliente);
        List<GrupoFamiliarViewModel> GetResponsavelByCliente(int idCliente);
        IPagedList<GrupoFamiliarViewModel> GetGrupoFamiliarFiltrado(GrupoFamiliarFilterModel filter);
        byte[] GeraExcel(GrupoFamiliarFilterModel filter);
        public object SalvarGrupoFamiliar(GrupoFamiliarViewModel model);
        bool DeletarGrupoFamiliar(int id);
        bool GetResetSenha(int id);
        GrupoFamiliarViewModel GetGruposByMorador(int idMorador);
        bool verificaEmail(GrupoFamiliarViewModel model);
        bool verificaRamal(GrupoFamiliarViewModel model);
        GrupoFamiliarViewModel SalaComercial(int id);
        bool verificaRgEstado(GrupoFamiliarViewModel model);
        bool verificaCpf(GrupoFamiliarViewModel model);
        IPagedList<MembrosGrupoFamiliarViewModel> GetMembrosGrupoFamiliar(GrupoFamiliarFilterModel filter);
        IPagedList<GrupoFamiliarViewModel> GetGrupoFamiliarBuscarFiltrador(GrupoFamiliarFilterModel filter);
    }
}