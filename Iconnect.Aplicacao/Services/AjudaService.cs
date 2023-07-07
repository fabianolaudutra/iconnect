using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class AjudaService : RepositoryBase<tb_ajd_ajuda>, IAjudaService
    {
        private IconnectCoreContext context;
        public AjudaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public int InsertOrUpdate(AjudaViewModel model)
        {

            if (string.IsNullOrEmpty(model.ajd_n_codigo))
            {
                var ajuda = new tb_ajd_ajuda()
                {
                    ajd_cli_n_codigo = Convert.ToInt32(model.ajd_cli_n_codigo),
                    ajd_tpc_n_codigo = Convert.ToInt32(model.ajd_tpc_n_codigo),
                    ajd_c_duvida = model.ajd_c_duvida,
                    ajd_c_descricao = model.ajd_c_descricao,
                    ajd_d_inclusao = DateTime.Now,
                    ajd_d_atualizado = DateTime.Now,
                    ajd_c_link = model.ajd_c_link
                };

                Insert(ajuda);
                context.SaveChanges();
                return ajuda.ajd_n_codigo;
            }
            else
            {
                var ajuda = (from ajd in context.tb_ajd_ajuda where ajd.ajd_n_codigo == Convert.ToInt32(model.ajd_n_codigo) select ajd).FirstOrDefault();
                ajuda.ajd_cli_n_codigo = Convert.ToInt32(model.ajd_cli_n_codigo);
                ajuda.ajd_tpc_n_codigo = Convert.ToInt32(model.ajd_tpc_n_codigo);                
                ajuda.ajd_c_duvida = model.ajd_c_duvida;
                ajuda.ajd_c_descricao = model.ajd_c_descricao;
                ajuda.ajd_d_atualizado = DateTime.Now;
                ajuda.ajd_c_link = model.ajd_c_link;

                Update(ajuda);
                context.SaveChanges();
                return ajuda.ajd_n_codigo;
            }
        }

        public AjudaViewModel GetAjuda(int id)
        {
            return (from ajd in context.tb_ajd_ajuda
                    where ajd.ajd_n_codigo == id
                    select new AjudaViewModel()
                    {
                        ajd_cli_n_codigo = ajd.ajd_cli_n_codigo.ToString(),
                        ajd_tpc_n_codigo = ajd.ajd_tpc_n_codigo.ToString(),
                        ajd_c_duvida = ajd.ajd_c_duvida,
                        ajd_c_descricao = ajd.ajd_c_descricao,
                        ajd_n_codigo = ajd.ajd_n_codigo.ToString(),
                        ajd_c_link = ajd.ajd_c_link,
                    }).FirstOrDefault();
        }

        public List<AjudaViewModel> GetAjudaFiltrado(AjudaFilterModel filter)
        {
            var query = (from ajd in context.tb_ajd_ajuda
                         join cli in context.tb_cli_cliente on ajd.ajd_cli_n_codigo equals cli.cli_n_codigo
                         join tpc in context.tb_tpc_topicos on ajd.ajd_tpc_n_codigo equals tpc.tpc_n_codigo
                         select new AjudaViewModel()
                         {
                             ajd_n_codigo = ajd.ajd_n_codigo.ToString(),
                             ajd_cli_n_codigo = ajd.ajd_cli_n_codigo.ToString(),
                             ajd_tpc_n_codigo = ajd.ajd_tpc_n_codigo.ToString(),
                             ajd_c_duvida = ajd.ajd_c_duvida,
                             ajd_c_descricao = ajd.ajd_c_descricao,
                             ajd_cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                             ajd_topico = tpc.tpc_c_descricao,
                             buscaSimples = $"{ajd.ajd_c_duvida}",
                             ajd_c_link = ajd.ajd_c_link
                         }).ToList();

            if (!filter?.idsClientes?.Equals("todos") ?? false)
            {
                var ids = filter.idsClientes.Split(",");
                query = query.Where(w => ids.Contains(w.ajd_cli_n_codigo)).ToList();
            }

            if (!string.IsNullOrEmpty(filter?.ajd_cli_n_codigo_filter) && filter?.ajd_cli_n_codigo_filter != "NULL" && filter?.ajd_cli_n_codigo_filter != "0")
            {
                query = query.Where(w => w.ajd_cli_n_codigo.Contains(filter.ajd_cli_n_codigo_filter)).ToList();
            }

            if (!string.IsNullOrEmpty(filter?.ajd_tpc_n_codigo_filter) && filter?.ajd_tpc_n_codigo_filter != "NULL" && filter?.ajd_tpc_n_codigo_filter != "0")
            {
                query = query.Where(w => w.ajd_tpc_n_codigo.Contains(filter.ajd_tpc_n_codigo_filter)).ToList();
            }

            if (!string.IsNullOrEmpty(filter?.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter)).ToList();
            }

            return query.ToList();
        }

        public void Deletar(int id)
        {
            Delete(context.tb_ajd_ajuda.Find(id));
            context.SaveChanges();
        }

        public IPagedList<AjudaViewModel> GetCadastroAjudaFiltrado(AjudaFilterModel filter)
        {
            var query = (from ajd in context.tb_ajd_ajuda
                         join cli in context.tb_cli_cliente on ajd.ajd_cli_n_codigo equals cli.cli_n_codigo
                         join tpc in context.tb_tpc_topicos on ajd.ajd_tpc_n_codigo equals tpc.tpc_n_codigo
                         select new AjudaViewModel()
                         {
                             ajd_n_codigo = ajd.ajd_n_codigo.ToString(),
                             ajd_cli_n_codigo = ajd.ajd_cli_n_codigo.ToString(),
                             ajd_tpc_n_codigo = ajd.ajd_tpc_n_codigo.ToString(),
                             ajd_c_duvida = ajd.ajd_c_duvida,
                             ajd_c_descricao = ajd.ajd_c_descricao,
                             ajd_cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                             ajd_topico = tpc.tpc_c_descricao,
                             buscaSimples = $"{ajd.ajd_c_duvida}",
                             ajd_c_link = ajd.ajd_c_link
                         }).ToList();

            if (!filter?.idsClientes?.Equals("todos") ?? false)
            {
                var ids = filter.idsClientes.Split(",");
                query = query.Where(w => ids.Contains(w.ajd_cli_n_codigo)).ToList();
            }

            if (!string.IsNullOrEmpty(filter?.ajd_cli_n_codigo_filter) && filter?.ajd_cli_n_codigo_filter != "NULL" && filter?.ajd_cli_n_codigo_filter != "0")
            {
                query = query.Where(w => w.ajd_cli_n_codigo.Contains(filter.ajd_cli_n_codigo_filter)).ToList();
            }

            if (!string.IsNullOrEmpty(filter?.ajd_tpc_n_codigo_filter) && filter?.ajd_tpc_n_codigo_filter != "NULL" && filter?.ajd_tpc_n_codigo_filter != "0")
            {
                query = query.Where(w => w.ajd_tpc_n_codigo.Contains(filter.ajd_tpc_n_codigo_filter)).ToList();
            }

            if (!string.IsNullOrEmpty(filter?.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter)).ToList();
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }
    }
}
