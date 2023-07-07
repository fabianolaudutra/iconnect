using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using System.Security.Cryptography;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using Iconnect.Aplicacao.FilterModel;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;


namespace Iconnect.Aplicacao.Services
{
    public class VisitanteAppService : RepositoryBase<tb_vis_visitasApp>, IVisitanteAppService
    {
        private IconnectCoreContext context;

        public VisitanteAppService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeleteVisita(int id)
        {
            try
            {
                Delete(context.tb_vis_visitasApp.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public VisitasAppViewModel SalvarVisitasApp(VisitasAppViewModel model)
        {
            try
            {
                if (model != null)
                {
                    tb_vis_visitasApp tbVisitas = new tb_vis_visitasApp
                    {
                        vis_n_codigo = model.vis_n_codigo
                    };

                  
                    if (model.vis_n_codigo == 0)
                    {
                        tbVisitas.vis_c_descricao = model.vis_c_descricao;
                        tbVisitas.vis_d_dataHora = model.vis_d_dataHora;
                        tbVisitas.vis_n_duracao = model.vis_n_duracao; 
                        tbVisitas.vis_n_duracaoAntes = 60; //Duração fixa
                        tbVisitas.vis_n_quantidade = 0;
                        tbVisitas.vis_mor_n_codigo = null;
                        tbVisitas.vis_c_unique = Guid.NewGuid();
                        tbVisitas.vis_d_inclusao = DateTime.Now;
                        tbVisitas.vis_d_atualizado = DateTime.Now;
                        tbVisitas.vis_d_modificacao = DateTime.Now;
                        tbVisitas.vis_age_n_codigo = model.vis_age_n_codigo;
                        Insert(tbVisitas);
                    }
                    else
                    {
                        tbVisitas = (from vis in context.tb_vis_visitasApp where vis.vis_age_n_codigo == model.vis_n_codigo select vis).FirstOrDefault();
                        tbVisitas.vis_c_descricao = model.vis_c_descricao;
                        tbVisitas.vis_d_dataHora = model.vis_d_dataHora;
                        tbVisitas.vis_n_duracao = model.vis_n_duracao; 
                        tbVisitas.vis_n_duracaoAntes = 60; //Duração fixa
                        tbVisitas.vis_n_quantidade = 0;
                        tbVisitas.vis_mor_n_codigo = null;
                        tbVisitas.vis_c_unique = Guid.NewGuid();
                        tbVisitas.vis_d_inclusao = DateTime.Now;
                        tbVisitas.vis_d_atualizado = DateTime.Now;
                        tbVisitas.vis_d_modificacao = DateTime.Now;
                        tbVisitas.vis_age_n_codigo = model.vis_age_n_codigo;

                        Update(tbVisitas);
                    }

                    context.SaveChanges();

                    model.vis_n_codigo = tbVisitas.vis_n_codigo;
                    return model;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
