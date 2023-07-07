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
using System.Security.Cryptography;
using Iconnect.Infraestrutura.Exceptions;

namespace Iconnect.Aplicacao.Services
{
    class ResponsavelLocacaoService : RepositoryBase<tb_rel_responsavelLocacaoSaloes>, IResponsavelLocacaoService
    {
        private IconnectCoreContext context;

        public ResponsavelLocacaoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool Deletar(int id)
        {
            try
            {
                Delete(context.tb_rel_responsavelLocacaoSaloes.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ResponsavelLocacaoViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<ResponsavelLocacaoViewModel> GetFiltrado(ResponsavelLocacaoFilterModel filter)
        {
            try
            {
                var query = (from rel in Context.tb_rel_responsavelLocacaoSaloes
                             orderby rel.rel_c_nome
                             select new ResponsavelLocacaoViewModel
                             {
                                 rel_n_codigo = rel.rel_n_codigo.ToString(),
                                 rel_cli_n_codigo = rel.rel_cli_n_codigo.ToString(),
                                 rel_c_nome = rel.rel_c_nome,
                                 rel_c_rg = rel.rel_c_rg,
                                 rel_c_telefone = rel.rel_c_telefone,
                                 rel_c_permissao = rel.rel_c_permissao,
                             });

                int codCli = Convert.ToInt32(filter.rel_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.rel_cli_n_codigo.Equals(codCli.ToString()));
                }
                //else
                //{
                //    query = query.Where(w => w.rel_cli_n_codigo == null);
                //}


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ResponsavelLocacaoViewModel GetResponsavel(int id)
        {
            return (from rel in Context.tb_rel_responsavelLocacaoSaloes
                    where rel.rel_n_codigo == id

                    select new ResponsavelLocacaoViewModel
                    {
                        rel_n_codigo = rel.rel_n_codigo.ToString(),
                        rel_c_tipo = rel.rel_c_tipo,
                        rel_c_nome = rel.rel_c_nome,
                        rel_c_rg = rel.rel_c_rg,
                        rel_c_telefone = rel.rel_c_telefone,
                        rel_c_permissao = rel.rel_c_permissao,
                        rel_c_email = rel.rel_c_email,
                        rel_c_login = rel.rel_c_login,
                    }).FirstOrDefault();
        }

        public void InsertOrUpdate(ResponsavelLocacaoViewModel model)
        {
            string senhaCriptografada = "";

            if (model != null && !string.IsNullOrEmpty(model.rel_c_senha))
            {
                senhaCriptografada = CriptografarSenha(model.rel_c_senha);
            }

            int? codeCli = null;
            int codeRel = 0;


            if (model.rel_cli_n_codigo != null && model.rel_cli_n_codigo != "")
            {
                codeCli = Convert.ToInt32(model.rel_cli_n_codigo);
            }

            if (model.rel_n_codigo != null && model.rel_n_codigo != "")
            {
                codeRel = Convert.ToInt32(model.rel_n_codigo);
            }

            var tbResLoc = (from r in context.tb_rel_responsavelLocacaoSaloes where r.rel_c_login == model.rel_c_login && r.rel_n_codigo != codeRel select r).FirstOrDefault();
            var tbAcesso = context.tb_ace_acesso.Where(x => x.ace_c_login == model.rel_c_login).FirstOrDefault();
            var tbOpLocal = (from opl in context.tb_opl_operadorLocal where opl.opl_c_login == model.rel_c_login select opl)?.FirstOrDefault();

            if (tbResLoc != null || (tbAcesso != null && (model?.rel_c_origem?.Equals("NOVO") ?? false)) || (tbOpLocal != null && (model?.rel_c_origem?.Equals("NOVO") ?? false))) 
                throw new MensagemException("O login digitado está em uso.");

            if (codeRel == 0)
            {
                Insert(new tb_rel_responsavelLocacaoSaloes()
                {
                    rel_cli_n_codigo = codeCli,
                    rel_c_tipo = model.rel_c_tipo,
                    rel_c_nome = model.rel_c_nome,
                    rel_c_sobreNome = model.rel_c_sobreNome,
                    rel_c_login = model.rel_c_login,
                    rel_c_senha = senhaCriptografada,
                    rel_c_permissao = model.rel_c_permissao,
                    rel_c_rg = model.rel_c_rg,
                    rel_c_telefone = model.rel_c_telefone,
                    rel_c_email = model.rel_c_email,
                    rel_c_origem = model.rel_c_origem,
                    rel_c_unique = Guid.NewGuid(),
                    rel_d_atualizado = DateTime.Now,
                    rel_d_inclusao = DateTime.Now,
                });
            }
            else
            {
                var rel = (from responsavel in context.tb_rel_responsavelLocacaoSaloes where responsavel.rel_n_codigo == codeRel select responsavel)?.FirstOrDefault();

                if (rel == null) throw new MensagemException("Responsável locação não encontrado.");

                rel.rel_cli_n_codigo = codeCli;
                rel.rel_c_tipo = model.rel_c_tipo;
                rel.rel_c_nome = model.rel_c_nome;
                rel.rel_c_sobreNome = model.rel_c_sobreNome;
                rel.rel_c_rg = model.rel_c_rg;
                rel.rel_c_telefone = model.rel_c_telefone;
                rel.rel_c_login = model.rel_c_login;
                rel.rel_c_senha = senhaCriptografada != "" ? senhaCriptografada : rel.rel_c_senha;
                rel.rel_c_permissao = model.rel_c_permissao;
                rel.rel_c_email = model.rel_c_email;
                rel.rel_c_origem = model.rel_c_origem;
                rel.rel_usu_n_responsavel = Convert.ToInt32(model.rel_usu_n_responsavel);
                rel.rel_d_atualizado = DateTime.Now;

                Update(rel);
            }

            context.SaveChanges();
        }

        private string CriptografarSenha(string senha)
        {
            var enc = Encoding.GetEncoding(0);
            byte[] buffer = enc.GetBytes(senha);
            var sha1 = SHA1.Create();
            var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }
    }
}
