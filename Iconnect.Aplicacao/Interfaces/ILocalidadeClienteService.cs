using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ILocalidadeClienteService : IRepositoryBase<tb_lcc_localidadeCliente>
    {
        public object InsertOrUpdate(LocalidadeClienteViewModel model);
        IPagedList<LocalidadeClienteViewModel> GetLocalidadeFiltrado(LocalidadeClienteFilterModel filter);
        public LocalidadeClienteViewModel GetLocalidade(int id);

        public bool DeletarLocalidade(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);

        public List<GenericList> GetLocalidades(int id);

        List<LocalidadeClienteViewModel> GetLocalidadeByTipo(int idCliente, string tipo);

        List<GenericList> GetLocalidadeComboByTipo(int idCliente, string tipo);

        public GenericList GetLocalidadeByIds(string id);

    }
}
