using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IRegistroSalaoService : IRepositoryBase<tb_res_registroSalao>
    {
        public void InsertOrUpdate(RegistroSalaoViewModel model, int perfil);
        public List<RegistroSalaoViewModel> GetReservas(int id);
        IPagedList<RegistroSalaoViewModel> GetFiltrado(RegistroSalaoFilterModel filter, string ids);
        IList<RegistroSalaoViewModel> GetByData(RegistroSalaoFilterModel filter);
        public RegistroSalaoViewModel GetReserva(int id);
        public bool Deletar(int id);
        public bool Aprovar(int id);
    }
}
