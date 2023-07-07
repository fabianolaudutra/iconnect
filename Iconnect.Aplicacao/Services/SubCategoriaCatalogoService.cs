using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class SubCategoriaCatalogoService : RepositoryBase<tb_scc_subCategoriaCatalogo>, ISubCategoriaCatalogoService
    {
        private readonly IconnectCoreContext context;

        public SubCategoriaCatalogoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarSubCategoriaCatalogo(int id)
        {
            try
            {
                Delete(context.tb_scc_subCategoriaCatalogo.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public SubCategoriaCatalogoViewModel GetSubCategoriaCatalogo(int id)
        {
            return (from scc in Context.tb_scc_subCategoriaCatalogo
                    where scc.scc_n_codigo == id

                    select new SubCategoriaCatalogoViewModel
                    {
                        scc_n_codigo = scc.scc_n_codigo.ToString(),
                        scc_cat_n_codigo = scc.scc_cat_n_codigo.ToString(),
                        scc_cli_n_codigo = scc.scc_cli_n_codigo.ToString(),
                        scc_b_ativo = scc.scc_b_ativo == true ? "ATIVO" : "INATIVO",
                        scc_c_nome = scc.scc_c_nome,
                        scc_c_imagem = scc.scc_c_imagem == null ? "" : scc.scc_c_imagem,
                    }).FirstOrDefault();
        }

        public List<GenericList> GetSubCategoriaCatalogoComboPorId(int id)
        {
            return (from scc in Context.tb_scc_subCategoriaCatalogo
                    where scc.scc_cat_n_codigo == id && scc.scc_b_ativo == true
                    orderby scc.scc_c_nome ascending
                    select new GenericList
                    {
                        value = scc.scc_n_codigo.ToString(),
                        text = scc.scc_c_nome.ToUpper(),

                    }).ToList();
        }

        public IPagedList<SubCategoriaCatalogoViewModel> GetSubCategoriaCatalogoFiltrado(SubCategoriaCatalogoFilterModel filter)
        {
            try
            {
                var query = (from scc in context.tb_scc_subCategoriaCatalogo
                             join cat in context.tb_cat_categoriaCatalogo on scc.scc_cat_n_codigo equals cat.cat_n_codigo
                             select new SubCategoriaCatalogoViewModel
                             {
                                 scc_n_codigo = scc.scc_n_codigo.ToString(),
                                 scc_cat_n_codigo = scc.scc_cat_n_codigo.ToString(),
                                 scc_cli_n_codigo = scc.scc_cli_n_codigo.ToString(),
                                 scc_b_ativo = scc.scc_b_ativo == true ? "ATIVO" : "INATIVO",
                                 scc_c_nome = scc.scc_c_nome,
                                 scc_cat_c_nome = cat.cat_c_nome,
                                 scc_c_imagem = scc.scc_c_imagem == null ? "" : scc.scc_c_imagem,
                             });

                int codCli = Convert.ToInt32(filter.scc_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.scc_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.scc_cli_n_codigo == null);
                }

                return query.OrderBy(x => x.scc_cat_c_nome).ThenBy(x => x.scc_c_nome).ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<SubCategoriaCatalogoViewModel> GetSubCategoriaCatalogoPorCliente(int idCliente)
        {
            var lstSubCategoriaCatalogo = (from scc in Context.tb_scc_subCategoriaCatalogo
                                           where scc.scc_cli_n_codigo == idCliente
                                           orderby scc.scc_c_nome ascending
                                           select new SubCategoriaCatalogoViewModel
                                           {
                                               scc_b_ativo = scc.scc_b_ativo == true ? "ATIVO" : "INATIVO",
                                               scc_n_codigo = scc.scc_n_codigo.ToString(),
                                               scc_cat_n_codigo = scc.scc_cat_n_codigo.ToString(),
                                               scc_cli_n_codigo = scc.scc_cli_n_codigo.ToString(),
                                               scc_c_nome = scc.scc_c_nome,
                                               scc_c_imagem = scc.scc_c_imagem == null ? "" : scc.scc_c_imagem,

                                           }).ToList();

            return lstSubCategoriaCatalogo;
        }

        public SubCategoriaCatalogoViewModel InserOrUpdate(SubCategoriaCatalogoViewModel model)
        {
            try
            {
                var duplicado = ValidaDuplicidade(model);
                
                if(duplicado == true)
                {
                    return null;
                }

                int? codeCli = null;
                if (model.scc_cli_n_codigo != null && model.scc_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.scc_cli_n_codigo);
                }

                int codeSCC = Convert.ToInt32(model.scc_n_codigo);

                if (codeSCC == 0)
                {
                    Insert(new tb_scc_subCategoriaCatalogo()
                    {
                        scc_b_ativo = model.scc_b_ativo == "true" ? true : false,
                        scc_cat_n_codigo = int.Parse(model.scc_cat_n_codigo),
                        scc_cli_n_codigo = codeCli.Value,
                        scc_c_nome = model.scc_c_nome,
                        scc_c_imagem = model.scc_c_imagem,
                        scc_c_unique = Guid.NewGuid(),
                        scc_d_atualizado = DateTime.Now,
                        scc_d_inclusao = DateTime.Now,
                    });
                }
                else
                {
                    var scc = (from subCategoriaCatalogo in context.tb_scc_subCategoriaCatalogo where subCategoriaCatalogo.scc_n_codigo == codeSCC select subCategoriaCatalogo).FirstOrDefault();

                    scc.scc_b_ativo = model.scc_b_ativo == "true" ? true : false;
                    scc.scc_cat_n_codigo = int.Parse(model.scc_cat_n_codigo);
                    scc.scc_cli_n_codigo = codeCli.Value;
                    scc.scc_c_nome = model.scc_c_nome;
                    scc.scc_c_imagem = model.scc_c_imagem;
                    scc.scc_c_unique = Guid.NewGuid();
                    scc.scc_d_atualizado = DateTime.Now;
                    scc.scc_d_inclusao = DateTime.Now;

                    Update(scc);
                }

                context.SaveChanges();

                return model;
            }

            catch (Exception ex)
            { }

            return model;
        }

        public bool ValidaDuplicidade(SubCategoriaCatalogoViewModel model)
        {
            var duplicado = (from scc in context.tb_scc_subCategoriaCatalogo
                             where scc.scc_cli_n_codigo == Convert.ToInt32(model.scc_cli_n_codigo) 
                             && scc.scc_cat_n_codigo == Convert.ToInt32(model.scc_cat_n_codigo)
                             && scc.scc_c_nome.Contains(model.scc_c_nome)
                             && scc.scc_n_codigo != Convert.ToInt32(model.scc_n_codigo)
                             select scc).ToList();

            if(duplicado.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
