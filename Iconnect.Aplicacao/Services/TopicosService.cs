using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PagedList;
using Iconnect.Aplicacao.FilterModel;

namespace Iconnect.Aplicacao.Services
{
    public class TopicosService : RepositoryBase<tb_tpc_topicos>, ITopicosService
    {
        private IconnectCoreContext context;
        public TopicosService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public void Insert(TopicoViewModel model)
        {
            var topico = new tb_tpc_topicos()
            {

                tpc_c_descricao = model.tpc_c_descricao,
                tpc_d_modificacao = DateTime.Now,
                tpc_c_unique = new Guid(),
                tpc_d_atualizado = DateTime.Now,
                tpc_d_inclusao = DateTime.Now,
            };

            Insert(topico);
            context.SaveChanges();
        }

        public List<TopicoViewModel> GetTopicos()
        {
            return (from tpc in context.tb_tpc_topicos
                    select new TopicoViewModel()
                    {
                        tpc_n_codigo = tpc.tpc_n_codigo.ToString(),
                        tpc_c_descricao = tpc.tpc_c_descricao,
                    }).ToList();
        }

        public IPagedList<TopicoViewModel> GetListaTopicos(TopicosFilterModel filter)
        {
            var query = (from tpc in context.tb_tpc_topicos
                         select new TopicoViewModel()
                         {
                             tpc_n_codigo = tpc.tpc_n_codigo.ToString(),
                             tpc_c_descricao = tpc.tpc_c_descricao,
                         });

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public void Deletar(int id)
        {
            Delete(context.tb_tpc_topicos.Find(id));
            context.SaveChanges();
        }
    }
}
