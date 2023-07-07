using System;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using Iconnect.Aplicacao.FilterModel;

namespace Iconnect.Aplicacao.Services
{
    public class ArquivoDependenciaService : RepositoryBase<tb_ard_arquivoDependencias>, IArquivoDependenciaService
    {

        private IconnectCoreContext context;

        public ArquivoDependenciaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public string uploadArquivo(string id, string nome, byte[] imageByte)
        {

            string retorno = "0";
            tb_ard_arquivoDependencias ard = new tb_ard_arquivoDependencias();
            try
            {

                if (imageByte != null)
                {
                    if (id == null || id == "0")
                    {
                        //criar

                        ard.ard_blob_PDFImagem = imageByte;
                        ard.ard_d_atualizado = DateTime.Now;
                        ard.ard_d_inclusao = DateTime.Now;
                        ard.ard_d_modificacao = DateTime.Now;
                        ard.ard_c_nomePDFImagem = nome;
                        ard.ard_c_unique = Guid.NewGuid();
                        Insert(ard);
                    }
                    else
                    {
                        ard = (from arquivo in context.tb_ard_arquivoDependencias where arquivo.ard_n_codigo == Convert.ToInt32(id) select arquivo).FirstOrDefault();
                        ard.ard_blob_PDFImagem = imageByte;
                        ard.ard_d_modificacao = DateTime.Now;
                        ard.ard_c_nomePDFImagem = nome;
                        ard.ard_d_atualizado = DateTime.Now;
                        Update(ard);

                    }
                    context.SaveChanges();
                    retorno = ard.ard_n_codigo.ToString();
                    retorno += "," + ard.ard_c_nomePDFImagem;

                    return retorno;

                }
                return retorno;
            }
            catch (Exception)
            {
                retorno = "";

                return retorno;
                throw;
            }
        }

        public byte[] GetFoto(int id)
        {
            byte[] b = null;
            if (id != 0)
            {
                tb_ard_arquivoDependencias foto = (from ard in context.tb_ard_arquivoDependencias where ard.ard_n_codigo == Convert.ToInt32(id) select ard).FirstOrDefault();
                b = foto.ard_blob_PDFImagem;

                return b;

            }
            return b;

        }

        public byte[] GetArquivo(int id)
        {
            byte[] c = null;
            tb_ard_arquivoDependencias arquivo = (from ard in context.tb_ard_arquivoDependencias where ard.ard_n_codigo == Convert.ToInt32(id) select ard).FirstOrDefault();
            c = arquivo.ard_blob_PDFImagem;
            return c;
        }

        public byte[] GetImg(int id)
        {
            byte[] d = null;
            tb_ard_arquivoDependencias arquivo = (from ard in context.tb_ard_arquivoDependencias where ard.ard_n_codigo == Convert.ToInt32(id) select ard).FirstOrDefault();
            d = arquivo.ard_blob_PDFImagem;
            return d;
        }

        public bool DeletarArquivo(int id)
        {
            try
            {
                Delete(context.tb_ard_arquivoDependencias.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
