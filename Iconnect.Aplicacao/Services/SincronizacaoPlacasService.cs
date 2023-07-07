using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System;

namespace Iconnect.Aplicacao.Services
{
    class SincronizacaoPlacasService : RepositoryBase<tb_sin_sincronizacaoPlacas>, ISincronizacaoPlacasService
    {
        private IconnectCoreContext context;

        public SincronizacaoPlacasService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool SalvarSincronizacaoPlacasExterna(int cli_n_codigo, string sin_c_controladoras)
        {
            try
            {
                Insert(new tb_sin_sincronizacaoPlacas()
                {
                    sin_b_interno = null,
                    sin_cli_n_codigo = cli_n_codigo,
                    sin_c_status = "AI",
                    sin_c_controladoras = sin_c_controladoras,
                    sin_d_dataSolicitacao = DateTime.Now,
                    sin_d_modificacao = DateTime.Now,
                    sin_c_unique = Guid.NewGuid(),
                    sin_d_atualizado = DateTime.Now,
                    sin_d_inclusao = DateTime.Now,
                });

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SalvarSincronizacaoPlacasInterna(int cli_n_codigo, string sin_c_controladoras, int cac_n_codigo)
        {
            Insert(new tb_sin_sincronizacaoPlacas()
            {
                sin_ace_n_codigo = cac_n_codigo,
                sin_b_interno = true,
                sin_cli_n_codigo = cli_n_codigo,
                sin_c_status = "AI",
                sin_c_controladoras = sin_c_controladoras,
                sin_d_dataSolicitacao = DateTime.Now,
                sin_d_modificacao = DateTime.Now
            });
            context.SaveChanges();
        }
    }
}