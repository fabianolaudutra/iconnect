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
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    class MotivoOcorrenciaService : RepositoryBase<tb_moc_motivoOcorrenciaCliente>, IMotivoOcorrenciaService
    {
        private IconnectCoreContext context;

        public MotivoOcorrenciaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public MotivoOcorrenciaViewModel InsertOrUpdate(MotivoOcorrenciaViewModel model)
        {
            try
            {
                int? codeCli = null;
                if (model.moc_cli_n_codigo != null && model.moc_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.moc_cli_n_codigo);
                }

                int codeMoc = Convert.ToInt32(model.moc_n_codigo);

                if (codeMoc == 0)
                {
                    Insert(new tb_moc_motivoOcorrenciaCliente()
                    {
                        moc_cli_n_codigo = codeCli,
                        moc_c_descricao = model.moc_c_descricao,
                        moc_b_encerrar = Convert.ToBoolean(model.moc_b_encerrar),
                        moc_c_unique = Guid.NewGuid(),
                        moc_d_atualizado = DateTime.Now,
                        moc_d_inclusao = DateTime.Now,
                        moc_d_modificacao = DateTime.Now
                    });
                }
                else
                {
                    var moc = (from motivo in context.tb_moc_motivoOcorrenciaCliente where motivo.moc_n_codigo == codeMoc select motivo).FirstOrDefault();

                    moc.moc_cli_n_codigo = codeCli;
                    moc.moc_c_descricao = model.moc_c_descricao;
                    moc.moc_b_encerrar = Convert.ToBoolean(model.moc_b_encerrar);
                    moc.moc_d_atualizado = DateTime.Now;
                    moc.moc_d_modificacao = DateTime.Now;

                    Update(moc);
                }
                context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
            }
            return model;


        }

        public IPagedList<MotivoOcorrenciaViewModel> GetMotivoFiltrado(MotivoOcorrenciaFilterModel filter)
        {
            try
            {
                var query = (from moc in Context.tb_moc_motivoOcorrenciaCliente
                             orderby moc.moc_c_descricao
                             select new MotivoOcorrenciaViewModel
                             {
                                 moc_n_codigo = moc.moc_n_codigo.ToString(),
                                 moc_cli_n_codigo = moc.moc_cli_n_codigo.ToString(),
                                 moc_c_descricao = moc.moc_c_descricao,
                                 //moc_b_encerrar = moc.moc_b_encerrar,

                             });

                int codCli = Convert.ToInt32(filter.moc_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.moc_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.moc_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarMotivo(int id)
        {
            try
            {
                Delete(context.tb_moc_motivoOcorrenciaCliente.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public MotivoOcorrenciaViewModel GetMotivo(int id)
        {

            return (from moc in Context.tb_moc_motivoOcorrenciaCliente
                    where moc.moc_n_codigo == id

                    select new MotivoOcorrenciaViewModel
                    {
                        moc_n_codigo = moc.moc_n_codigo.ToString(),
                        moc_cli_n_codigo = moc.moc_cli_n_codigo.ToString(),
                        moc_c_descricao = moc.moc_c_descricao,
                        moc_b_encerrar = moc.moc_b_encerrar.ToString(),
                    }).FirstOrDefault();
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_moc_motivoOcorrenciaCliente> lista = new List<tb_moc_motivoOcorrenciaCliente>();


                lista = (from moc in context.tb_moc_motivoOcorrenciaCliente where moc.moc_cli_n_codigo == null select moc).OrderBy(x => x.moc_c_descricao).ToList();


                foreach (var item in lista)
                {

                    DeletarMotivo(item.moc_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public bool Vincular(int id)
        {
            try
            {
                var lista = context.tb_moc_motivoOcorrenciaCliente.Where(x => x.moc_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.moc_cli_n_codigo = id;
                        Update(item);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<MotivoOcorrenciaViewModel> GetMotivosByCliente(int id)
        {
            var lstMotivos = (from moc in Context.tb_moc_motivoOcorrenciaCliente
                              where moc.moc_cli_n_codigo == id
                              orderby moc.moc_c_descricao ascending
                              select new MotivoOcorrenciaViewModel
                              {
                                  moc_n_codigo = moc.moc_n_codigo.ToString(),
                                  moc_cli_n_codigo = moc.moc_cli_n_codigo.ToString(),
                                  moc_c_descricao = moc.moc_c_descricao,
                                  moc_b_encerrar = moc.moc_b_encerrar.ToString()
                              }).ToList();

            return lstMotivos;
        }
    }
}
