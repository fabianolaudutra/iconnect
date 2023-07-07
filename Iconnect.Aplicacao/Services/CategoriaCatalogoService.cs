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
    public class CategoriaCatalogoService : RepositoryBase<tb_cat_categoriaCatalogo>, ICategoriaCatalogoService
    {
        private readonly IconnectCoreContext context;

        public CategoriaCatalogoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarCategoriaCatalogo(int id)
        {
            try
            {
                Delete(context.tb_cat_categoriaCatalogo.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public IPagedList<CategoriaCatalogoViewModel> GetCategoriaCatalogoFiltrado(CategoriaCatalogoFilterModel filter)
        {
            try
            {
                var query = (from cat in context.tb_cat_categoriaCatalogo orderby cat.cat_c_nome                           
                             select new CategoriaCatalogoViewModel
                             {
                                 cat_n_codigo = cat.cat_n_codigo.ToString(),
                                 cat_cli_n_codigo = cat.cat_cli_n_codigo.ToString(),
                                 cat_b_ativo = cat.cat_b_ativo == true ? "ATIVO" : "INATIVO",
                                 cat_b_tipoLink = cat.cat_b_tipoLink.ToString(),
                                 cat_b_solicitarEspecialidade = cat.cat_b_solicitarEspecialidade.ToString(),
                                 cat_c_nome = cat.cat_c_nome,
                                 cat_c_descricao = cat.cat_c_descricao,
                                 cat_c_link = cat.cat_c_link == null ? "" : cat.cat_c_link,
                                 cat_c_imagem = cat.cat_c_imagem == null ? "" : cat.cat_c_imagem,
                             });

                int codCli = Convert.ToInt32(filter.cat_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.cat_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.cat_cli_n_codigo == null);
                }

                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CategoriaCatalogoViewModel GetCategoriaCatalogo(int id)
        {
            return (from cat in Context.tb_cat_categoriaCatalogo
                    where cat.cat_n_codigo == id

                    select new CategoriaCatalogoViewModel
                    {
                        cat_n_codigo = cat.cat_n_codigo.ToString(),
                        cat_cli_n_codigo = cat.cat_cli_n_codigo.ToString(),
                        cat_b_ativo = cat.cat_b_ativo == true ? "ATIVO" : "INATIVO",
                        cat_b_tipoLink = cat.cat_b_tipoLink.ToString(),
                        cat_b_solicitarEspecialidade = cat.cat_b_solicitarEspecialidade.ToString(),
                        cat_c_nome = cat.cat_c_nome,
                        cat_c_descricao = cat.cat_c_descricao,
                        cat_c_link = cat.cat_c_link == null ? "" : cat.cat_c_link,
                        cat_c_imagem = cat.cat_c_imagem == null ? "" : cat.cat_c_imagem,
                    }).FirstOrDefault();
        }

        public List<CategoriaCatalogoViewModel> GetCategoriaCatalogoPorCliente(int idCliente)
        {
            var lstCategoriaCatalogo = (from cat in Context.tb_cat_categoriaCatalogo
                                        where cat.cat_cli_n_codigo == idCliente
                                        orderby cat.cat_c_nome ascending
                                        select new CategoriaCatalogoViewModel
                                        {
                                           cat_n_codigo = cat.cat_n_codigo.ToString(),
                                           cat_cli_n_codigo = cat.cat_cli_n_codigo.ToString(),
                                           cat_b_ativo = cat.cat_b_ativo == true ? "ATIVO" : "INATIVO",
                                           cat_b_tipoLink = cat.cat_b_tipoLink.ToString(),
                                           cat_b_solicitarEspecialidade = cat.cat_b_solicitarEspecialidade.ToString(),
                                           cat_c_nome = cat.cat_c_nome,
                                           cat_c_descricao = cat.cat_c_descricao,
                                           cat_c_link = cat.cat_c_link,
                                           cat_c_imagem = cat.cat_c_imagem
                                        }).ToList();

            return lstCategoriaCatalogo;
        }

        public CategoriaCatalogoViewModel InserOrUpdate(CategoriaCatalogoViewModel model)
        {
            try
            {
                int? codeCli = null;
                if (model.cat_cli_n_codigo != null && model.cat_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.cat_cli_n_codigo);
                }

                int codeCat = Convert.ToInt32(model.cat_n_codigo);

                if (codeCat == 0)
                {
                    Insert(new tb_cat_categoriaCatalogo()
                    {
                        cat_cli_n_codigo = codeCli.Value,
                        cat_b_ativo = model.cat_b_ativo == "true" ? true : false,
                        cat_b_tipoLink = model.cat_b_tipoLink == "true" ? true : false,
                        cat_b_solicitarEspecialidade = model.cat_b_solicitarEspecialidade == "true" ? true : false,
                        cat_c_nome = model.cat_c_nome,
                        cat_c_descricao = model.cat_c_descricao,
                        cat_c_link = model.cat_c_link,
                        cat_c_imagem = model.cat_c_imagem,
                        cat_c_unique = Guid.NewGuid(),
                        cat_d_atualizado = DateTime.Now,
                        cat_d_inclusao = DateTime.Now,
                    });
                }
                else
                {
                    var cat = (from categoriaCatalogo in context.tb_cat_categoriaCatalogo where categoriaCatalogo.cat_n_codigo == codeCat select categoriaCatalogo).FirstOrDefault();

                    cat.cat_cli_n_codigo = codeCli.Value;
                    cat.cat_b_ativo = model.cat_b_ativo == "true" ? true : false;
                    cat.cat_b_tipoLink = model.cat_b_tipoLink == "true" ? true : false;
                    cat.cat_b_solicitarEspecialidade = model.cat_b_solicitarEspecialidade == "true" ? true : false;
                    cat.cat_c_nome = model.cat_c_nome;
                    cat.cat_c_descricao = model.cat_c_descricao;
                    cat.cat_c_link = model.cat_c_link;
                    cat.cat_c_imagem = model.cat_c_imagem;

                    Update(cat);
                }

                context.SaveChanges();

                return model;
            }
            
            catch (Exception ex)
            { }

            return model;

        }

        public List<GenericList> GetCatalogoSemLink(int idCliente)
        {
          return (from cat in Context.tb_cat_categoriaCatalogo
                  where cat.cat_cli_n_codigo == idCliente && cat.cat_b_ativo == true && (cat.cat_c_link == null || cat.cat_c_link == "")
                  orderby cat.cat_c_nome ascending
                  select new GenericList
                  {                       
                      value = cat.cat_n_codigo.ToString(),
                      value2 = cat.cat_b_solicitarEspecialidade.ToString(),
                      text = cat.cat_c_nome.ToUpper(),                        

                  }).ToList();
        }

        public List<CategoriaCatalogoViewModel> GetComboCatalogoSemLink(int idCliente)
        {
            return (from cat in Context.tb_cat_categoriaCatalogo
                    where cat.cat_cli_n_codigo == idCliente && cat.cat_b_ativo == true && (cat.cat_c_link == null || cat.cat_c_link == "")
                    orderby cat.cat_c_nome ascending
                    select new CategoriaCatalogoViewModel
                    {
                        cat_n_codigo = cat.cat_n_codigo.ToString(),
                        cat_b_solicitarEspecialidade = cat.cat_b_solicitarEspecialidade.ToString(),
                        cat_c_nome = cat.cat_c_nome.ToUpper(),

                    }).ToList();
        }

        public List<GenericList> GetCategoriaCatalogoComboPorId(int id)
        {
            return (from cat in Context.tb_cat_categoriaCatalogo
                    where cat.cat_n_codigo == id && cat.cat_b_ativo == true 
                    orderby cat.cat_c_nome ascending
                    select new GenericList
                    {
                        value = cat.cat_n_codigo.ToString(),
                        value2 = cat.cat_b_solicitarEspecialidade.ToString(),
                        text = cat.cat_c_nome.ToUpper(),

                    }).ToList();
        }
    }
}
