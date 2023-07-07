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
using CORS.CitroxDecompiled;

namespace Iconnect.Aplicacao.Services
{
    public class LiberacaoVisitanteService : RepositoryBase<tb_liv_liberacaoVisitante>, ILiberacaoVisitanteService
    {
        private IconnectCoreContext context;

        public LiberacaoVisitanteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeleteLiberacao(int id)
        {
            try
            {
                Delete(context.tb_liv_liberacaoVisitante.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LiberacaoVisitanteViewModel SalvarLiberacao(LiberacaoVisitanteViewModel model)
        {
            try
            {
                if (model != null)
                {
                    tb_liv_liberacaoVisitante tbLiberacao = new tb_liv_liberacaoVisitante
                    {
                        liv_n_codigo = model.liv_n_codigo
                    };

                    if (model.liv_n_codigo == 0)
                    {
                            tbLiberacao.liv_b_pendente = true;
                            tbLiberacao.liv_c_celular = model.liv_c_celular;
                            tbLiberacao.liv_c_nome = model.liv_c_nome;
                            tbLiberacao.liv_mor_n_codigo = null;
                            tbLiberacao.liv_vis_n_codigo = model.liv_vis_n_codigo;// ID da tabela tb_vis_visitasApp_vis_n_codigo
                            tbLiberacao.liv_d_dataHora = model.liv_d_dataHora;
                            tbLiberacao.liv_cac_n_codigo = model.liv_cac_n_codigo;
                            tbLiberacao.liv_visitante_n_codigo = model.liv_visitante_n_codigo;// ID da tabela tb_vis_visitante_vis_n_codigo
                            tbLiberacao.liv_c_unique = Guid.NewGuid();
                            tbLiberacao.liv_d_inclusao = DateTime.Now;
                            tbLiberacao.liv_d_atualizado = DateTime.Now;

                        Insert(tbLiberacao);
                    }
                    else
                    {
                        //REVISAR CAMPOS PARA UPDATE
                        tbLiberacao = (from liv in context.tb_liv_liberacaoVisitante where liv.liv_n_codigo == model.liv_n_codigo select liv).FirstOrDefault();
                        tbLiberacao.liv_c_nome = model.liv_c_nome;
                        tbLiberacao.liv_vis_n_codigo = model.liv_vis_n_codigo;
                        tbLiberacao.liv_d_inclusao = DateTime.Now;
                        tbLiberacao.liv_d_atualizado = DateTime.Now;

                        Update(tbLiberacao);
                    }

                    context.SaveChanges();

                    model.liv_n_codigo = tbLiberacao.liv_n_codigo;
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
