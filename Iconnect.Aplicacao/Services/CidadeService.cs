
using System;
using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;


namespace Iconnect.Aplicacao.Services
{
    class CidadeService : RepositoryBase<tb_cid_cidade>, ICidadeService
    {
        private IconnectCoreContext context;

        public CidadeService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public List<CidadeViewModel> ListarCidades()
        {
            return (from cid in Context.tb_cid_cidade
                    select new CidadeViewModel()
                    {
                        cid_n_codigo = cid.cid_n_codigo.ToString(),
                        cid_c_nome = cid.cid_c_nome,

                    }).ToList();
        }

        public List<CidadeViewModel> ListarCidadesFiltrado(int id)
        {
            return (from cid in Context.tb_cid_cidade
                    where cid.cid_est_n_codigo == id
                    select new CidadeViewModel()
                    {
                        cid_n_codigo = cid.cid_n_codigo.ToString(),
                        cid_c_nome = cid.cid_c_nome,
                    }).ToList();
        }
    }
}
