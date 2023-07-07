using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Exceptions;
using Iconnect.Infraestrutura.Models;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class ProprietarioService : RepositoryBase<tb_pro_proprietario>, IProprietarioService
    {
        private IconnectCoreContext context;
        public ProprietarioService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IAcessoService _acesso;
        public IAcessoService Acesso
        {
            get
            {
                if (_acesso == null)
                {
                    _acesso = new AcessoService(context);
                }
                return _acesso;
            }
        }
        public bool DeletarProprietario(int id)
        {
            try
            {
                int result = Context.tb_pro_proprietario.FirstOrDefault(w => w.pro_n_codigo == id).pro_ace_n_codigo.Value;
                Delete(context.tb_pro_proprietario.Find(id));
                context.SaveChanges();
                Acesso.DeletarAcesso(result);
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public ProprietarioViewModel GetProprietario(int id)
        {
            return (from pro in Context.tb_pro_proprietario
                    join cid in Context.tb_cid_cidade on pro.pro_cid_n_codigo equals cid.cid_n_codigo
                    join est in Context.tb_est_estado on pro.pro_est_n_codigo equals est.est_n_codigo
                    join ace in Context.tb_ace_acesso on pro.pro_ace_n_codigo equals ace.ace_n_codigo

                    where pro.pro_n_codigo == id
                    select new ProprietarioViewModel()
                    {
                        pro_n_codigo = pro.pro_n_codigo.ToString(),
                        pro_b_tipoGaren = pro.pro_b_tipoGaren.ToString(),
                        pro_c_nome = pro.pro_c_nome,
                        pro_c_cargo = pro.pro_c_cargo,
                        pro_c_cpf = pro.pro_c_cpf,
                        pro_c_telefone = pro.pro_c_telefone,
                        pro_c_celular = pro.pro_c_celular,
                        pro_c_email = pro.pro_c_email,
                        pro_c_email2 = pro.pro_c_email2,
                        pro_c_cep = pro.pro_c_cep,
                        pro_d_dataNascimento = pro.pro_d_dataNascimento != null ? Convert.ToDateTime(pro.pro_d_dataNascimento).ToString("yyyy-MM-dd") : "",
                        pro_c_rg = pro.pro_c_rg,
                        pro_c_rua = pro.pro_c_rua,
                        pro_c_numero = pro.pro_c_numero,
                        pro_c_complemento = pro.pro_c_complemento,
                        pro_c_bairro = pro.pro_c_bairro,
                        pro_c_observacao = pro.pro_c_observacao,
                        pro_est_n_codigo = pro.pro_est_n_codigo.ToString(),
                        pro_cid_n_codigo = pro.pro_cid_n_codigo.ToString(),
                        pro_ace_n_codigo = pro.pro_ace_n_codigo.ToString(),
                        pro_ace_login = ace.ace_c_login,
                    }).FirstOrDefault();
        }

        public IPagedList<ProprietarioViewModel> GetProprietarioFiltrado(ProprietarioFilterModel filter)
        {
            var query = from prop in Context.tb_pro_proprietario
                        join cid in Context.tb_cid_cidade on prop.pro_cid_n_codigo equals cid.cid_n_codigo
                        join est in Context.tb_est_estado on prop.pro_est_n_codigo equals est.est_n_codigo
                        orderby prop.pro_c_nome
                        select new ProprietarioViewModel
                        {
                            pro_n_codigo = prop.pro_n_codigo.ToString(),
                            pro_c_nome = prop.pro_c_nome,
                            pro_c_cpf = prop.pro_c_cpf,
                            pro_c_telefone = prop.pro_c_telefone,
                            pro_c_celular = prop.pro_c_celular,
                            pro_c_email = prop.pro_c_email,
                            pro_est_n_codigo = prop.pro_est_n_codigo.ToString(),
                            pro_nomeEstado = est.est_c_descricao,
                            pro_nomeCidade = cid.cid_c_nome,
                            buscaSimples = prop.pro_c_nome,
                        };

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.pro_c_nome_filter))
            {
                query = query.Where(w => w.pro_c_nome.Contains(filter.pro_c_nome_filter));
            }

            if (!string.IsNullOrEmpty(filter.pro_c_cpf_filter))
            {
                query = query.Where(w => w.pro_c_cpf.Contains(filter.pro_c_cpf_filter));
            }

            if (!string.IsNullOrEmpty(filter.pro_c_telefone_filter))
            {
                filter.pro_c_telefone_filter = filter.pro_c_telefone_filter.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                query = query.Where(w => w.pro_c_telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "").Contains(filter.pro_c_telefone_filter));
            }

            if (!string.IsNullOrEmpty(filter.pro_c_celular_filter))
            {
                filter.pro_c_celular_filter = filter.pro_c_celular_filter.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                query = query.Where(w => w.pro_c_celular.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "").Contains(filter.pro_c_celular_filter));
            }

            if (!string.IsNullOrEmpty(filter.pro_c_email_filter))
            {
                query = query.Where(w => w.pro_c_email.Contains(filter.pro_c_email_filter));
            }

            if (!string.IsNullOrEmpty(filter.pro_nomeEstado_filter))
            {
                query = query.Where(w => w.pro_nomeEstado.Contains(filter.pro_nomeEstado_filter));
            }

            if (!string.IsNullOrEmpty(filter.pro_nomeCidade_filter))
            {
                filter.pro_nomeCidade_filter = RemoveDiacritics(filter.pro_nomeCidade_filter);
                query = query.Where(w => w.pro_nomeCidade.Contains(filter.pro_nomeCidade_filter));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public List<ProprietarioViewModel> GetProprietarios()
        {
            throw new NotImplementedException();
        }

        public int SalvarProprietario(ProprietarioViewModel model)
        {
            VerificaDuplicado(model);

            DateTime? dataNascimento = null;

            if (model.pro_d_dataNascimento != "")
            {
                dataNascimento = Convert.ToDateTime(model.pro_d_dataNascimento);
            }

            tb_pro_proprietario proprietario;
            if (model.pro_n_codigo == null || model.pro_n_codigo == "")
            {
                Insert(proprietario = new tb_pro_proprietario()
                {
                    pro_b_tipoGaren = true, /*REGRA FOI APLICADA PARA APPS 'ICONNEC/GAREN'  POREN NÃO VAMOS APLICA-LA MAIS, POREM VAMOS MANTER SALVANDO COMO TIPO GAREN SIM*/
                    pro_ace_n_codigo = Convert.ToInt32(model.pro_ace_n_codigo),
                    pro_c_nome = model.pro_c_nome,
                    pro_c_cargo = model.pro_c_cargo,
                    pro_d_dataNascimento = !string.IsNullOrEmpty(model.pro_d_dataNascimento) ? Convert.ToDateTime(model.pro_d_dataNascimento) : new DateTime?(),
                    pro_c_rg = model.pro_c_rg,
                    pro_c_cpf = model.pro_c_cpf,
                    pro_c_telefone = model.pro_c_telefone,
                    pro_c_celular = model.pro_c_celular,
                    pro_c_email = model.pro_c_email,
                    pro_c_email2 = model.pro_c_email2,
                    pro_c_cep = model.pro_c_cep,
                    pro_c_rua = model.pro_c_rua,
                    pro_c_numero = model.pro_c_numero,
                    pro_c_complemento = model.pro_c_complemento,
                    pro_c_bairro = model.pro_c_bairro,
                    pro_c_observacao = model.pro_c_observacao,
                    pro_est_n_codigo = Convert.ToInt32(model.pro_est_n_codigo),
                    pro_cid_n_codigo = Convert.ToInt32(model.pro_cid_n_codigo),
                    pro_d_atualizado = DateTime.Now,
                    pro_c_unique = Guid.NewGuid(),
                    pro_d_inclusao = DateTime.Now,
                });
            }
            else
            {
                proprietario = (from pro in context.tb_pro_proprietario where pro.pro_n_codigo == Convert.ToInt32(model.pro_n_codigo) select pro).FirstOrDefault();

                if (proprietario == null) throw new MensagemException("Proprietário não encontrado.");

                proprietario.pro_b_tipoGaren = model.pro_b_tipoGaren != "" ? Convert.ToBoolean(model.pro_b_tipoGaren) : true;
                proprietario.pro_ace_n_codigo = Convert.ToInt32(model.pro_ace_n_codigo);
                proprietario.pro_c_nome = model.pro_c_nome;
                proprietario.pro_c_cargo = model.pro_c_cargo;
                proprietario.pro_d_dataNascimento = dataNascimento;
                proprietario.pro_c_rg = model.pro_c_rg;
                proprietario.pro_c_cpf = model.pro_c_cpf;
                proprietario.pro_c_telefone = model.pro_c_telefone;
                proprietario.pro_c_celular = model.pro_c_celular;
                proprietario.pro_c_email = model.pro_c_email;
                proprietario.pro_c_email2 = model.pro_c_email2;
                proprietario.pro_c_cep = model.pro_c_cep;
                proprietario.pro_c_rua = model.pro_c_rua;
                proprietario.pro_c_numero = model.pro_c_numero;
                proprietario.pro_c_complemento = model.pro_c_complemento;
                proprietario.pro_c_bairro = model.pro_c_bairro;
                proprietario.pro_c_observacao = model.pro_c_observacao;
                proprietario.pro_est_n_codigo = Convert.ToInt32(model.pro_est_n_codigo);
                proprietario.pro_cid_n_codigo = Convert.ToInt32(model.pro_cid_n_codigo);
                proprietario.pro_d_atualizado = DateTime.Now;
                Update(proprietario);
            }

            context.SaveChanges();

            return proprietario.pro_n_codigo;
        }

        public void VerificaDuplicado(ProprietarioViewModel model)
        {
            if (!string.IsNullOrEmpty(model.pro_c_rg))
            {
                int result = Context.tb_pro_proprietario.Where(x => x.pro_n_codigo != Convert.ToInt32(model.pro_n_codigo) && x.pro_c_cpf.Equals(model.pro_c_cpf)).Count();

                if (result > 0)
                    throw new MensagemException("O CPF digitado ja está sendo usado, verifque novamente ou contate o Administrador.");
            }
            if (!string.IsNullOrEmpty(model.pro_c_rg))
            {
                int result = Context.tb_pro_proprietario.Where(x => x.pro_n_codigo != Convert.ToInt32(model.pro_n_codigo) && x.pro_c_rg.Equals(model.pro_c_rg)).Count();

                if (result > 0)
                    throw new MensagemException("O RG digitado ja está sendo usado, verifque novamente ou contate o Administrador.");
            }
            if (!string.IsNullOrEmpty(model.pro_c_email))
            {
                int result = Context.tb_pro_proprietario.Where(x => x.pro_n_codigo != Convert.ToInt32(model.pro_n_codigo) && x.pro_c_email.Equals(model.pro_c_email)).Count();
                result += Context.tb_ope_operador.Where(w => w.ope_c_email.Equals(model.pro_c_email)).Count();
                result += Context.tb_emp_empresa.Where(w => w.emp_c_email.Equals(model.pro_c_email)).Count();

                if (result > 0)
                {
                    throw new MensagemException("O E-mail digitado ja está sendo usado, verifque novamente ou contate o Administrador.");
                }
            }
        }

        public byte[] GeraExcel(ProprietarioFilterModel filter)
        {
            var query = (from prop in Context.tb_pro_proprietario
                         join cid in Context.tb_cid_cidade on prop.pro_cid_n_codigo equals cid.cid_n_codigo
                         join est in Context.tb_est_estado on prop.pro_est_n_codigo equals est.est_n_codigo
                         select new ProprietarioViewModel
                         {
                             pro_n_codigo = prop.pro_n_codigo.ToString(),

                             pro_c_nome = prop.pro_c_nome,
                             pro_c_cpf = prop.pro_c_cpf,
                             pro_c_telefone = prop.pro_c_telefone,
                             pro_c_celular = prop.pro_c_celular,
                             pro_c_email = prop.pro_c_email,
                             pro_est_n_codigo = prop.pro_est_n_codigo.ToString(),
                             pro_nomeEstado = est.est_c_descricao,
                             pro_nomeCidade = cid.cid_c_nome,
                             buscaSimples = prop.pro_c_nome,
                         });

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

            }
            if (!string.IsNullOrEmpty(filter.pro_c_nome_filter))
            {
                query = query.Where(w => w.pro_c_nome.Contains(filter.pro_c_nome_filter));
            }
            if (!string.IsNullOrEmpty(filter.pro_c_cpf_filter))
            {
                query = query.Where(w => w.pro_c_cpf.Contains(filter.pro_c_cpf_filter));
            }
            if (!string.IsNullOrEmpty(filter.pro_c_telefone_filter))
            {
                query = query.Where(w => w.pro_c_telefone.Contains(filter.pro_c_telefone_filter));
            }
            if (!string.IsNullOrEmpty(filter.pro_c_celular_filter))
            {
                query = query.Where(w => w.pro_c_celular.Contains(filter.pro_c_celular_filter));
            }
            if (!string.IsNullOrEmpty(filter.pro_c_email_filter))
            {
                query = query.Where(w => w.pro_c_email.Contains(filter.pro_c_email_filter));
            }
            if (!string.IsNullOrEmpty(filter.pro_nomeEstado_filter))
            {
                query = query.Where(w => w.pro_nomeEstado.Contains(filter.pro_nomeEstado_filter));
            }
            if (!string.IsNullOrEmpty(filter.pro_nomeEstado_filter))
            {
                query = query.Where(w => w.pro_nomeCidade.Contains(filter.pro_nomeCidade_filter));
            }

            var listaEmpresas = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Nome",
                    "CPF",
                    "Telefone",
                    "Celular",
                    "E-mail",
                    "UF",
                    "Cidade",
                };

                var worksheet = package.Workbook.Worksheets.Add("Operador");
                using (var cells = worksheet.Cells[1, 1, 1, columHeaders.Count()])
                {
                    cells.Style.Font.Bold = true;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].Value = columHeaders[i];
                }

                var j = 2;

                try
                {
                    foreach (var empresa in listaEmpresas)
                    {
                        worksheet.Cells["A" + j].Value = empresa.pro_n_codigo;
                        worksheet.Cells["B" + j].Value = empresa.pro_c_nome;
                        worksheet.Cells["C" + j].Value = empresa.pro_c_cpf;
                        worksheet.Cells["D" + j].Value = empresa.pro_c_telefone;
                        worksheet.Cells["E" + j].Value = empresa.pro_c_celular;
                        worksheet.Cells["F" + j].Value = empresa.pro_c_email;
                        worksheet.Cells["G" + j].Value = empresa.pro_nomeEstado;
                        worksheet.Cells["H" + j].Value = empresa.pro_nomeCidade;
                        j++;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].AutoFitColumns();
                }

                return package.GetAsByteArray();
            }

        }

        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
