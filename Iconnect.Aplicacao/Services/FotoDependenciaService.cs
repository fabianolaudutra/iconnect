using System;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class FotoDependenciaService : RepositoryBase<tb_ftd_fotoDependencia>, IFotoDependenciaService
    {
        private IconnectCoreContext context;

        public FotoDependenciaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }
        public string uploadFoto(string id, byte[] imageByte)
        {

            string retorno = "0";
            tb_ftd_fotoDependencia tbFotoDependencia = new tb_ftd_fotoDependencia();
            try
            {

                if (imageByte != null)
                {
                    if (id == null || id == "0")
                    {
                        //criar

                        tbFotoDependencia.ftd_c_imagem = imageByte;
                        tbFotoDependencia.ftd_d_atualizado = DateTime.Now;
                        tbFotoDependencia.ftd_c_unique = Guid.NewGuid();
                        Insert(tbFotoDependencia);

                    }
                    else
                    {
                        tbFotoDependencia = (from foto in context.tb_ftd_fotoDependencia where foto.ftd_n_codigo == Convert.ToInt32(id) select foto).FirstOrDefault();
                        tbFotoDependencia.ftd_c_imagem = imageByte;
                        tbFotoDependencia.ftd_d_modificacao = DateTime.Now;
                        tbFotoDependencia.ftd_d_atualizado = DateTime.Now;
                        Update(tbFotoDependencia);

                    }
                    context.SaveChanges();
                    retorno = tbFotoDependencia.ftd_n_codigo.ToString();
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
                tb_ftd_fotoDependencia foto = (from ftd in context.tb_ftd_fotoDependencia where ftd.ftd_n_codigo == Convert.ToInt32(id) select ftd).FirstOrDefault();
                b = foto.ftd_c_imagem;

                return b;

            }
            return b;

        }

        public bool DeletarFoto(int id)
        {
            try
            {
                Delete(context.tb_ftd_fotoDependencia.Find(id));
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
