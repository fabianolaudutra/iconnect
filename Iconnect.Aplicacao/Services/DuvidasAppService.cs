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
using OfficeOpenXml;

namespace Iconnect.Aplicacao.Services
{
    class DuvidasAppService : RepositoryBase<tb_dva_duvidasApp>, IDuvidasAppService
    {
        private IconnectCoreContext context;

        public DuvidasAppService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarDuvida(int id)
        {
            try
            {
                Delete(context.tb_dva_duvidasApp.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_dva_duvidasApp> lista = new List<tb_dva_duvidasApp>();


                lista = (from duv in context.tb_dva_duvidasApp where duv.dva_cli_n_codigo == null select duv).OrderBy(x => x.dva_c_duvida).ToList();


                foreach (var item in lista)
                {

                    DeletarDuvida(item.dva_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public DuvidasAppViewModel GetDuvida(int id)
        {
            return (from duv in Context.tb_dva_duvidasApp
                    where duv.dva_n_codigo == id

                    select new DuvidasAppViewModel
                    {
                        dva_n_codigo = duv.dva_n_codigo.ToString(),
                        dva_cli_n_codigo = duv.dva_cli_n_codigo.ToString(),
                        dva_c_duvida = duv.dva_c_duvida,
                        dva_c_resposta = duv.dva_c_resposta,
                        dva_c_link = duv.dva_c_link,

                    }).FirstOrDefault();
        }

        public List<DuvidasAppViewModel> GetDuvidasByCliente(int idCliente)
        {
            var lstDuvidas = (from duv in Context.tb_dva_duvidasApp
                              where duv.dva_cli_n_codigo == idCliente
                              orderby duv.dva_c_duvida ascending
                              select new DuvidasAppViewModel
                              {
                                  dva_n_codigo = duv.dva_n_codigo.ToString(),
                                  dva_cli_n_codigo = duv.dva_cli_n_codigo.ToString(),
                                  dva_c_duvida = duv.dva_c_duvida,
                                  dva_c_resposta = duv.dva_c_resposta,
                                  dva_c_link = duv.dva_c_link,
                              }).ToList();

            return lstDuvidas;
        }

        public IPagedList<DuvidasAppViewModel> GetDuvidasFiltrado(DuvidasAppFilterModel filter)
        {
            try
            {
                var query = (from duv in Context.tb_dva_duvidasApp
                             orderby duv.dva_c_duvida
                             select new DuvidasAppViewModel
                             {
                                 dva_n_codigo = duv.dva_n_codigo.ToString(),
                                 dva_cli_n_codigo = duv.dva_cli_n_codigo.ToString(),
                                 dva_c_duvida = duv.dva_c_duvida,
                                 dva_c_resposta = duv.dva_c_resposta,
                                 dva_c_link = duv.dva_c_link,

                             });

                int codCli = Convert.ToInt32(filter.dva_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.dva_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.dva_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DuvidasAppViewModel InsertOrUpdate(DuvidasAppViewModel model)
        {
            try
            {
                int? codeCli = null;
                if (model.dva_cli_n_codigo != null && model.dva_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.dva_cli_n_codigo);
                }

                int codeDuv = Convert.ToInt32(model.dva_n_codigo);

                if (codeDuv == 0)
                {
                    Insert(new tb_dva_duvidasApp()
                    {
                        dva_cli_n_codigo = codeCli.Value,
                        dva_c_duvida = model.dva_c_duvida,
                        dva_c_resposta = model.dva_c_resposta,
                        dva_c_link = model.dva_c_link,
                        dva_c_unique = Guid.NewGuid(),
                        dva_d_atualizado = DateTime.Now,
                        dva_d_inclusao = DateTime.Now,
                    });
                }
                else
                {
                    var duv = (from duvida in context.tb_dva_duvidasApp where duvida.dva_n_codigo == codeDuv select duvida).FirstOrDefault();

                    duv.dva_cli_n_codigo = codeCli.Value;
                    duv.dva_c_duvida = model.dva_c_duvida;
                    duv.dva_c_resposta = model.dva_c_resposta;
                    duv.dva_c_link = model.dva_c_link;
                    duv.dva_d_atualizado = DateTime.Now;

                    Update(duv);
                }
                context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
            }
            return model;

        }

        public bool Vincular(int id)
        {
            try
            {
                var lista = context.tb_dva_duvidasApp.Where(x => x.dva_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.dva_cli_n_codigo = id;
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

    }
}
