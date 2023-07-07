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
    public interface IGrupoPermissaoOperadorService : IRepositoryBase<tb_gpp_grupoPermissaoOperador>
    {
        public List<tb_gpp_grupoPermissaoOperador> ListarGrupoPermissaoOperador();
        public List<tb_gpp_grupoPermissaoOperador> ListarGrupoById(int id);
        public object InsertOrUpdate(GrupoPermissaoOperadorViewModel model, string UsuarioLogado);
        IPagedList<GrupoPermissaoOperadorViewModel> GetGrupoFiltrado(GrupoPermissaoOperadorFilterViewModel filter);
        public GrupoPermissaoOperadorViewModel GetGrupo(int id);
        public bool DeletarGrupo(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);
        public List<GenericList> BuscaTipos();

        public List<PermissoesGrupoViewModel> BuscaPermissoes(int id);
        byte[] GeraExcel(GrupoPermissaoOperadorFilterViewModel filter);



    }
}
