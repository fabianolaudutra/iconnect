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
using System.Data;
using System.ComponentModel;

namespace Iconnect.Aplicacao.Services
{
    class HorarioService : RepositoryBase<tb_hor_horario>, IHorarioService
    {
        private IconnectCoreContext context;

        public HorarioService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<HorarioViewModel> GetHorarioFiltrado(HorarioFilterModel filter)
        {
            var query = (from hor in Context.tb_hor_horario
                         select new HorarioViewModel
                         {
                             hor_n_codigo = hor.hor_n_codigo.ToString(),
                             hor_c_nome = hor.hor_c_nome,
                             hor_d_termina = hor.hor_d_termina,
                             hor_c_diaSemana = hor.hor_c_diaSemana,
                             hor_d_inicia = hor.hor_d_inicia,
                             hor_cli_n_codigo = hor.hor_cli_n_codigo.ToString(),
                             hor_b_referenciaApp = hor.hor_b_referenciaApp.Value ? "SIM" : "NÃO",
                             hor_d_modificacao = hor.hor_d_modificacao.ToString(),
                             hor_n_codigoLinear = hor.hor_n_codigoLinear.ToString(),
                             hor_c_unique = hor.hor_c_unique.ToString(),
                             hor_d_atualizado = hor.hor_d_atualizado.ToString(),
                             hor_d_inclusao = hor.hor_d_inclusao.ToString(),
                         });

            if (!string.IsNullOrEmpty(filter.hor_cli_n_codigo_filter) && filter.hor_cli_n_codigo_filter != "0")
            {
                query = query.Where(w => w.hor_cli_n_codigo == filter.hor_cli_n_codigo_filter);
            }
            else
            {
                query = query.Where(w => w.hor_cli_n_codigo == null);
            }

            return query.OrderBy(x => x.hor_c_nome).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarHorario(HorarioViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.hor_n_codigo) || model.hor_n_codigo.ToString() == "0")
                {
                    Insert(new tb_hor_horario()
                    {
                        hor_c_nome = model.hor_c_nome,
                        hor_d_termina = model.hor_d_termina,
                        hor_c_diaSemana = model.hor_c_diaSemana,
                        hor_d_inicia = model.hor_d_inicia,
                        hor_cli_n_codigo = Convert.ToInt32(model.hor_cli_n_codigo),
                        hor_b_referenciaApp = Convert.ToBoolean(model.hor_b_referenciaApp),
                        hor_d_modificacao = DateTime.Now,
                        //hor_n_codigoLinear = Convert.ToInt32(model.hor_n_codigoLinear),
                        hor_c_unique = new Guid(),
                        hor_d_atualizado = DateTime.Now,
                        hor_d_inclusao = DateTime.Now,
                    });
                }
                else
                {
                    var Horario = (from hor in context.tb_hor_horario where hor.hor_n_codigo == Convert.ToInt32(model.hor_n_codigo) select hor).FirstOrDefault();
                    Horario.hor_c_nome = model.hor_c_nome;
                    Horario.hor_d_termina = model.hor_d_termina;
                    Horario.hor_c_diaSemana = model.hor_c_diaSemana;
                    Horario.hor_d_inicia = model.hor_d_inicia;
                    Horario.hor_cli_n_codigo = Convert.ToInt32(model.hor_cli_n_codigo);
                    Horario.hor_b_referenciaApp = Convert.ToBoolean(model.hor_b_referenciaApp);
                    Horario.hor_d_modificacao = DateTime.Now;
                    //Horario.hor_n_codigoLinear = Convert.ToInt32(model.hor_n_codigoLinear);
                    Horario.hor_d_atualizado = DateTime.Now;

                    Update(Horario);
                }

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarHorario(int id)
        {
            Delete(context.tb_hor_horario.Find(id));

            context.SaveChanges();

            return true;
        }

        public List<GenericList> ListarHorarios(int id)
        {
            return (from hor in Context.tb_hor_horario
                    where hor.hor_cli_n_codigo == id
                    orderby hor.hor_c_nome
                    select new GenericList()
                    {
                        value = hor.hor_n_codigo.ToString(),
                        text = hor.hor_c_nome,

                    }).ToList();
        }
    }
}