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
    public interface IDispositivoCFTVService : IRepositoryBase<tb_ddv_dispositivoDVRCliente>
    {
        public DispositivoCFTVViewModel InsertOrUpdate(DispositivoCFTVViewModel model);
        IPagedList<DispositivoCFTVViewModel> GetDispositivoFiltrado(DispositivoCFTVFilterModel filter);
        public DispositivoCFTVViewModel GetDispositivo(int id);
        public DispositivoCFTVViewModel GetDispositivoByLayout(int id);
        public bool DeletarDispositivo(int id);
        public List<GenericList> ListarDispositivos(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);



    }
}
