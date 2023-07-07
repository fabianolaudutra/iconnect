using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class HistoricoLiberacaoService : RepositoryBase<tb_hil_historicoLiberacao>, IHistoricoLiberacaoService
    {
        private IconnectCoreContext context;
        public HistoricoLiberacaoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool SalvarHistorico(HistoricoLiberacaoViewModel model)
        {
            try
            {
                if (model.hil_n_codigo == 0)
                {
                    Insert(new tb_hil_historicoLiberacao()
                    {
                        hil_d_data = DateTime.Now,
                        hil_d_modificacao = DateTime.Now,
                        hil_mor_n_codigo = model.hil_mor_n_codigo,
                        hil_c_status = (model.hil_c_status == "true" ? "LIBERADO" :"NEGADO"),
                        hil_c_observacao = model.hil_c_observacao,
                        hil_c_nomeUsuario = "ADMINISTRADOR"
                    });
                }
                /*
                    Analisar posteriormente o pq context.tb_hil_historicoLiberacao não 
                    aceita a clausula WHERE;

                  else
                    {
                        var historico = (from hil in context.tb_hil_historicoLiberacao where hil.hil_n_codigo == model.hil_n_codigo select hil).FirstOrDefault();
                        historico.hil_mor_n_codigo = model.hil_mor_n_codigo;
                        historico.hil_c_status = model.hil_c_status;
                        historico.hil_c_observacao = model.hil_c_observacao;
                        historico.hil_d_modificacao = DateTime.Now;
                        Update(historico);
                    }
                 */
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
    }
}
