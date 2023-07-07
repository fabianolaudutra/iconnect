using System;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;


namespace Iconnect.Aplicacao.Services
{
    class FotoEmpresaService : RepositoryBase<tb_fem_fotoEmpresa>, IFotoEmpresaService
    {
        private IconnectCoreContext context;

        public FotoEmpresaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public string uploadFoto(string id, byte[] imageByte)
        {

            string retorno = "0";
            tb_fem_fotoEmpresa tbFotoEmpresa = new tb_fem_fotoEmpresa();
            try
            {

                if (imageByte != null)
                {
                    if (id == null || id == "0")
                    {
                        //criar

                        tbFotoEmpresa.fem_c_imagem = imageByte;
                        tbFotoEmpresa.fem_d_atualizado = DateTime.Now;
                        tbFotoEmpresa.fem_c_unique = Guid.NewGuid();
                        Insert(tbFotoEmpresa);

                    }
                    else
                    {
                        tbFotoEmpresa = (from foto in context.tb_fem_fotoEmpresa where foto.fem_n_codigo == Convert.ToInt32(id) select foto).FirstOrDefault();
                        tbFotoEmpresa.fem_c_imagem = imageByte;
                        tbFotoEmpresa.fem_d_modificacao = DateTime.Now;
                        tbFotoEmpresa.fem_d_atualizado = DateTime.Now;
                        Update(tbFotoEmpresa);

                    }
                    context.SaveChanges();
                    retorno = tbFotoEmpresa.fem_n_codigo.ToString();
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
                tb_fem_fotoEmpresa foto = (from fem in context.tb_fem_fotoEmpresa where fem.fem_n_codigo == Convert.ToInt32(id) select fem).FirstOrDefault();
                b = foto.fem_c_imagem;

                return b;

            }
            return b;

        }

        public bool DeletarFoto(int id)
        {
            try
            {
                Delete(context.tb_fem_fotoEmpresa.Find(id));
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
