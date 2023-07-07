using System;
using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using Iconnect.Aplicacao.FilterModel;

namespace Iconnect.Aplicacao.Services
{
    public class PermissionamentoService : RepositoryBase<tb_per_permissionamento>, IPermissionamentoService
    {
        private IconnectCoreContext context;

        public PermissionamentoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }
        public bool DeletarPermissionamento(Guid id)
        {
            try
            {
                Delete(context.tb_per_permissionamento.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public IPagedList<PermissionamentoViewModel> GetPermissionamentosFiltrado(PermissionamentoFilterModel filter)
        {
            var query = (from per in context.tb_per_permissionamento
                         orderby per.per_b_ativo == false, per.per_c_chave
                         select new PermissionamentoViewModel()
                         {
                             Acessos = (from ace in context.tb_ace_acesso
                                        where per.tb_ace_per_acessoPermissionamento.Select(x => x.per_ace_n_codigo).Contains(ace.ace_n_codigo)
                                        select new AcessoViewModel()
                                        {
                                            ace_b_bloqueado = ace.ace_b_bloqueado,
                                            ace_b_relacional = Convert.ToBoolean(ace.ace_b_relacional),
                                            ace_c_login = ace.ace_c_login,
                                            ace_c_senha = ace.ace_c_senha,
                                            ace_c_unique = ace.ace_c_unique,
                                            ace_d_atualizado = ace.ace_d_atualizado,
                                            ace_d_inclusao = ace.ace_d_inclusao,
                                            ace_d_modificacao = ace.ace_d_modificacao,
                                            ace_emp_n_codigo = Convert.ToInt32(ace.ace_emp_n_codigo),
                                            ace_n_codigo = ace.ace_n_codigo,
                                            ace_per_n_codigo = Convert.ToInt32(ace.ace_per_n_codigo)
                                        }).ToList(),
                             Perfis = (from perfil in context.tb_per_perfil
                                       where per.tb_per_per_perfilPermissionamento.Select(x => x.per_n_codigo).Contains(perfil.per_n_codigo)
                                       select new PerfilViewModel()
                                       {
                                           per_c_nome = perfil.per_c_nome,
                                           per_c_unique = perfil.per_c_unique,
                                           per_d_atualizado = perfil.per_d_atualizado,
                                           per_d_inclusao = perfil.per_d_inclusao,
                                           per_d_modificacao = perfil.per_d_modificacao,
                                           per_n_codigo = perfil.per_n_codigo
                                       }).ToList(),
                             per_b_ativo = per.per_b_ativo,
                             per_c_chave = per.per_c_chave,
                             per_u_codigo = per.per_u_codigo,
                         });

            if (!string.IsNullOrEmpty(filter.per_c_chave))
            {
                query = query.Where(w => w.per_c_chave.Contains(filter.per_c_chave));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }


        public List<PermissionamentoViewModel> ListarPermissionamentos()
        {
            return (from per in context.tb_per_permissionamento
                    select new PermissionamentoViewModel() {
                        Acessos = (from ace in context.tb_ace_acesso
                                   where per.tb_ace_per_acessoPermissionamento.Select(x => x.per_ace_n_codigo).Contains(ace.ace_n_codigo)
                                   select new AcessoViewModel()
                                   {
                                       ace_b_bloqueado = ace.ace_b_bloqueado,
                                       ace_b_relacional = Convert.ToBoolean(ace.ace_b_relacional),
                                       ace_c_login = ace.ace_c_login,
                                       ace_c_senha = ace.ace_c_senha,
                                       ace_c_unique = ace.ace_c_unique,
                                       ace_d_atualizado = ace.ace_d_atualizado,
                                       ace_d_inclusao = ace.ace_d_inclusao,
                                       ace_d_modificacao = ace.ace_d_modificacao,
                                       ace_emp_n_codigo = Convert.ToInt32(ace.ace_emp_n_codigo),
                                       ace_n_codigo = ace.ace_n_codigo,
                                       ace_per_n_codigo = Convert.ToInt32(ace.ace_per_n_codigo)
                                   }).ToList(),
                        Perfis = (from perfil in context.tb_per_perfil
                                  where per.tb_per_per_perfilPermissionamento.Select(x => x.per_n_codigo).Contains(perfil.per_n_codigo)
                                  select new PerfilViewModel()
                                  {
                                      per_c_nome = perfil.per_c_nome,
                                      per_c_unique = perfil.per_c_unique,
                                      per_d_atualizado = perfil.per_d_atualizado,
                                      per_d_inclusao = perfil.per_d_inclusao,
                                      per_d_modificacao = perfil.per_d_modificacao,
                                      per_n_codigo = perfil.per_n_codigo
                                  }).ToList(),
                        per_b_ativo = per.per_b_ativo,
                        per_c_chave = per.per_c_chave,
                        per_u_codigo = per.per_u_codigo,
                    }).ToList();
        }

        public List<PermissionamentoViewModel> ObterDadosPermissionamento(Guid id)
        {
            var ret = (from per in context.tb_per_permissionamento
                       where per.per_u_codigo == id
                       select new PermissionamentoViewModel()
                       {
                           Acessos = (from ace in context.tb_ace_acesso
                                      where per.tb_ace_per_acessoPermissionamento.Select(x => x.per_ace_n_codigo).Contains(ace.ace_n_codigo)
                                      select new AcessoViewModel()
                                      {
                                          ace_b_bloqueado = ace.ace_b_bloqueado,
                                          ace_b_relacional = Convert.ToBoolean(ace.ace_b_relacional),
                                          ace_c_login = ace.ace_c_login,
                                          ace_c_senha = ace.ace_c_senha,
                                          ace_c_unique = ace.ace_c_unique,
                                          ace_d_atualizado = ace.ace_d_atualizado,
                                          ace_d_inclusao = ace.ace_d_inclusao,
                                          ace_d_modificacao = ace.ace_d_modificacao,
                                          ace_emp_n_codigo = Convert.ToInt32(ace.ace_emp_n_codigo),
                                          ace_n_codigo = ace.ace_n_codigo,
                                          ace_per_n_codigo = Convert.ToInt32(ace.ace_per_n_codigo)
                                      }).ToList(),
                           Perfis = (from perfil in context.tb_per_perfil
                                     where per.tb_per_per_perfilPermissionamento.Select(x => x.per_n_codigo).Contains(perfil.per_n_codigo)
                                     select new PerfilViewModel()
                                     {
                                         per_c_nome = perfil.per_c_nome,
                                         per_c_unique = perfil.per_c_unique,
                                         per_d_atualizado = perfil.per_d_atualizado,
                                         per_d_inclusao = perfil.per_d_inclusao,
                                         per_d_modificacao = perfil.per_d_modificacao,
                                         per_n_codigo = perfil.per_n_codigo
                                     }).ToList(),
                           per_b_ativo = per.per_b_ativo,
                           per_c_chave = per.per_c_chave,
                           per_u_codigo = per.per_u_codigo
                       }).ToList();


            return ret;
        }

        public bool SalvarPermissionamento(PermissionamentoViewModel model)
        {
            try
            {
                var acessos = context.tb_ace_per_acessoPermissionamento.Where(x => x.per_u_n_codigo == model.per_u_codigo);
                var perfis = context.tb_per_per_perfilPermissionamento.Where(x => x.per_u_n_codigo == model.per_u_codigo);
                context.tb_per_per_perfilPermissionamento.RemoveRange(perfis);
                context.tb_ace_per_acessoPermissionamento.RemoveRange(acessos);
               
                if (model.per_u_codigo == null || model.per_u_codigo == Guid.Empty)
                {
                    model.per_u_codigo = Guid.NewGuid();
                    Insert(new tb_per_permissionamento()
                    {
                        per_b_ativo = true,
                        per_c_chave = model.per_c_chave,
                        per_u_codigo = model.per_u_codigo
                    });
                }
                else
                {
                    var permissionamentoDB = context.tb_per_permissionamento.Find(model.per_u_codigo);
                    if(permissionamentoDB != null)
                    {
                        permissionamentoDB.per_c_chave = model.per_c_chave;
                        permissionamentoDB.per_b_ativo = true;//model.per_b_ativo;
                        Update(permissionamentoDB);
                    }
                }

                List<tb_ace_per_acessoPermissionamento> acessosToInsert = model.Acessos.Select(x => new tb_ace_per_acessoPermissionamento()
                {
                    ace_per_u_codigo = Guid.NewGuid(),
                    per_ace_n_codigo = x.ace_n_codigo,
                    per_u_n_codigo = model.per_u_codigo,
                    tb_per_permissionamento = null,
                    tb_ace_acesso = null
                }).ToList();

                acessosToInsert.ForEach(x => context.tb_ace_per_acessoPermissionamento.Add(x));

                List<tb_per_per_perfilPermissionamento> perfisToInsert = model.Perfis.Select(x => new tb_per_per_perfilPermissionamento()
                {
                    
                    per_per_u_codigo = Guid.NewGuid(),
                    per_n_codigo = x.per_n_codigo,
                    per_u_n_codigo = model.per_u_codigo,
                    tb_per_perfil = null,
                    tb_per_permissionamento = null
                }).ToList();
                perfisToInsert.ForEach(x => context.tb_per_per_perfilPermissionamento.Add(x));
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
