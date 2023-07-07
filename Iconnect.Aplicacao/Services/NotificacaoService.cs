using System.Collections.Generic;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;
using System;
using PagedList;
using System.Globalization;

namespace Iconnect.Aplicacao.Services
{
    public class NotificacaoService : RepositoryBase<tb_not_notificacao>, INotificacaoService
    {
        private IconnectCoreContext context;

        public NotificacaoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<NotificacaoViewModel> ListarNotificacao(NotificacaoFilterViewModel filter)
        {
            DateTime data = DateTime.Today;
            var query = new List<NotificacaoViewModel>();

            //EMPRESA
            if (filter.IdPerfil == 2)
            {
                query = (from not in context.tb_not_notificacao
                         join aviso in context.tb_avi_avisoEmpresa on not.not_avi_n_codigoEmpresa equals aviso.avi_n_codigo
                         orderby not.not_b_lido, not.not_n_codigo descending
                         where not.not_emp_n_codigo.Equals(filter.IdUsuario)
                         select new NotificacaoViewModel()
                         {
                             titulo = aviso.avi_c_titulo.ToString(),
                             mensagem = aviso.avi_c_descricao.ToString(),
                             dataInicio = aviso.avi_d_inicio.Value.ToString("dd/MM/yyyy"),
                             not_b_lido = not.not_b_lido ?? false,
                             not_n_codigo = not.not_n_codigo.ToString(),
                             not_emp_n_codigo = not.not_ope_n_codigo.ToString(),
                             not_avi_n_codigoEmpresa = not.not_avi_n_codigoEmpresa.ToString(),
                         }).ToList();
            }
            //Operador
            if (filter.IdPerfil == 5)
            {
                query = (from not in context.tb_not_notificacao
                         join aviso in context.tb_avi_aviso on not.not_avi_n_codigo equals aviso.avi_n_codigo
                         orderby not.not_b_lido, not.not_n_codigo descending
                         where not.not_ope_n_codigo.Equals(filter.IdUsuario)
                         select new NotificacaoViewModel()
                         {
                             titulo = aviso.avi_c_titulo.ToString(),
                             mensagem = aviso.avi_c_descricao.ToString(),
                             dataInicio = aviso.avi_d_inicio.Value.ToString("dd/MM/yyyy"),
                             not_b_lido = not.not_b_lido ?? false,
                             not_n_codigo = not.not_n_codigo.ToString(),
                             not_ope_n_codigo = not.not_ope_n_codigo.ToString(),
                             not_avi_n_codigo = not.not_avi_n_codigo.ToString(),
                         }).ToList();
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public List<NotificacaoViewModel> PrimeirasNotificacoes(int IdUsuario, int IdPerfil)
        {
            if (IdPerfil == 2)
            {
                var query = (from not in context.tb_not_notificacao
                             join aviso in context.tb_avi_avisoEmpresa on not.not_avi_n_codigoEmpresa equals aviso.avi_n_codigo
                             orderby not.not_b_lido, not.not_n_codigo descending
                             where not.not_emp_n_codigo.Equals(IdUsuario)
                             select new NotificacaoViewModel()
                             {
                                 titulo = aviso.avi_c_titulo.ToString(),
                                 mensagem = aviso.avi_c_descricao.ToString(),
                                 dataInicio = aviso.avi_d_inicio.Value.ToString("dd/MM/yyyy"),
                                 not_b_lido = not.not_b_lido ?? false,
                                 not_n_codigo = not.not_n_codigo.ToString(),
                                 not_emp_n_codigo = not.not_ope_n_codigo.ToString(),
                                 not_avi_n_codigoEmpresa = not.not_avi_n_codigoEmpresa.ToString(),
                             }).ToList();

                return query.Take(3).ToList();
            }
            //Operador
            if (IdPerfil == 5)
            {
                var query = (from not in context.tb_not_notificacao
                             join aviso in context.tb_avi_aviso on not.not_avi_n_codigo equals aviso.avi_n_codigo
                             orderby not.not_b_lido, not.not_n_codigo descending
                             where not.not_ope_n_codigo == IdUsuario
                             select new NotificacaoViewModel()
                             {
                                 titulo = aviso.avi_c_titulo.ToString(),
                                 mensagem = aviso.avi_c_descricao.ToString(),
                                 not_b_lido = not.not_b_lido ?? false,
                                 not_n_codigo = not.not_n_codigo.ToString(),
                                 not_ope_n_codigo = not.not_ope_n_codigo.ToString(),
                                 not_avi_n_codigo = not.not_avi_n_codigo.ToString(),
                             });

                return query.Take(3).ToList();
            }
            else
            {
                return null;
            }
        }

        public bool UpdateStatus(NotificacaoViewModel[] model, int IdPerfil)
        {
            try
            {
                if (IdPerfil == 2)
                {
                    var not_n_codigo = model[0].not_n_codigo;

                    var exclusao = context.tb_not_notificacao.Where(x => x.not_n_codigo == Convert.ToInt32(not_n_codigo)).ToList();
                    if (exclusao != null && exclusao.Count > 0)
                    {
                        context.RemoveRange(exclusao);
                    }

                    for (int i = 0; i < model.Length; i++)
                    {
                        var status = model[i];

                        Insert(new tb_not_notificacao()
                        {
                            not_n_codigo = Convert.ToInt32(status.not_n_codigo),
                            //not_ope_n_codigo = Convert.ToInt32(status.not_ope_n_codigo),
                            not_emp_n_codigo = Convert.ToInt32(status.not_emp_n_codigo),
                            not_avi_n_codigo = Convert.ToInt32(status.not_avi_n_codigo),
                            not_b_lido = status.not_b_lido,
                        });
                    }

                    context.SaveChanges();
                    return true;

                }
                else if (IdPerfil == 5)
                {

                    var not_n_codigo = model[0].not_n_codigo;

                    var exclusao = context.tb_not_notificacao.Where(x => x.not_n_codigo == Convert.ToInt32(not_n_codigo)).ToList();
                    if (exclusao != null && exclusao.Count > 0)
                    {
                        context.RemoveRange(exclusao);
                    }

                    for (int i = 0; i < model.Length; i++)
                    {
                        var status = model[i];

                        Insert(new tb_not_notificacao()
                        {
                            not_n_codigo = Convert.ToInt32(status.not_n_codigo),
                            not_ope_n_codigo = Convert.ToInt32(status.not_ope_n_codigo),
                            //not_emp_n_codigo = Convert.ToInt32(status.not_emp_n_codigo),
                            not_avi_n_codigo = Convert.ToInt32(status.not_avi_n_codigo),
                            not_b_lido = status.not_b_lido,
                        });
                    }

                    context.SaveChanges();
                    return true;
                }


            }

            catch (Exception ex)
            {
            }

            return false;
        }

        public bool SalvarAvisoNotificacao(AvisoViewModel model)
        {
            try
            {
                var codigo = (from avi in context.tb_avi_aviso
                              orderby avi.avi_n_codigo descending
                              select avi).FirstOrDefault();

                var avi_n_codigo = codigo?.avi_n_codigo;
                int.TryParse(model?.avi_emp_n_codigo, out int avi_emp_n_codigo);

                var tamanho = model?.OperadoresSelecionados.Length - 1;

                for (int i = 0; i < tamanho; i++)
                {
                    Insert(new tb_not_notificacao()
                    {
                        not_avi_n_codigo = avi_n_codigo,
                        not_emp_n_codigo = avi_emp_n_codigo,
                        not_ope_n_codigo = Convert.ToInt32(model?.OperadoresSelecionados[i]),
                        not_b_lido = false,
                        not_d_inclusao = Convert.ToDateTime(model?.avi_d_inicio)
                    });

                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool SalvarAvisoEmpresaNotificacao(AvisoEmpresaViewModel model)
        {
            try
            {
                var codigo = (from avi in context.tb_avi_aviso
                              orderby avi.avi_n_codigo descending
                              select avi).FirstOrDefault();

                var avi_n_codigo = codigo?.avi_n_codigo;

                var tamanho = model?.EmpresasSelecionadas.Length - 1;

                for (int i = 0; i < tamanho; i++)
                {
                    Insert(new tb_not_notificacao()
                    {
                        not_avi_n_codigoEmpresa = avi_n_codigo,
                        not_emp_n_codigo = Convert.ToInt32(model?.EmpresasSelecionadas[i]),
                        not_b_lido = false,
                        not_d_inclusao = Convert.ToDateTime(model?.avi_d_inicio)
                    });
                }

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        public int IdPerfil(int id)
        {
            return id;
        }

    }
}