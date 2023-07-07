using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Iconnect.Aplicacao.Services
{
    class VigilanteClienteService : RepositoryBase<tb_vic_vigilanteCliente>, IVigilanteClienteService
    {
        private IconnectCoreContext context;

        public VigilanteClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public VigilanteClienteViewModel InsertOrUpdate(VigilanteClienteViewModel model)
        {
            try
            {
                int? codeCli = null;
                if (model.vic_cli_n_codigo != null && model.vic_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.vic_cli_n_codigo);
                }

                int codeVic = Convert.ToInt32(model.vic_n_codigo);

                if (codeVic == 0)
                {
                    Insert(new tb_vic_vigilanteCliente()
                    {
                        vic_cli_n_codigo = codeCli,
                        vic_c_nome = model.vic_c_nome,
                        vic_c_celular = model.vic_c_celular,
                        vic_c_unique = Guid.NewGuid(),
                        vic_d_atualizado = DateTime.Now,
                        vic_d_inclusao = DateTime.Now,
                        vic_d_modificacao = DateTime.Now
                    });
                }
                else
                {
                    var vic = (from vigilante in context.tb_vic_vigilanteCliente where vigilante.vic_n_codigo == codeVic select vigilante).FirstOrDefault();

                    vic.vic_cli_n_codigo = codeCli;
                    vic.vic_c_nome = model.vic_c_nome;
                    vic.vic_c_celular = model.vic_c_celular;
                    vic.vic_d_atualizado = DateTime.Now;
                    vic.vic_d_modificacao = DateTime.Now;

                    Update(vic);
                }
                context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
            }
            return model;


        }

        public IPagedList<VigilanteClienteViewModel> GetVigilanteFiltrado(VigilanteClienteFilterModel filter)
        {
            try
            {
                var query = (from vic in Context.tb_vic_vigilanteCliente
                             orderby vic.vic_c_nome
                             select new VigilanteClienteViewModel
                             {
                                 vic_n_codigo = vic.vic_n_codigo.ToString(),
                                 vic_cli_n_codigo = vic.vic_cli_n_codigo.ToString(),
                                 vic_c_nome = vic.vic_c_nome,
                                 vic_c_celular = vic.vic_c_celular,

                             });

                int codCli = Convert.ToInt32(filter.vic_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.vic_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.vic_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarVigilante(int id)
        {
            try
            {
                Delete(context.tb_vic_vigilanteCliente.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public VigilanteClienteViewModel GetVigilante(int id)
        {

            return (from vic in Context.tb_vic_vigilanteCliente
                    where vic.vic_n_codigo == id

                    select new VigilanteClienteViewModel
                    {
                        vic_n_codigo = vic.vic_n_codigo.ToString(),
                        vic_cli_n_codigo = vic.vic_cli_n_codigo.ToString(),
                        vic_c_nome = vic.vic_c_nome,
                        vic_c_celular = vic.vic_c_celular,

                    }).FirstOrDefault();
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_vic_vigilanteCliente> lista = new List<tb_vic_vigilanteCliente>();


                lista = (from vic in context.tb_vic_vigilanteCliente where vic.vic_cli_n_codigo == null select vic).OrderBy(x => x.vic_c_nome).ToList();


                foreach (var item in lista)
                {

                    DeletarVigilante(item.vic_n_codigo);
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
                var lista = context.tb_vic_vigilanteCliente.Where(x => x.vic_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.vic_cli_n_codigo = id;
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

        public List<VigilanteClienteViewModel> GetVigilantesByCliente(int idCliente)
        {
            var lstVigilantes = (from vic in Context.tb_vic_vigilanteCliente
                                 where vic.vic_cli_n_codigo == idCliente
                                 orderby vic.vic_c_nome ascending
                                 select new VigilanteClienteViewModel
                                 {
                                     vic_n_codigo = vic.vic_n_codigo.ToString(),
                                     vic_cli_n_codigo = vic.vic_cli_n_codigo.ToString(),
                                     vic_c_nome = vic.vic_c_nome,
                                     vic_c_celular = vic.vic_c_celular,
                                 }).ToList();

            return lstVigilantes;
        }
    }
}
