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

namespace Iconnect.Aplicacao.Services
{
    class DisparoPgmService : RepositoryBase<tb_dpg_disparoPGM>, IDisparoPgmService
    {
        private IconnectCoreContext context;

        public DisparoPgmService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool SalvarDisparoPgm(DisparoPgmViewModel model)
        {
            try
            {
                Insert(new tb_dpg_disparoPGM()
                {
                    dpg_eqc_n_codigo = Convert.ToInt32(model.dpg_eqc_n_codigo),
                    dpg_cgp_n_codigo = Convert.ToInt32(model.dpg_cgp_n_codigo),
                    dpg_b_pendente = true,
                    dpg_d_modificacao = DateTime.Now,
                    dpg_c_usuario = "FELIPE",
                    dpg_c_unique = Guid.NewGuid(),
                    dpg_d_atualizado = DateTime.Now,
                    dpg_d_inclusao = DateTime.Now,
                    dpg_cli_n_codigo = Convert.ToInt32(model.dpg_cli_n_codigo)
                });

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