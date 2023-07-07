using Iconnect.Aplicacao.FilterModel;
using System.Collections.Generic;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using System;
using OfficeOpenXml;

namespace Iconnect.Aplicacao.Services
{
    class DistribuidorService : RepositoryBase<tb_dis_distribuidor>, IDistribuidorService
    {
        private IconnectCoreContext context;

        public DistribuidorService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IAcessoService _acessoService;
        public IAcessoService AcessoService
        {
            get
            {
                if (_acessoService == null)
                {
                    _acessoService = new AcessoService(context);
                }
                return _acessoService;
            }
        }

        public object InsertOrUpdate(DistribuidorViewModel model)
        {
            Retorno retorno = new Retorno();
            try
            {
                if (model == null) throw new Exception();

                string dataInclusao = model.dis_d_inclusao;
                if (!string.IsNullOrEmpty(model.dis_d_inclusao))
                {
                    var dataSplit = model.dis_d_inclusao.Split("/");
                    if (dataSplit.Length == 3)
                    {
                        dataInclusao = $"{dataSplit[2]}/{dataSplit[1]}/{dataSplit[0]}";
                    }
                }
                DateTime.TryParse(dataInclusao, out DateTime _dataInclusao);

                var distribuidor = new tb_dis_distribuidor();

                if (model.dis_n_codigo == null || model.dis_n_codigo == "")
                {
                    string result = VerificaDuplicado(model.dis_c_cnpj, model.dis_c_email);

                    if (result != "")
                    {
                        retorno.status = "error";
                        retorno.conteudo = result;
                        return retorno;
                    }

                    {
                        //emp_b_tipoGaren = Convert.ToBoolean(model.emp_b_tipoGaren),
                        distribuidor.dis_c_razaoSocial = model.dis_c_razaoSocial;
                        distribuidor.dis_c_nomeFantasia = model.dis_c_nomeFantasia;
                        distribuidor.dis_c_cnpj = model.dis_c_cnpj;
                        distribuidor.dis_c_ie = model.dis_c_ie;
                        distribuidor.dis_c_pessoaContato = model.dis_c_pessoaContato;
                        distribuidor.dis_c_email = model.dis_c_email;
                        distribuidor.dis_c_email2 = model.dis_c_email2;
                        distribuidor.dis_c_foneComercial = model.dis_c_foneComercial;
                        distribuidor.dis_c_foneComercial2 = model.dis_c_foneComercial2;
                        distribuidor.dis_c_celular = model.dis_c_celular;
                        distribuidor.dis_c_celular2 = model.dis_c_celular2;
                        distribuidor.dis_c_cep = model.dis_c_cep;
                        distribuidor.dis_c_rua = model.dis_c_rua;
                        distribuidor.dis_c_numero = model.dis_c_numero;
                        distribuidor.dis_c_complemento = model.dis_c_complemento;
                        distribuidor.dis_c_bairro = model.dis_c_bairro;
                        distribuidor.dis_c_observacao = model.dis_c_observacao;
                        distribuidor.dis_est_n_codigo = Convert.ToInt32(model.dis_est_n_codigo);
                        distribuidor.dis_cid_n_codigo = Convert.ToInt32(model.dis_cid_n_codigo);
                        distribuidor.dis_d_atualizado = DateTime.Now;
                        distribuidor.dis_c_unique = Guid.NewGuid();
                        distribuidor.dis_d_inclusao = DateTime.Now;
                    };
                    Insert(distribuidor);
                    context.SaveChanges();

                    AcessoService.VincularAcessoADistribuidor(distribuidor.dis_n_codigo);
                }
                else
                {
                    distribuidor = (from dis in context.tb_dis_distribuidor
                                    where dis.dis_n_codigo == Convert.ToInt32(model.dis_n_codigo)
                                    select dis).FirstOrDefault();

                    if (model.dis_c_cnpj != distribuidor.dis_c_cnpj)
                    {
                        string result = VerificaDuplicado(model.dis_c_cnpj, model.dis_c_email);

                        if (result != "")
                        {
                            retorno.status = "error";
                            retorno.conteudo = result;
                            return retorno;
                        }
                    }

                    //distribuidor.dis_b_tipoGaren = Convert.ToBoolean(model.dis_b_tipoGaren);
                    distribuidor.dis_c_razaoSocial = model.dis_c_razaoSocial;
                    distribuidor.dis_c_nomeFantasia = model.dis_c_nomeFantasia;
                    distribuidor.dis_c_cnpj = model.dis_c_cnpj;
                    distribuidor.dis_c_ie = model.dis_c_ie;
                    distribuidor.dis_c_pessoaContato = model.dis_c_pessoaContato;
                    distribuidor.dis_c_email = model.dis_c_email;
                    distribuidor.dis_c_email2 = model.dis_c_email2;
                    distribuidor.dis_c_pessoaContato = model.dis_c_pessoaContato;
                    distribuidor.dis_c_celular = model.dis_c_celular;
                    distribuidor.dis_c_celular2 = model.dis_c_celular2;
                    distribuidor.dis_c_cep = model.dis_c_cep;
                    distribuidor.dis_c_rua = model.dis_c_rua;
                    distribuidor.dis_c_numero = model.dis_c_numero;
                    distribuidor.dis_c_complemento = model.dis_c_complemento;
                    distribuidor.dis_c_bairro = model.dis_c_bairro;
                    distribuidor.dis_c_observacao = model.dis_c_observacao;
                    distribuidor.dis_est_n_codigo = Convert.ToInt32(model.dis_est_n_codigo);
                    distribuidor.dis_cid_n_codigo = Convert.ToInt32(model.dis_cid_n_codigo);
                    distribuidor.dis_d_atualizado = DateTime.Now;
                    distribuidor.dis_d_inclusao = DateTime.Now;
                    Update(distribuidor);
                    context.SaveChanges();
                }

                retorno.id = distribuidor.dis_n_codigo;
                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public IPagedList<DistribuidorViewModel> GetDistribuidorFiltrado(DistribuidorFilterModel filter)
        {
            var query = (from dis in context.tb_dis_distribuidor
                         join cid in context.tb_cid_cidade on dis.dis_cid_n_codigo equals cid.cid_n_codigo
                         join est in context.tb_est_estado on cid.cid_est_n_codigo equals est.est_n_codigo
                         orderby dis.dis_c_razaoSocial
                         select new DistribuidorViewModel
                         {
                             //dis_b_ativo = dis.dis_b_ativo.ToString(),
                             dis_est_n_codigo = dis.dis_est_n_codigo.ToString(),
                             dis_cid_n_codigo = dis.dis_cid_n_codigo.ToString(),
                             //dis_b_tipoGaren = dis.dis_b_tipoGaren.ToString(),
                             dis_c_bairro = dis.dis_c_bairro,
                             dis_c_celular = dis.dis_c_celular,
                             dis_c_celular2 = dis.dis_c_celular2,
                             dis_c_cep = dis.dis_c_cep,
                             dis_c_cnpj = dis.dis_c_cnpj,
                             dis_c_complemento = dis.dis_c_complemento,
                             dis_c_email = dis.dis_c_email,
                             dis_c_email2 = dis.dis_c_email2,
                             dis_c_foneComercial = dis.dis_c_foneComercial,
                             dis_c_foneComercial2 = dis.dis_c_foneComercial2,
                             Cidade = cid.cid_c_nome,
                             dis_c_ie = dis.dis_c_ie,
                             dis_c_nomeFantasia = dis.dis_c_nomeFantasia,
                             dis_c_numero = dis.dis_c_numero,
                             dis_c_observacao = dis.dis_c_observacao,
                             dis_c_pessoaContato = dis.dis_c_pessoaContato,
                             dis_c_razaoSocial = dis.dis_c_razaoSocial,
                             dis_c_rua = dis.dis_c_rua,
                             dis_c_unique = dis.dis_c_unique.ToString(),
                             dis_c_usuario = dis.dis_c_usuario,
                             dis_d_alteracao = dis.dis_d_alteracao.ToString(),
                             dis_d_atualizado = dis.dis_d_atualizado.ToString(),
                             dis_d_contrato = dis.dis_d_contrato.ToString(),
                             dis_d_inclusao = dis.dis_d_inclusao.ToString("dd/MM/yyyy"),
                             dis_n_codigo = dis.dis_n_codigo.ToString(),
                             Estado = est.est_c_descricao + "-" + est.est_c_sigla,
                             buscaSimples = dis.dis_c_nomeFantasia + " " + dis.dis_c_cnpj
                         });

            //Filtros
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.dis_c_razaoSocial_filter))
            {
                query = query.Where(w => w.dis_c_razaoSocial.Contains(filter.dis_c_razaoSocial_filter));
            }

