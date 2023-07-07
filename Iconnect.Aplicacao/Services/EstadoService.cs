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
    public class EstadoService : RepositoryBase<tb_est_estado>, IEstadoService
    {
        private IconnectCoreContext context;

        public EstadoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public List<EstadoViewModel> ListarEstados()
        {
            return (from est in Context.tb_est_estado
                    select new EstadoViewModel()
                    {
                        est_n_codigo = est.est_n_codigo.ToString(),
                        est_c_descricao = est.est_c_descricao,
                        est_c_sigla = est.est_c_sigla


                    }).ToList();

        }

        public List<EstadoViewModel> ListarEstadosFiltrado()
        {
            return (from est in Context.tb_est_estado
                    select new EstadoViewModel()
                    {
                        est_n_codigo = est.est_n_codigo.ToString(),
                        est_c_descricao = est.est_c_descricao,
                        est_c_sigla = est.est_c_sigla

                    }).ToList();
        }
    }
}
