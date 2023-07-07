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
    public interface IUploadAPKService : IRepositoryBase<tb_upa_uploadAPK>
    {
        IPagedList<UploadAPK> GetApkFiltrado(UploadApkFilterModel filter);
        public UploadAPK GetAPK(int id);
        public bool SalvarAPK(UploadAPK model, string usuarioLogado);
        public bool DeletarAPK(int id);

        public bool SaveArquivo(UploadAPK model);
        public bool deletarAll();
    }
}
