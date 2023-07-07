using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Iconnect.Aplicacao.Services
{
    class UploadAPKService : RepositoryBase<tb_upa_uploadAPK>, IUploadAPKService
    {
        private IconnectCoreContext context;

        public UploadAPKService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarAPK(int id)
        {
            try
            {
                Delete(context.tb_upa_uploadAPK.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public bool deletarAll()
        {
            try
            {
                context.Database.ExecuteSqlRaw("exec [EXECUTA_EXCLUSAO_APK]");
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public bool SalvarAPK(UploadAPK model,string usuarioLogado)
        {
            try
            {
                deletarAll();
                Insert(new tb_upa_uploadAPK()
                {
                    upa_c_arquivo = model.upa_c_arquivo,
                    upa_c_unique = Guid.NewGuid(),
                    upa_c_nome = "GAREN",
                    upa_n_versaoName = model.upa_n_versaoCode.ToString(),
                    upa_n_versaoCode = model.upa_n_versaoCode,
                    upa_d_inclusao = DateTime.Now
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        public UploadAPK GetAPK(int id)
        {
            /*Buscamos APK sem where pois a intenção é
             *sempre conter 1 unico registro nesta tabela
             para controle de versão do Garen Connect */
          var query = (from apk in context.tb_upa_uploadAPK
                    select new UploadAPK()
                    {
                        upa_n_codigo = apk.upa_n_codigo,
                        upa_c_nome = apk.upa_c_nome,
                        upa_n_versaoName = apk.upa_n_versaoName,
                        upa_n_versaoCode  = apk.upa_n_versaoCode,
                        upa_d_inclusao = apk.upa_d_inclusao.Value.ToString("dd/MM/yyyy")

                    }).FirstOrDefault();
            return query;
        }
        public List<UploadApkFilterModel> GetAll()
        {
            return null;
        }
        IPagedList<UploadAPK> IUploadAPKService.GetApkFiltrado(UploadApkFilterModel filter)
        {
            var query = (from apk in Context.tb_upa_uploadAPK
                         select new UploadAPK
                         {
                             upa_n_codigo = apk.upa_n_codigo,
                             upa_c_nome = apk.upa_c_nome,
                             upa_n_versaoName = apk.upa_n_versaoName,
                             upa_n_versaoCode = apk.upa_n_versaoCode,
                             upa_d_inclusao = apk.upa_d_inclusao.Value.ToString("dd/MM/yyyy")
                         });
            if (!string.IsNullOrEmpty(filter.Nome))
            {
                query = query.Where(w => w.upa_c_nome.Contains(filter.Nome));
            }
            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SaveArquivo(UploadAPK model)
        {
            try
            {
                /*DESCONTINUADO*/
                deletarAll();
                Insert(new tb_upa_uploadAPK()
                {
                    upa_c_arquivo = model.upa_c_arquivo,
                    upa_c_unique = Guid.NewGuid(),
                    upa_c_nome = "GAREN",
                    upa_n_versaoName = model.upa_n_versaoCode.ToString(),
                    upa_n_versaoCode = model.upa_n_versaoCode,
                    upa_d_inclusao = DateTime.Now
                });
                context.SaveChanges();
                return true;
            }
            catch(Exception ex) { 
            }
            return false;
        }
    }
}
