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
using Microsoft.EntityFrameworkCore;

namespace Iconnect.Aplicacao.Services
{
    class PgmService : RepositoryBase<tb_pgc_pgmCliente>, IPgmService
    {
        private IconnectCoreContext context;

        public PgmService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object InsertOrUpdate(PgcViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                int codeCli = Convert.ToInt32(model.pgc_cli_n_codigo);
                if (codeCli == 0)
                {
                    retorno.status = "error";
                    retorno.conteudo = "Cliente não cadastrado";
                    return retorno;
                }

                var duplicado = ValidaDuplicidade(model);
                if(duplicado == true)
                {
                    retorno.status = "error";
                    retorno.conteudo = "Configuração já cadastrada";
                    return retorno;
                }

                int codePgc = Convert.ToInt32(model.pgc_n_codigo);

                if (codePgc == 0)
                {
                    Insert(new tb_pgc_pgmCliente()
                    {
                        pgc_eqc_n_codigo = Convert.ToInt32(model.pgc_eqc_n_codigo),
                        pgc_c_nome = model.pgc_c_nome,
                        pgc_cpg_n_codigo = Convert.ToInt32(model.pgc_cpg_n_codigo),
                        pgc_cli_n_codigo = codeCli,
                        //pgc_usu_n_codigo = Convert.ToInt32(model.pgc_usu_n_codigo),
                        pgc_c_unique = Guid.NewGuid(),
                        pgc_d_atualizado = DateTime.Now,
                        pgc_d_inclusao = DateTime.Now,
                    });
                }
                else
                {
                    var pgc = (from pgmCli in context.tb_pgc_pgmCliente where pgmCli.pgc_n_codigo == codePgc select pgmCli).FirstOrDefault();
                    //pgc.pgc_cli_n_codigo = codeCli;
                    pgc.pgc_c_nome = model.pgc_c_nome;
                    pgc.pgc_cpg_n_codigo = Convert.ToInt32(model.pgc_cpg_n_codigo);
                    pgc.pgc_cli_n_codigo = Convert.ToInt32(model.pgc_cli_n_codigo);
                    //pgc.pgc_usu_n_codigo = Convert.ToInt32(model.pgc_usu_n_codigo);
                    pgc.pgc_d_atualizado = DateTime.Now;
                    pgc.pgc_d_inclusao = DateTime.Now;

                    Update(pgc);
                }
                context.SaveChanges();
                retorno.status = "ok";
                retorno.conteudo = "Dados salvos com sucesso";
                return retorno;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<GenericList> ListarPgm(int modelo)
        {
            return (from eqc in Context.tb_cpg_comandoPGM
                    where eqc.cgp_n_modelo == modelo && eqc.cgp_b_sirene == false
                    select new GenericList()
                    {
                        value = eqc.cgp_n_codigo.ToString(),
                        text = eqc.cgp_c_descricao,

                    }).ToList();
        }

        public IPagedList<PgcViewModel> GetPgcFiltrado(PgcFiltermodel filter)
        {
            try
            {
                var query = (from pgc in Context.tb_pgc_pgmCliente
                             join eqc in context.tb_eqc_equipamentoCliente on pgc.pgc_eqc_n_codigo equals eqc.eqc_n_codigo
                             join cpg in context.tb_cpg_comandoPGM on pgc.pgc_cpg_n_codigo equals cpg.cgp_n_codigo
                             orderby pgc.pgc_c_nome
                             select new PgcViewModel
                             {
                                 pgc_c_nome = pgc.pgc_c_nome,
                                 pgc_n_codigo = pgc.pgc_n_codigo.ToString(),
                                 pgc_cli_n_codigo = pgc.pgc_cli_n_codigo.ToString(),
                                 pgc_centralDescricao = eqc.eqc_c_nomePonto + " | " + eqc.eqc_c_ip,
                                 pgc_PgmDescricao = cpg.cgp_c_descricao
                             });

                int codCli = Convert.ToInt32(filter.pgc_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.pgc_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.pgc_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public PgcViewModel GetPgc(int id)
        {
            return (from pgc in Context.tb_pgc_pgmCliente
                    join eqc in context.tb_eqc_equipamentoCliente on pgc.pgc_eqc_n_codigo equals eqc.eqc_n_codigo
                    where pgc.pgc_n_codigo == id

                    select new PgcViewModel
                    {
                        pgc_n_codigo = pgc.pgc_n_codigo.ToString(),
                        pgc_c_nome = pgc.pgc_c_nome,
                        pgc_eqc_n_codigo = pgc.pgc_eqc_n_codigo.ToString(),
                        pgc_cpg_n_codigo = pgc.pgc_cpg_n_codigo.ToString(),
                        pgc_cli_n_codigo = pgc.pgc_cli_n_codigo.ToString(),
                        pgc_eqc_modelo = eqc.eqc_n_modelo.ToString(),
                    }).FirstOrDefault();
        }

        public List<PgcViewModel> GetPgcByEquipamento(int idEquipamento)
        {
            var lista = (from pgc in Context.tb_pgc_pgmCliente
                         join eqc in context.tb_eqc_equipamentoCliente on pgc.pgc_eqc_n_codigo equals eqc.eqc_n_codigo
                         where eqc.eqc_n_codigo == idEquipamento && pgc.pgc_cpg_n_codigo != 4 && pgc.pgc_cpg_n_codigo != 5
                         select new PgcViewModel
                         {
                             pgc_n_codigo = pgc.pgc_n_codigo.ToString(),
                             pgc_c_nome = pgc.pgc_c_nome,
                             pgc_eqc_n_codigo = pgc.pgc_eqc_n_codigo.ToString(),
                             pgc_cpg_n_codigo = pgc.pgc_cpg_n_codigo.ToString(),
                             pgc_cli_n_codigo = pgc.pgc_cli_n_codigo.ToString(),
                         }).ToList();

            return lista;
        }

        public bool DeletarPgc(int id)
        {
            try
            {
                Delete(context.tb_pgc_pgmCliente.Find(id));
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
                List<tb_pgc_pgmCliente> lista = new List<tb_pgc_pgmCliente>();


                lista = (from pgc in context.tb_pgc_pgmCliente where pgc.pgc_cli_n_codigo == 0 select pgc).OrderBy(x => x.pgc_c_nome).ToList();


                foreach (var item in lista)
                {

                    DeletarPgc(item.pgc_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
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

        //public bool Vincular(int id)
        //{
        //    try
        //    {
        //        var lista = context.tb_pgc_pgmCliente.Where(x => x.pgc_cli_n_codigo == 0).ToList();

        //        if (lista.Count() > 0)
        //        {
        //            foreach (var item in lista)
        //            {
        //                item.pgc_cli_n_codigo = id;
        //                Update(item);
        //            }

        //            context.SaveChanges();
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public bool ValidaDuplicidade(PgcViewModel model)
        {
            var duplicado = (from pgc in context.tb_pgc_pgmCliente
                             where pgc.pgc_eqc_n_codigo == Convert.ToInt32(model.pgc_eqc_n_codigo)
                             && pgc.pgc_cpg_n_codigo == Convert.ToInt32(model.pgc_cpg_n_codigo)
                             && pgc.pgc_cli_n_codigo == Convert.ToInt32(model.pgc_cli_n_codigo)
                             && pgc.pgc_n_codigo != Convert.ToInt32(model.pgc_n_codigo) 
                             select pgc).Count();
            if(duplicado != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
