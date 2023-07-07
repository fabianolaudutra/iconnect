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
    class InformacoesClienteService : RepositoryBase<tb_inc_informacoesCliente>, IInformacoesClienteService
    {
        private IconnectCoreContext context;

        public InformacoesClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<InformacoesClienteViewModel> GetInformacoesClienteFiltrado(InformacoesClienteFilterModel filter)
        {
            var query = from informacoes in Context.tb_inc_informacoesCliente
                        select new InformacoesClienteViewModel
                        {
                            inc_n_codigo = informacoes.inc_n_codigo.ToString(),
                            inc_cli_n_codigo = informacoes.inc_cli_n_codigo.ToString(),
                            inc_c_titulo = informacoes.inc_c_titulo,
                            inc_c_descricao = informacoes.inc_c_descricao,
                            inc_n_ordem = informacoes.inc_n_ordem.ToString(),
                        };

            //if (!string.IsNullOrEmpty(filter.inc_cli_n_codigo))
            //{
            //    query = query.Where(w => w.inc_c_status == filter.inc_c_status_filter);
            //}

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public InformacoesClienteViewModel GetInformacoesCliente(int id)
        {
            return (from inc in context.tb_inc_informacoesCliente
                    where inc.inc_n_codigo == id
                    select new InformacoesClienteViewModel()
                    {
                        inc_n_codigo = inc.inc_n_codigo.ToString(),
                        inc_cli_n_codigo = inc.inc_cli_n_codigo.ToString(),
                        inc_c_titulo = inc.inc_c_titulo,
                        inc_c_descricao = inc.inc_c_descricao,
                        inc_n_ordem = inc.inc_n_ordem.ToString(),
                    }).FirstOrDefault();
        }

        public bool SalvarInformacoesCliente(InformacoesClienteViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.inc_n_codigo) || model.inc_n_codigo.ToString() == "0")
                {
                    Insert(new tb_inc_informacoesCliente()
                    {
                        inc_cli_n_codigo = Convert.ToInt32(model.inc_cli_n_codigo),
                        inc_c_titulo = model.inc_c_titulo,
                        inc_c_descricao = model.inc_c_descricao,
                        inc_n_ordem = Convert.ToInt32(model.inc_n_ordem),
                        inc_c_unique = Guid.NewGuid(),
                        inc_d_atualizado = DateTime.Now,
                        inc_d_inclusao = DateTime.Now
                    });
                }
                else
                {
                    var informacoes = (from inc in context.tb_inc_informacoesCliente where inc.inc_n_codigo == Convert.ToInt32(model.inc_n_codigo) select inc).FirstOrDefault();
                    informacoes.inc_c_titulo = model.inc_c_titulo;
                    informacoes.inc_c_descricao = model.inc_c_descricao;
                    informacoes.inc_n_ordem = Convert.ToInt32(model.inc_n_ordem);
                    informacoes.inc_d_atualizado = DateTime.Now;

                    Update(informacoes);
                }

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