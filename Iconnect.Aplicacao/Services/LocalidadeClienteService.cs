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
    class LocalidadeClienteService : RepositoryBase<tb_lcc_localidadeCliente>, ILocalidadeClienteService
    {
        private IconnectCoreContext context;

        public LocalidadeClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object InsertOrUpdate(LocalidadeClienteViewModel model)
        {
            Retorno retorno = new Retorno();
            try
            {
                int? codeCli = null;
                if (model.lcc_cli_n_codigo != null && model.lcc_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.lcc_cli_n_codigo);
                }

                int codLcc = Convert.ToInt32(model.lcc_n_codigo);

                var lccExiste = ValidaDuplicidade(model);

                if (lccExiste)
                {
                    retorno.status = "duplicado";
                    retorno.conteudo = "Localidade já cadastrada.";
                    return retorno;
                }
                else
                {
                    if (codLcc == 0)
                    {
                        Insert(new tb_lcc_localidadeCliente()
                        {
                            lcc_cli_n_codigo = codeCli,
                            lcc_c_tipoLocalidade = model.lcc_c_tipoLocalidade,
                            lcc_c_descricao = model.lcc_c_descricao,
                            lcc_c_tipoLayout = model.lcc_c_tipoLayout,
                            lcc_c_unique = Guid.NewGuid(),
                            lcc_d_atualizado = DateTime.Now,
                            lcc_d_inclusao = DateTime.Now,
                            lcc_d_modificacao = DateTime.Now
                        });
                    }
                    else
                    {
                        var lcc = (from localidade in context.tb_lcc_localidadeCliente where localidade.lcc_n_codigo == codLcc select localidade).FirstOrDefault();

                        lcc.lcc_cli_n_codigo = codeCli;
                        lcc.lcc_c_tipoLocalidade = model.lcc_c_tipoLocalidade;
                        lcc.lcc_c_descricao = model.lcc_c_descricao;
                        lcc.lcc_c_tipoLayout = model.lcc_c_tipoLayout;

                        lcc.lcc_d_atualizado = DateTime.Now;
                        lcc.lcc_d_modificacao = DateTime.Now;

                        Update(lcc);
                    }
                    context.SaveChanges();
                    retorno.status = "sucesso";
                    retorno.conteudo = "Dados salvos com sucesso.";
                    retorno.id = Convert.ToInt32(model.lcc_n_codigo);
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                retorno.status = "erro";
                retorno.conteudo = "Ocorreu um erro ao salvar os dados.";
                retorno.id = Convert.ToInt32(model.lcc_n_codigo);
                return retorno;
            }
        }

        public IPagedList<LocalidadeClienteViewModel> GetLocalidadeFiltrado(LocalidadeClienteFilterModel filter)
        {
            try
            {
                var query = (from lcc in Context.tb_lcc_localidadeCliente
                             orderby lcc.lcc_c_tipoLocalidade
                             select new LocalidadeClienteViewModel
                             {
                                 lcc_n_codigo = lcc.lcc_n_codigo.ToString(),
                                 lcc_cli_n_codigo = lcc.lcc_cli_n_codigo.ToString(),
                                 lcc_c_tipoLocalidade = lcc.lcc_c_tipoLocalidade,
                                 lcc_c_descricao = lcc.lcc_c_descricao,

                             });


                int codCli = Convert.ToInt32(filter.lcc_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.lcc_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.lcc_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<GenericList> GetLocalidades(int id)
        {
            try
            {
                var query = (from lcc in Context.tb_lcc_localidadeCliente
                             where lcc.lcc_cli_n_codigo == id && (lcc.lcc_c_tipoLocalidade == "BLOCO-QUADRA" || lcc.lcc_c_tipoLocalidade == "BLOCO" || lcc.lcc_c_tipoLocalidade == "QUADRA" || lcc.lcc_c_tipoLocalidade == "TORRE" || lcc.lcc_c_tipoLocalidade == "SALA")

                             select new GenericList
                             {
                                 value = lcc.lcc_c_descricao.ToString(),
                                 text = lcc.lcc_c_descricao.ToString(),
                             }).ToList();

                return query;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarLocalidade(int id)
        {
            try
            {
                Delete(context.tb_lcc_localidadeCliente.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public LocalidadeClienteViewModel GetLocalidade(int id)
        {

            var loc = from lcc in Context.tb_lcc_localidadeCliente
                      where lcc.lcc_n_codigo == id

                      select new LocalidadeClienteViewModel
                      {
                          lcc_n_codigo = lcc.lcc_n_codigo.ToString(),
                          lcc_cli_n_codigo = lcc.lcc_cli_n_codigo.ToString(),
                          lcc_c_tipoLocalidade = lcc.lcc_c_tipoLocalidade,
                          lcc_c_descricao = lcc.lcc_c_descricao,
                          lcc_c_tipoLayout = lcc.lcc_c_tipoLayout,

                      };
            return loc.FirstOrDefault();
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_lcc_localidadeCliente> lista = new List<tb_lcc_localidadeCliente>();


                lista = (from lcc in context.tb_lcc_localidadeCliente where lcc.lcc_cli_n_codigo == null select lcc).OrderBy(x => x.lcc_c_descricao).ToList();


                foreach (var item in lista)
                {

                    DeletarLocalidade(item.lcc_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public bool Vincular(int id)
        {
            try
            {
                var lista = context.tb_lcc_localidadeCliente.Where(x => x.lcc_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.lcc_cli_n_codigo = id;
                        Update(item);
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

        public List<LocalidadeClienteViewModel> GetLocalidadeByTipo(int idCliente, string tipo)
        {
            List<string> tipos = new List<string>();
            foreach (var item in tipo.Split("-"))
            {
                tipos.Add(item);
            }
            List<LocalidadeClienteViewModel> lista = (from x in Context.tb_lcc_localidadeCliente
                                                      where (tipos.Contains(x.lcc_c_tipoLocalidade) || x.lcc_c_tipoLocalidade == tipo) && x.lcc_cli_n_codigo == idCliente
                                                      select new LocalidadeClienteViewModel
                                                      {
                                                          lcc_n_codigo = x.lcc_n_codigo.ToString(),
                                                          lcc_cli_n_codigo = x.lcc_cli_n_codigo.ToString(),
                                                          lcc_c_tipoLocalidade = x.lcc_c_tipoLocalidade,
                                                          lcc_c_descricao = x.lcc_c_descricao,
                                                          lcc_c_tipoLayout = x.lcc_c_tipoLayout,

                                                      }).ToList();
            return lista;
        }

        public GenericList GetLocalidadeByIds(string ids)
        {
            GenericList list = new GenericList();
            try
            {
                List<int> IdsLoc = new List<int>();
                foreach (var item in ids.Split(','))
                {
                    IdsLoc.Add(Convert.ToInt32(item));
                }

                var lista = (from lcc in Context.tb_lcc_localidadeCliente
                             where IdsLoc.Contains(lcc.lcc_n_codigo)

                             select new LocalidadeClienteViewModel
                             {
                                 lcc_n_codigo = lcc.lcc_n_codigo.ToString(),
                                 lcc_cli_n_codigo = lcc.lcc_cli_n_codigo.ToString(),
                                 lcc_c_tipoLocalidade = lcc.lcc_c_tipoLocalidade,
                                 lcc_c_descricao = lcc.lcc_c_descricao,
                                 lcc_c_tipoLayout = lcc.lcc_c_tipoLayout,

                             }).ToList();


                foreach (var item in lista)
                {
                    list.text += item.lcc_c_tipoLocalidade + ": " + item.lcc_c_descricao + "/";
                }

                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        public List<GenericList> GetLocalidadeComboByTipo(int idCliente, string tipo)
        {
            return (from lcc in Context.tb_lcc_localidadeCliente
                    where lcc.lcc_c_tipoLocalidade == tipo && lcc.lcc_cli_n_codigo == idCliente
                    orderby lcc.lcc_c_descricao ascending
                    select new GenericList
                    {
                        value = lcc.lcc_n_codigo.ToString(),
                        text = lcc.lcc_c_descricao.ToUpper(),

                    }).ToList();
        }

        public bool ValidaDuplicidade(LocalidadeClienteViewModel model)
        {
            var query = (from lcc in context.tb_lcc_localidadeCliente
                         where lcc.lcc_c_tipoLocalidade == model.lcc_c_tipoLocalidade
                         && lcc.lcc_c_descricao == model.lcc_c_descricao
                         && lcc.lcc_cli_n_codigo == Convert.ToInt32(model.lcc_cli_n_codigo)
                         && lcc.lcc_n_codigo != Convert.ToInt32(model.lcc_n_codigo)
                         select lcc).Count();

            if (query != 0)
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
