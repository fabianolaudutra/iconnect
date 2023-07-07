using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Bucket;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Exceptions;
using Iconnect.Infraestrutura.Models;
using System;
using System.IO;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class FotoService : RepositoryBase<tb_fot_foto>, IFotoService
    {
        private IconnectCoreContext context;

        public FotoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public string uploadFoto(string id, byte[] imageByte)
        {
            string retorno = "0";
            tb_fot_foto tbFoto;
            var unique_name = Guid.NewGuid();

            try
            {
                if (imageByte != null)
                {
                    if (string.IsNullOrEmpty(id) || id.Equals("0"))
                    {
                        MemoryStream stream = new MemoryStream();
                        stream.Write(imageByte, 0, imageByte.Length);

                        tbFoto = new tb_fot_foto
                        {
                            fot_d_atualizado = DateTime.Now,
                            fot_c_unique = unique_name,
                            fot_d_upload = DateTime.Now
                        };

                        tbFoto.fot_c_url = ManageFile.UploadFile(stream, $"{tbFoto.fot_c_unique}{tbFoto.fot_d_upload.Value.Ticks}", "jpeg");

                        Insert(tbFoto);
                    }
                    else
                    {
                        MemoryStream stream = new MemoryStream();
                        stream.Write(imageByte, 0, imageByte.Length);

                        tbFoto = (from foto in context.tb_fot_foto where foto.fot_n_codigo == Convert.ToInt32(id) select foto).FirstOrDefault();

                        DateTime oldUpload = DateTime.MinValue;
                        if (tbFoto.fot_d_upload != null && tbFoto.fot_d_upload > DateTime.MinValue)
                        {
                            oldUpload = tbFoto.fot_d_upload.Value;
                        }

                        tbFoto.fot_d_modificacao = DateTime.Now;
                        tbFoto.fot_d_atualizado = DateTime.Now;
                        tbFoto.fot_d_upload = DateTime.Now;

                        if (string.IsNullOrEmpty(tbFoto.fot_c_url))
                            tbFoto.fot_c_url = ManageFile.UploadFile(stream, $"{tbFoto.fot_c_unique}{tbFoto.fot_d_upload.Value.Ticks}", "jpeg");
                        else
                            tbFoto.fot_c_url = ManageFile.UpdateFile(stream, $"{tbFoto.fot_c_unique}{tbFoto.fot_d_upload.Value.Ticks}", $"{tbFoto.fot_c_unique}{oldUpload.Ticks}", "jpeg");

                        Update(tbFoto);
                    }

                    context.SaveChanges();
                    retorno = tbFoto.fot_n_codigo.ToString();
                    return retorno;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                ManageFile.DeleteFile(unique_name.ToString(), "jpeg");
                throw new MensagemException(ex.ToString());
            }
        }

        public RetornoFotoViewModel GetFoto(int id)
        {
            var ret = new RetornoFotoViewModel();

            if (id != 0)
            {
                ret = (from fot in context.tb_fot_foto
                       where fot.fot_n_codigo == Convert.ToInt32(id)
                       select new RetornoFotoViewModel
                       {
                           Id = fot.fot_n_codigo,
                           Url = fot.fot_c_url
                       })?.FirstOrDefault();

                if (ret != null && string.IsNullOrEmpty(ret?.Url))
                {
                    ret = (from fot in context.tb_fot_foto
                           where fot.fot_n_codigo == ret.Id
                           select new RetornoFotoViewModel
                           {
                               Id = fot.fot_n_codigo,
                               Imagem = fot.fot_c_imagem
                           })?.FirstOrDefault();
                }
            }

            return ret;
        }

        public bool DeletarFoto(int id)
        {
            try
            {
                var imagem = context.tb_fot_foto.Find(id);
                if (imagem == null)
                    throw new Exception("Imagem não encontrada");

                if (!string.IsNullOrEmpty(imagem.fot_c_url))
                {
                    ManageFile.DeleteFile($"{imagem.fot_c_unique}{imagem.fot_d_upload.Value.Ticks}", "jpeg");
                }

                var grupoFamiliar = context.tb_grf_grupoFamiliar.Where(x => x.grf_fot_n_codigo == id).ToList();
                var morador = context.tb_mor_Morador.Where(x => x.mor_fot_n_documento == id || x.mor_fot_n_codigo == id).ToList();
                var pet = context.tb_pet_pet.Where(x => x.pet_fot_n_codigo == id).ToList();
                var prestadorServico = context.tb_pse_prestadorServico.Where(x => x.pse_fot_n_codigo == id || x.pse_fot_n_documento == id).ToList();
                var visitante = context.tb_vis_visitante.Where(x => x.vis_fot_n_codigo == id || x.vis_fot_n_documento == id).ToList();
                var fotoFachada = context.tb_cli_cliente.Where(x => x.cli_fot_fachada_n_codigo == id).ToList();
                var catalogo = context.tb_cal_catalogo.Where(x => x.cal_fot_n_codigo == id || x.cal_logo_n_codigo == id).FirstOrDefault();

                foreach (var item in grupoFamiliar)
                {
                    item.grf_fot_n_codigo = null;
                    context.Update(item);
                }

                foreach (var item in pet)
                {
                    item.pet_fot_n_codigo = null;
                    context.Update(item);
                }

                foreach (var item in morador)
                {
                    if (item.mor_fot_n_codigo == id)
                        item.mor_fot_n_codigo = null;

                    if (item.mor_fot_n_documento == id)
                        item.mor_fot_n_documento = null;

                    context.Update(item);
                }

                foreach (var item in prestadorServico)
                {
                    if (item.pse_fot_n_codigo == id)
                        item.pse_fot_n_codigo = null;

                    if (item.pse_fot_n_documento == id)
                        item.pse_fot_n_documento = null;

                    context.Update(item);
                }

                foreach (var item in visitante)
                {
                    if (item.vis_fot_n_codigo == id)
                        item.vis_fot_n_codigo = null;

                    if (item.vis_fot_n_documento == id)
                        item.vis_fot_n_documento = null;

                    context.Update(item);
                }

                foreach (var item in fotoFachada)
                {
                    if (item.cli_fot_fachada_n_codigo == id)
                        item.cli_fot_fachada_n_codigo = null;

                    context.Update(item);
                }

                if (catalogo != null)
                {
                    catalogo.cal_fot_n_codigo = null;
                    context.Update(catalogo);
                }

                Delete(imagem);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
