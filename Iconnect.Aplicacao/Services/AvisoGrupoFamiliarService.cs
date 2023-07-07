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
    class AvisoGrupoFamiliarService : RepositoryBase<tb_avg_avisoGrupoFamiliar>, IAvisoGrupoFamiliarService
    {
        private IconnectCoreContext context;

        public AvisoGrupoFamiliarService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<AvisoGrupoFamiliarViewModel> GetAvisoGrupoFamiliarFiltrado(AvisoGrupoFamiliarFilterModel filter)
        {
            var query = (from avg in Context.tb_avg_avisoGrupoFamiliar
                         join cav in Context.tb_cav_categorizacaoAviso on avg.avg_cav_n_codigo equals cav.cav_n_codigo
                         select new AvisoGrupoFamiliarViewModel
                         {
                             avg_n_codigo = avg.avg_n_codigo.ToString(),
                             avg_cav_n_codigo = avg.avg_cav_n_codigo.ToString(),
                             Categoria = cav.cav_c_descricao.ToString(),
                             avg_b_lidoNaoLido = avg.avg_b_lidoNaoLido.ToString(),
                             avg_grf_n_codigo = avg.avg_grf_n_codigo.ToString(),
                             avg_c_descricao = avg.avg_c_descricao.ToString(),
                             avg_d_modificacao = avg.avg_d_modificacao.ToString(),
                             avg_c_unique = avg.avg_c_unique.ToString(),
                             avg_d_atualizado = avg.avg_d_atualizado.ToString(),
                             avg_d_inclusao = avg.avg_d_inclusao.ToString(),
                         });

            if (!string.IsNullOrEmpty(filter.avg_grf_n_codigo_filter))
            {
                if(filter.avg_grf_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.avg_grf_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.avg_grf_n_codigo == filter.avg_grf_n_codigo_filter);
                }
            }

            return query.OrderBy(x => x.avg_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarAvisoGrupoFamiliar(AvisoGrupoFamiliarViewModel model)
        {
            try
            {
                int? auxIdGrupo = null;
                if(model.avg_grf_n_codigo != "0")
                {
                    auxIdGrupo = Convert.ToInt32(model.avg_grf_n_codigo);
                }

                if (string.IsNullOrEmpty(model.avg_n_codigo) || model.avg_n_codigo.ToString() == "0")
                {
                    Insert(new tb_avg_avisoGrupoFamiliar()
                    {
                        avg_cav_n_codigo = Convert.ToInt32(model.avg_cav_n_codigo),
                        avg_b_lidoNaoLido = false,
                        avg_grf_n_codigo = auxIdGrupo,
                        avg_c_descricao = model.avg_c_descricao,
                        avg_d_modificacao = DateTime.Now,
                        avg_c_unique = new Guid(),
                        avg_d_atualizado = DateTime.Now,
                        avg_d_inclusao = DateTime.Now
                    });
                }
                else
                {
                    var AvisoGrupoFamiliar = (from avg in context.tb_avg_avisoGrupoFamiliar where avg.avg_n_codigo == Convert.ToInt32(model.avg_n_codigo) select avg).FirstOrDefault();
                    AvisoGrupoFamiliar.avg_cav_n_codigo = Convert.ToInt32(model.avg_cav_n_codigo);
                    AvisoGrupoFamiliar.avg_c_descricao = model.avg_c_descricao;
                    AvisoGrupoFamiliar.avg_d_modificacao = DateTime.Now;
                    AvisoGrupoFamiliar.avg_d_atualizado = DateTime.Now;

                    Update(AvisoGrupoFamiliar);
                }

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarAvisoGrupoFamiliar(int id)
        {
            try
            {
                Delete(context.tb_avg_avisoGrupoFamiliar.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarAvisoGrupoFamiliarSemGrupo()
        {
            try
            {
                var lstAvisos = context.tb_avg_avisoGrupoFamiliar.Where(x => x.avg_grf_n_codigo == null).ToList();

                if(lstAvisos.Count() > 0)
                {
                    foreach (var aviso in lstAvisos)
                    {
                        Delete(aviso);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        public bool VincularAvisos(int idGrupo)
        {
            try
            {
                var lstAvisos = context.tb_avg_avisoGrupoFamiliar.Where(x => x.avg_grf_n_codigo == null).ToList();

                if (lstAvisos.Count() > 0)
                {
                    foreach (var aviso in lstAvisos)
                    {
                        aviso.avg_grf_n_codigo = idGrupo;
                        Update(aviso);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}