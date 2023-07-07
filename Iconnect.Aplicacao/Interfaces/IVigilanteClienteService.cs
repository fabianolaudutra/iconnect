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
    public interface IVigilanteClienteService : IRepositoryBase<tb_vic_vigilanteCliente>
    {
        public VigilanteClienteViewModel InsertOrUpdate(VigilanteClienteViewModel model);
        IPagedList<VigilanteClienteViewModel> GetVigilanteFiltrado(VigilanteClienteFilterModel filter);
        public VigilanteClienteViewModel GetVigilante(int id);
        public bool DeletarVigilante(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);
        public List<VigilanteClienteViewModel> GetVigilantesByCliente(int idCliente);
    }
}
