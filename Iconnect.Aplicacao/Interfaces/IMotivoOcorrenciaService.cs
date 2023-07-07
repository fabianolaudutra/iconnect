using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IMotivoOcorrenciaService : IRepositoryBase<tb_moc_motivoOcorrenciaCliente>
    {
        public MotivoOcorrenciaViewModel InsertOrUpdate(MotivoOcorrenciaViewModel model);
        IPagedList<MotivoOcorrenciaViewModel> GetMotivoFiltrado(MotivoOcorrenciaFilterModel filter);
        public MotivoOcorrenciaViewModel GetMotivo(int id);
        public bool DeletarMotivo(int id);
        bool ExcluirTemporarios();
        public bool Vincular(int id);
        public List<MotivoOcorrenciaViewModel> GetMotivosByCliente(int id);
    }
}
