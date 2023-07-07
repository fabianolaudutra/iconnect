using System;
using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class LocalidadeGrupoFamiliarService : RepositoryBase<tb_lcg_localidadeClienteGrupoFamiliar>, ILocalidadeGrupoFamiliarService
    {
        private IconnectCoreContext context;

        public LocalidadeGrupoFamiliarService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object SalvarLocalidade(LocalidadeGrupoFamiliarViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                bool retornaLocatario = verificaLocatario(model);
                bool retornoBlocoQuadra = verificaBlocoLote(model);
                if (retornoBlocoQuadra)
                {
                    retorno.status = "error";
                    retorno.conteudo = "BlocoQuadraExistente";
                    return retorno;
                }

                if (retornaLocatario)
                {
                    retorno.status = "error";
                    retorno.conteudo = "TipoLocatarioResidencial";
                    return retorno;
                }

                if (model != null)
                {

                    if (string.IsNullOrEmpty(model.lcg_n_codigo) || model.lcg_n_codigo.Equals("0"))
                    {
                        if (string.IsNullOrEmpty(model.lcg_grf_n_codigo) || model.lcg_grf_n_codigo.Equals("0"))
                        {
                            Insert(new tb_lcg_localidadeClienteGrupoFamiliar()
                            {
                                lcg_grf_n_codigo = null,
                                lcg_d_modificacao = DateTime.Now,
                                lcg_c_unique = new Guid(),
                                lcg_d_atualizado = DateTime.Now,
                                lcg_d_inclusao = DateTime.Now,
                                lcg_lcc_n_codigoBlocoQuadra = Convert.ToInt32(model.lcg_lcc_n_codigoBlocoQuadra),
                                lcg_lcc_n_codigoLoteApto = Convert.ToInt32(model.lcg_lcc_n_codigoLoteApto),
                                lcg_n_vagas = Convert.ToInt32(model.lcg_n_vagas)
                            });
                            retorno.status = "success";
                            retorno.conteudo = "Localidade salva com sucesso!";
                        }
                        else
                        {
                            Insert(new tb_lcg_localidadeClienteGrupoFamiliar()
                            {
                                lcg_grf_n_codigo = Convert.ToInt32(model.lcg_grf_n_codigo),
                                lcg_d_modificacao = DateTime.Now,
                                lcg_c_unique = new Guid(),
                                lcg_d_atualizado = DateTime.Now,
                                lcg_d_inclusao = DateTime.Now,
                                lcg_lcc_n_codigoBlocoQuadra = Convert.ToInt32(model.lcg_lcc_n_codigoBlocoQuadra),
                                lcg_lcc_n_codigoLoteApto = Convert.ToInt32(model.lcg_lcc_n_codigoLoteApto),
                                lcg_n_vagas = Convert.ToInt32(model.lcg_n_vagas)
                            });
                            retorno.status = "success";
                            retorno.conteudo = "Localidade salva com sucesso";
                        }
                    }
                    else
                    {
                        var localidade = (from lcg in context.tb_lcg_localidadeClienteGrupoFamiliar
                                          where lcg.lcg_n_codigo == Convert.ToInt32(model.lcg_n_codigo)
                                          select lcg)?.FirstOrDefault();
                        if (localidade != null)
                        {
                            localidade.lcg_d_modificacao = DateTime.Now;
                            localidade.lcg_d_atualizado = DateTime.Now;
                            localidade.lcg_lcc_n_codigoBlocoQuadra = Convert.ToInt32(model.lcg_lcc_n_codigoBlocoQuadra);
                            localidade.lcg_lcc_n_codigoLoteApto = Convert.ToInt32(model.lcg_lcc_n_codigoLoteApto);
                            localidade.lcg_n_vagas = Convert.ToInt32(model.lcg_n_vagas);
                            Update(localidade);
                            retorno.status = "success";
                            retorno.conteudo = "Localidade editada com sucesso";
                        }
                    }

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return retorno;
            }
        }

        public IPagedList<LocalidadeGrupoFamiliarViewModel> GetLocalidade(LocalidadeGrupoFamiliarFilterModel filter)
        {
            var query = (from lcg in context.tb_lcg_localidadeClienteGrupoFamiliar
                         join lcc in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoBlocoQuadra equals lcc.lcc_n_codigo
                         join loc in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoLoteApto equals loc.lcc_n_codigo
                         select new LocalidadeGrupoFamiliarViewModel
                         {
                             lcg_lcc_n_codigoBlocoQuadra = lcc.lcc_n_codigo.ToString(),
                             lcg_lcc_n_codigoLoteApto = loc.lcc_n_codigo.ToString(),
                             lcg_n_vagas = lcg.lcg_n_vagas.ToString(),
                             DescricaoBlocoQuadra = lcc.lcc_c_descricao.ToString(),
                             DescricaoLoteApto = loc.lcc_c_descricao.ToString(),
                             lcg_n_codigo = lcg.lcg_n_codigo.ToString(),
                             lcg_grf_n_codigo = lcg.lcg_grf_n_codigo.ToString()
                         });

            if (!string.IsNullOrEmpty(filter.lcg_grf_n_codigo_filter))
            {
                if (filter.lcg_grf_n_codigo_filter == "0")
                {
                    query = query.Where(x => x.lcg_grf_n_codigo == null);
                }
                else
                {
                    query = query.Where(x => x.lcg_grf_n_codigo == filter.lcg_grf_n_codigo_filter);
                }
            }

            return query.OrderBy(x => x.lcg_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool DeletarLocalidade(int id)
        {
            try
            {
                Delete(context.tb_lcg_localidadeClienteGrupoFamiliar.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool VincularGrupoFamiliar(int id)
        {
            var localidade = (from lcg in context.tb_lcg_localidadeClienteGrupoFamiliar
                              where lcg.lcg_grf_n_codigo == null
                              select lcg)?.FirstOrDefault();
            if (localidade != null)
            {
                localidade.lcg_grf_n_codigo = Convert.ToInt32(id);
                Update(localidade);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verificaBlocoLote(LocalidadeGrupoFamiliarViewModel model)
        {
            try
            {
                int idLocalidade = Convert.ToInt32(model.lcg_n_codigo);
                int idCliente = Convert.ToInt32(model.idCliente);

                var query = (from lcg in context.tb_lcg_localidadeClienteGrupoFamiliar
                             join grf in context.tb_grf_grupoFamiliar on lcg.lcg_grf_n_codigo equals grf.grf_n_codigo
                             where idCliente == grf.grf_cli_n_codigo
                             && lcg.lcg_n_codigo != idLocalidade
                             select lcg).ToList();

                if (query.Any())
                {
                    for (var i = 0; i < query.Count; i++)
                    {
                        if (query[i].lcg_lcc_n_codigoBlocoQuadra == Convert.ToInt32(model.lcg_lcc_n_codigoBlocoQuadra)
                            && query[i].lcg_lcc_n_codigoLoteApto == Convert.ToInt32(model.lcg_lcc_n_codigoLoteApto))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public bool verificaLocalidade(int idGrupoFamiliar, int idCliente)
        {
            try
            {
                var query = (from lcg in context.tb_lcg_localidadeClienteGrupoFamiliar
                             join grf in context.tb_grf_grupoFamiliar on lcg.lcg_grf_n_codigo equals grf.grf_n_codigo
                             where lcg.lcg_grf_n_codigo == idGrupoFamiliar &&
                             grf.grf_cli_n_codigo == idCliente
                             select lcg).ToList();

                var novoRegistro = (from lcg in context.tb_lcg_localidadeClienteGrupoFamiliar
                                    orderby lcg.lcg_n_codigo descending
                                    where lcg.lcg_grf_n_codigo == null
                                    select lcg.lcg_d_inclusao).Count();

                if (!query.Any() && novoRegistro == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool verificaLocatario(LocalidadeGrupoFamiliarViewModel model)
        {
            try
            {
                int idLocalidade = Convert.ToInt32(model.lcg_n_codigo);
                string tipoGrupo = (from grf in context.tb_grf_grupoFamiliar
                                    join lcg in context.tb_lcg_localidadeClienteGrupoFamiliar on grf.grf_n_codigo equals lcg.lcg_grf_n_codigo
                                    where grf.grf_n_codigo == Convert.ToInt32(model.lcg_grf_n_codigo)
                                    && lcg.lcg_n_codigo != idLocalidade
                                    select grf.grf_c_tipo).FirstOrDefault();

                int tipoEmpresa = (int)(from cli in context.tb_cli_cliente
                                        where cli.cli_n_codigo == Convert.ToInt32(model.idCliente)
                                        select cli.cli_tcl_n_codigo).FirstOrDefault();

                if (tipoGrupo == "LOCATARIO" && tipoEmpresa == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public bool DeletarLocalidadeSemGrupo()
        {
            try
            {
                var lstLocalidades = context.tb_lcg_localidadeClienteGrupoFamiliar.Where(x => x.lcg_grf_n_codigo == null).ToList();

                if (lstLocalidades.Count() > 0)
                {
                    foreach (var aviso in lstLocalidades)
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
    }
}
