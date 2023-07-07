using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class SalaComercialCatalogoService : RepositoryBase<tb_sca_salaComercialCatalogo>, ISalaComercialCatalogoService
    {
        private readonly IconnectCoreContext context;

        public SalaComercialCatalogoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public void InserirRelacionamento(CatalogoViewModel model)
        {
            try
            {
                tb_sca_salaComercialCatalogo relacionamento;
                relacionamento = new tb_sca_salaComercialCatalogo()
                {
                    sca_grf_n_codigo = Convert.ToInt32(model.cal_grf_n_codigo),
                    sca_cal_n_codigo = Convert.ToInt32(model.cal_n_codigo),
                    sca_d_inclusao = DateTime.Now,
                    sca_d_atualizado = DateTime.Now,
                    sca_c_unique = new Guid(),
                };

                Insert(relacionamento);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