            if (!string.IsNullOrEmpty(filter.dis_c_nomeFantasia_filter))
            {
                query = query.Where(w => w.dis_c_nomeFantasia.Contains(filter.dis_c_nomeFantasia_filter));
            }

            if (!string.IsNullOrEmpty(filter.dis_c_cnpj_filter))
            {
                query = query.Where(w => w.dis_c_cnpj.Contains(filter.dis_c_cnpj_filter));
            }

            if (!string.IsNullOrEmpty(filter.Estado_filter))
            {
                query = query.Where(w => w.Estado.Contains(filter.Estado_filter));
            }

            if (!string.IsNullOrEmpty(filter.Cidade_filter))
            {
                query = query.Where(w => w.Cidade.Contains(filter.Cidade_filter));
            }

            if (!string.IsNullOrEmpty(filter.dis_c_ie_filter))
            {
                query = query.Where(w => w.dis_c_ie.Contains(filter.dis_c_ie_filter));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool Deletar(int id)
        {
            try
            {
                Delete(context.tb_dis_distribuidor.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }


        public List<DistribuidorViewModel> GetDistribuidor()
        {
            var query = (from dis in context.tb_dis_distribuidor
                         select new DistribuidorViewModel()
                         {
                             dis_n_codigo = dis.dis_n_codigo.ToString(),
                             dis_c_nomeFantasia = dis.dis_c_nomeFantasia,
                             dis_c_razaoSocial = dis.dis_c_razaoSocial,
                         });

            return query.OrderBy(x => x.dis_c_nomeFantasia).ToList();
        }

        public DistribuidorViewModel GetDistribuidorEditar(int id)
        {
            return (from dis in context.tb_dis_distribuidor
                    join cid in context.tb_cid_cidade on dis.dis_cid_n_codigo equals cid.cid_n_codigo
                    join est in context.tb_est_estado on dis.dis_est_n_codigo equals est.est_n_codigo
                    where dis.dis_n_codigo == id
                    select new DistribuidorViewModel()
                    {
                        dis_n_codigo = dis.dis_n_codigo.ToString(),
                        //dis_b_tipoGaren = dis.dis_b_tipoGaren.ToString(),
                        dis_c_razaoSocial = dis.dis_c_razaoSocial,
                        dis_c_nomeFantasia = dis.dis_c_nomeFantasia,
                        dis_c_cnpj = dis.dis_c_cnpj,
                        dis_c_email = dis.dis_c_email,
                        dis_c_email2 = dis.dis_c_email2,
                        dis_c_cep = dis.dis_c_cep,
                        dis_d_contrato = dis.dis_d_contrato != null ? Convert.ToDateTime(dis.dis_d_contrato).ToString("dd-MM-yyyy") : "",
                        dis_d_inclusao = Convert.ToDateTime(dis.dis_d_inclusao).ToString("dd/MM/yyyy"),
                        dis_c_rua = dis.dis_c_rua,
                        dis_c_numero = dis.dis_c_numero,
                        dis_c_complemento = dis.dis_c_complemento,
                        dis_c_bairro = dis.dis_c_bairro,
                        dis_c_observacao = dis.dis_c_observacao,
                        dis_est_n_codigo = dis.dis_est_n_codigo.ToString(),
                        dis_cid_n_codigo = dis.dis_cid_n_codigo.ToString(),
                        dis_c_ie = dis.dis_c_ie,
                        dis_c_pessoaContato = dis.dis_c_pessoaContato,
                        dis_c_foneComercial = dis.dis_c_foneComercial,
                        dis_c_foneComercial2 = dis.dis_c_foneComercial2,
                        dis_c_celular = dis.dis_c_celular,
                    }).FirstOrDefault();
        }

        public string VerificaDuplicado(string cnpj, string email)
        {
            string retorno = "";

            List<tb_dis_distribuidor> listaDisCnpj = context.tb_dis_distribuidor.Where(x => x.dis_c_cnpj == cnpj).ToList();
            List<tb_dis_distribuidor> listaDisEmail = context.tb_dis_distribuidor.Where(x => x.dis_c_email == email).ToList();
            if (listaDisCnpj.Count() > 0)
            {
                retorno = "CNPJ_DUPLICADO";
                return retorno;
            }
            else if (listaDisEmail.Count() > 0)
            {
                retorno = "EMAIL_DUPLICADO";
                return retorno;
            }
            else
            {
                retorno = "";
                return retorno;
            }
        }
    }
}
