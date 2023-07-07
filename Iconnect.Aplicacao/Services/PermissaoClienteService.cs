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
    class PermissaoClienteService : RepositoryBase<tb_pec_permissaoCliente>, IPermissaoClienteService
    {
        private IconnectCoreContext context;

        public PermissaoClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<PermissaoClienteViewModel> GetPermissaoClienteFiltrado(PermissaoClienteFilterModel filter)
        {
            var query = (from pec in Context.tb_pec_permissaoCliente
                         join cli in Context.tb_cli_cliente on pec.pec_cli_n_codigo equals cli.cli_n_codigo
                         join emp in Context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                         select new PermissaoClienteViewModel
                         {
                             pec_n_codigo = pec.pec_n_codigo.ToString(),
                             pec_cli_n_codigo = pec.pec_cli_n_codigo.ToString(),
                             pec_ope_n_codigo = pec.pec_ope_n_codigo.ToString(),
                             pec_b_editaInformacoes = pec.pec_b_editaInformacoes.Value ? "SIM" : "NÃO",
                             pec_usu_n_codigo = pec.pec_usu_n_codigo.ToString(),
                             pec_d_modificacao = pec.pec_d_modificacao.ToString(),
                             pec_c_unique = pec.pec_c_unique.ToString(),
                             pec_d_atualizado = pec.pec_d_atualizado.ToString(),
                             pec_d_inclusao = pec.pec_d_inclusao.ToString(),
                             cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                             emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                         });

            if (!string.IsNullOrEmpty(filter.pec_ope_n_codigo_filter))
            {
                if(filter.pec_ope_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.pec_ope_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.pec_ope_n_codigo == filter.pec_ope_n_codigo_filter);
                }
            }

            return query.OrderBy(x => x.emp_c_nomeFantasia).ThenBy(y => y.cli_c_nomeFantasia).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarPermissaoCliente(PermissaoClienteViewModel model)
        {
            try
            {
                int? auxIdOperador = null;
                if(model.pec_ope_n_codigo != "0")
                {
                    auxIdOperador = Convert.ToInt32(model.pec_ope_n_codigo);
                }

                foreach (string cli_n_codigo in model.lstCliente)
                {
                    var queryPermissao = (from pec in Context.tb_pec_permissaoCliente
                                          where pec.pec_ope_n_codigo == auxIdOperador && pec.pec_cli_n_codigo == Convert.ToInt32(cli_n_codigo)
                                          select new PermissaoClienteViewModel
                                          {
                                              pec_n_codigo = pec.pec_n_codigo.ToString(),
                                          });

                    if (queryPermissao.Count() == 0)
                    {
                        Insert(new tb_pec_permissaoCliente()
                        {
                            pec_cli_n_codigo = Convert.ToInt32(cli_n_codigo),
                            pec_ope_n_codigo = auxIdOperador,
                            pec_b_editaInformacoes = Convert.ToBoolean(model.pec_b_editaInformacoes),
                            //pec_usu_n_codigo = Convert.ToInt32(model.pec_usu_n_codigo),
                            pec_d_modificacao = DateTime.Now,
                            pec_c_unique = new Guid(),
                            pec_d_atualizado = DateTime.Now,
                            pec_d_inclusao = DateTime.Now
                        });
                    }
                    else
                    {
                        var auxPec = queryPermissao.FirstOrDefault();
                        var PermissaoCliente = (from pec in context.tb_pec_permissaoCliente where pec.pec_n_codigo == Convert.ToInt32(auxPec.pec_n_codigo) select pec).FirstOrDefault();
                        PermissaoCliente.pec_cli_n_codigo = Convert.ToInt32(cli_n_codigo);
                        PermissaoCliente.pec_ope_n_codigo = auxIdOperador;
                        PermissaoCliente.pec_b_editaInformacoes = Convert.ToBoolean(model.pec_b_editaInformacoes);
                        //PermissaoCliente.pec_usu_n_codigo = Convert.ToInt32(model.pec_usu_n_codigo);
                        PermissaoCliente.pec_d_modificacao = DateTime.Now;
                        PermissaoCliente.pec_d_atualizado = DateTime.Now;

                        Update(PermissaoCliente);
                    }
                }

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarPermissaoCliente(int id)
        {
            try
            {
                Delete(context.tb_pec_permissaoCliente.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarPermissaoClienteSemOperador()
        {
            try
            {
                var lstPermissoes = context.tb_pec_permissaoCliente.Where(x => x.pec_ope_n_codigo == null).ToList();

                if(lstPermissoes.Count() > 0)
                {
                    foreach (var permissao in lstPermissoes)
                    {
                        Delete(permissao);
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

        
        public bool VincularPermissoes(int idOperador)
        {
            try
            {
                var lstPermissoes = context.tb_pec_permissaoCliente.Where(x => x.pec_ope_n_codigo == null).ToList();

                if (lstPermissoes.Count() > 0)
                {
                    foreach (var permissao in lstPermissoes)
                    {
                        permissao.pec_ope_n_codigo = idOperador;
                        Update(permissao);
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