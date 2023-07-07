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
    public class EmpresaService : RepositoryBase<tb_emp_empresa>, IEmpresaService
    {
        private IconnectCoreContext context;

        public EmpresaService(IconnectCoreContext context) : base(context)
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
        private IParametrosEmpresaService _parametros;
        public IParametrosEmpresaService Parametros
        {
            get
            {
                if (_parametros == null)
                {
                    _parametros = new ParametrosEmpresaService(context);
                }
                return _parametros;
            }
        }
        public IPagedList<EmpresaViewModel> GetEmpresaFiltrado(EmpresaFilterModel filter)
        {
            var query = (from emp in Context.tb_emp_empresa
                         join cid in Context.tb_cid_cidade on emp.emp_cid_n_codigo equals cid.cid_n_codigo
                         join est in Context.tb_est_estado on cid.cid_est_n_codigo equals est.est_n_codigo
                         orderby emp.emp_c_razaoSocial
                         select new EmpresaViewModel
                         {
                             emp_b_ativo = emp.emp_b_ativo.ToString(),
                             emp_est_n_codigo = emp.emp_est_n_codigo.ToString(),
                             emp_cid_n_codigo = emp.emp_cid_n_codigo.ToString(),
                             emp_b_tipoGaren = emp.emp_b_tipoGaren.ToString(),
                             emp_c_bairro = emp.emp_c_bairro,
                             emp_c_celular = emp.emp_c_celular,
                             emp_c_celular2 = emp.emp_c_celular2,
                             emp_c_cep = emp.emp_c_cep,
                             emp_c_cnpj = emp.emp_c_cnpj,
                             emp_c_complemento = emp.emp_c_complemento,
                             emp_c_contatoEmail1 = emp.emp_c_contatoEmail1,
                             emp_c_contatoEmail2 = emp.emp_c_contatoEmail2,
                             emp_c_contatoNome1 = emp.emp_c_contatoNome1,
                             emp_c_contatoNome2 = emp.emp_c_contatoNome2,
                             emp_c_contatoTelefone1 = emp.emp_c_contatoTelefone1,
                             emp_c_contatoTelefone2 = emp.emp_c_contatoTelefone2,
                             emp_c_email = emp.emp_c_email,
                             emp_c_email2 = emp.emp_c_email2,
                             emp_c_foneComercial = emp.emp_c_foneComercial,
                             emp_c_foneComercial2 = emp.emp_c_foneComercial2,
                             Cidade = cid.cid_c_nome,
                             emp_c_ie = emp.emp_c_ie,
                             emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                             emp_c_numero = emp.emp_c_numero,
                             emp_c_observacao = emp.emp_c_observacao,
                             emp_c_pessoaContato = emp.emp_c_pessoaContato,
                             emp_c_ramais = emp.emp_c_ramais,
                             emp_c_RangePortas = emp.emp_c_RangePortas,
                             emp_c_RangeRamais = emp.emp_c_RangeRamais,
                             emp_c_razaoSocial = emp.emp_c_razaoSocial,
                             emp_c_rua = emp.emp_c_rua,
                             emp_c_unique = emp.emp_c_unique.ToString(),
                             emp_c_usuario = emp.emp_c_usuario,
                             emp_d_alteracao = emp.emp_d_alteracao.ToString(),
                             emp_d_atualizado = emp.emp_d_atualizado.ToString(),
                             emp_d_contrato = emp.emp_d_contrato.ToString(),
                             emp_d_inclusao = emp.emp_d_inclusao.ToString("dd/MM/yyyy"),
                             emp_d_modificacao = emp.emp_d_modificacao.ToString(),
                             emp_fem_n_codigo = emp.emp_fem_n_codigo.ToString(),
                             emp_mol_n_codigo = emp.emp_mol_n_codigo.ToString(),
                             emp_n_codigo = emp.emp_n_codigo.ToString(),
                             Estado = est.est_c_descricao + "-" + est.est_c_sigla,
                             buscaSimples = emp.emp_c_nomeFantasia + " " + emp.emp_c_cnpj,
                             emp_dis_n_codigo = emp.emp_dis_n_codigo.ToString()
                         });

            //Filtros
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_c_razaoSocial_filter))
            {
                query = query.Where(w => w.emp_c_razaoSocial.Contains(filter.emp_c_razaoSocial_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_c_nomeFantasia_filter))
            {
                query = query.Where(w => w.emp_c_nomeFantasia.Contains(filter.emp_c_nomeFantasia_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_c_cnpj_filter))
            {
                query = query.Where(w => w.emp_c_cnpj.Contains(filter.emp_c_cnpj_filter));
            }

            if (!string.IsNullOrEmpty(filter.Estado_filter))
            {
                query = query.Where(w => w.Estado.Contains(filter.Estado_filter));
            }

            if (!string.IsNullOrEmpty(filter.Cidade_filter))
            {
                query = query.Where(w => w.Cidade.Contains(filter.Cidade_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_c_ie_filter))
            {
                filter.emp_c_ie_filter = filter.emp_c_ie_filter.Replace(".", "");
                query = query.Where(w => w.emp_c_ie.Replace(".", "").Contains(filter.emp_c_ie_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_c_razaoSocial_filter))
            {
                query = query.Where(w => w.emp_c_razaoSocial.Contains(filter.emp_c_razaoSocial_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_dis_n_codigo_filter))
            {
                query = query.Where(w => w.emp_dis_n_codigo.Contains(filter.emp_dis_n_codigo_filter.ToString()));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public List<EmpresaViewModel> GetEmpresas()
        {
            return (from emp in context.tb_emp_empresa
                    select new EmpresaViewModel()
                    {
                        emp_n_codigo = emp.emp_n_codigo.ToString(),
                        emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                        emp_c_razaoSocial = emp.emp_c_razaoSocial,
                        emp_dis_n_codigo = emp.emp_dis_n_codigo.ToString(),
                    }).OrderBy(x => x.emp_c_nomeFantasia).ToList();
        }

        public object InsertOrUpdate(EmpresaViewModel model)
        {
            Retorno retorno = new Retorno();
            try
            {
                if (model == null) throw new Exception();

                string result = VerificaDuplicado(model);
                int? codFem = null;
                if (!string.IsNullOrEmpty(model?.emp_fem_n_codigo) && !model.emp_fem_n_codigo.Equals("0"))
                {
                    codFem = Convert.ToInt32(model.emp_fem_n_codigo);
                }

                if (result != "")
                {
                    retorno.status = "error";
                    retorno.conteudo = result;
                    return retorno;
                }
                string dataInclusao = model.emp_d_inclusao;
                if (!string.IsNullOrEmpty(model.emp_d_inclusao))
                {
                    var dataSplit = model.emp_d_inclusao.Split("/");
                    if (dataSplit.Length == 3)
                    {
                        dataInclusao = $"{dataSplit[2]}/{dataSplit[1]}/{dataSplit[0]}";
                    }
                }
                DateTime.TryParse(dataInclusao, out DateTime _dataInclusao);

                var _empresa = new tb_emp_empresa();

                if (model.emp_n_codigo == null || model.emp_n_codigo == "")
                {
                    _empresa = new tb_emp_empresa()
                    {
                        emp_b_tipoGaren = Convert.ToBoolean(model.emp_b_tipoGaren),
                        emp_mol_n_codigo = Convert.ToInt32(model.Modulo.mol_n_codigo),
                        emp_c_razaoSocial = model.emp_c_razaoSocial,
                        emp_c_nomeFantasia = model.emp_c_nomeFantasia,
                        emp_c_cnpj = model.emp_c_cnpj,
                        emp_c_ie = model.emp_c_ie,
                        emp_c_pessoaContato = model.emp_c_pessoaContato,
                        emp_c_email = model.emp_c_email,
                        emp_c_email2 = model.emp_c_email2,
                        emp_c_foneComercial = model.emp_c_foneComercial,
                        emp_c_foneComercial2 = model.emp_c_foneComercial2,
                        emp_c_celular = model.emp_c_celular,
                        emp_c_celular2 = model.emp_c_celular2,
                        emp_c_cep = model.emp_c_cep,
                        emp_c_rua = model.emp_c_rua,
                        emp_c_numero = model.emp_c_numero,
                        emp_c_complemento = model.emp_c_complemento,
                        emp_c_bairro = model.emp_c_bairro,
                        emp_c_observacao = model.emp_c_observacao,
                        emp_c_RangeRamais = model.emp_c_RangeRamais,
                        emp_c_ramais = model.emp_c_ramais,
                        emp_c_RangePortas = model.emp_c_RangePortas,
                        emp_fem_n_codigo = codFem,
                        emp_c_contatoNome1 = model.emp_c_contatoNome1,
                        emp_c_contatoTelefone1 = model.emp_c_contatoTelefone1,
                        emp_c_contatoEmail1 = model.emp_c_contatoEmail1,
                        emp_c_contatoNome2 = model.emp_c_contatoNome1,
                        emp_c_contatoTelefone2 = model.emp_c_contatoTelefone1,
                        emp_c_contatoEmail2 = model.emp_c_contatoEmail1,
                        emp_est_n_codigo = Convert.ToInt32(model.emp_est_n_codigo),
                        emp_cid_n_codigo = Convert.ToInt32(model.emp_cid_n_codigo),
                        emp_d_atualizado = DateTime.Now,
                        emp_c_unique = Guid.NewGuid(),
                        emp_d_inclusao = DateTime.Now,
                        emp_dis_n_codigo = Convert.ToInt32(model.emp_dis_n_codigo),
                    };
                    Insert(_empresa);
                    context.SaveChanges();

                    AcessoService.VincularAcessoAEmpresa(_empresa.emp_n_codigo);
                    InsereParametrosEmpresa(_empresa);
                }
                else
                {
                    _empresa = (from empresa in context.tb_emp_empresa
                                where empresa.emp_n_codigo == Convert.ToInt32(model.emp_n_codigo)
                                select empresa).FirstOrDefault();

                    _empresa.emp_b_tipoGaren = Convert.ToBoolean(model.emp_b_tipoGaren);
                    _empresa.emp_mol_n_codigo = Convert.ToInt32(model.Modulo.mol_n_codigo);
                    _empresa.emp_c_razaoSocial = model.emp_c_razaoSocial;
                    _empresa.emp_c_nomeFantasia = model.emp_c_nomeFantasia;
                    _empresa.emp_c_cnpj = model.emp_c_cnpj;
                    _empresa.emp_c_ie = model.emp_c_ie;
                    _empresa.emp_c_pessoaContato = model.emp_c_pessoaContato;
                    _empresa.emp_c_email = model.emp_c_email;
                    _empresa.emp_c_email2 = model.emp_c_email2;
                    _empresa.emp_c_pessoaContato = model.emp_c_pessoaContato;
                    _empresa.emp_c_celular = model.emp_c_celular;
                    _empresa.emp_c_celular2 = model.emp_c_celular2;
                    _empresa.emp_c_cep = model.emp_c_cep;
                    _empresa.emp_c_rua = model.emp_c_rua;
                    _empresa.emp_c_numero = model.emp_c_numero;
                    _empresa.emp_c_complemento = model.emp_c_complemento;
                    _empresa.emp_c_bairro = model.emp_c_bairro;
                    _empresa.emp_c_observacao = model.emp_c_observacao;
                    _empresa.emp_c_RangeRamais = model.emp_c_RangeRamais;
                    _empresa.emp_c_ramais = model.emp_c_ramais;
                    _empresa.emp_c_RangePortas = model.emp_c_RangePortas;
                    _empresa.emp_fem_n_codigo = codFem;
                    _empresa.emp_c_contatoNome1 = model.emp_c_contatoNome1;
                    _empresa.emp_c_contatoTelefone1 = model.emp_c_contatoTelefone1;
                    _empresa.emp_c_contatoEmail1 = model.emp_c_contatoEmail1;
                    _empresa.emp_c_contatoNome2 = model.emp_c_contatoNome2;
                    _empresa.emp_c_contatoTelefone2 = model.emp_c_contatoTelefone2;
                    _empresa.emp_c_contatoEmail2 = model.emp_c_contatoEmail2;
                    _empresa.emp_d_inclusao = DateTime.Now;

                    _empresa.emp_est_n_codigo = Convert.ToInt32(model.emp_est_n_codigo);
                    _empresa.emp_cid_n_codigo = Convert.ToInt32(model.emp_cid_n_codigo);
                    _empresa.emp_d_atualizado = DateTime.Now;
                    _empresa.emp_dis_n_codigo = Convert.ToInt32(model.emp_dis_n_codigo);
                    Update(_empresa);
                    context.SaveChanges();

                    InsereParametrosEmpresa(_empresa);
                }

                retorno.id = _empresa.emp_n_codigo;
                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void InsereParametrosEmpresa(tb_emp_empresa empresa)
        {
            try
            {
                ParametrosEmpresaViewModel tbParametro = new ParametrosEmpresaViewModel();
                tbParametro.par_emp_n_codigo = empresa.emp_n_codigo;
                tbParametro.par_c_chave = "DESTINATARIO_CLIENTE";
                tbParametro.par_c_descricao = "DESTINATÁRIO(S) E-MAIL";
                tbParametro.par_c_aba = "email";
                tbParametro.par_c_valor = empresa.emp_c_email;
                tbParametro.par_d_modificacao = DateTime.Now;
                Parametros.InsertOrUpdate(tbParametro);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public EmpresaViewModel GetEmpresa(int id)
        {
            return (from emp in Context.tb_emp_empresa
                    join cid in Context.tb_cid_cidade on emp.emp_cid_n_codigo equals cid.cid_n_codigo
                    join est in Context.tb_est_estado on emp.emp_est_n_codigo equals est.est_n_codigo
                    join mol in Context.tb_mol_modulosLiberados on emp.emp_mol_n_codigo equals mol.mol_n_codigo

                    where emp.emp_n_codigo == id
                    select new EmpresaViewModel()
                    {
                        emp_n_codigo = emp.emp_n_codigo.ToString(),
                        emp_b_tipoGaren = emp.emp_b_tipoGaren.ToString(),
                        emp_c_razaoSocial = emp.emp_c_razaoSocial,
                        emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                        emp_c_cnpj = emp.emp_c_cnpj,
                        emp_fem_n_codigo = emp.emp_fem_n_codigo.ToString(),
                        emp_c_contatoNome1 = emp.emp_c_contatoNome1,
                        emp_c_contatoTelefone1 = emp.emp_c_contatoTelefone1,
                        emp_c_contatoEmail1 = emp.emp_c_contatoEmail1,
                        emp_c_contatoNome2 = emp.emp_c_contatoNome2,
                        emp_c_contatoTelefone2 = emp.emp_c_contatoTelefone2,
                        emp_c_contatoEmail2 = emp.emp_c_contatoEmail2,
                        emp_c_email = emp.emp_c_email,
                        emp_c_email2 = emp.emp_c_email2,
                        emp_c_cep = emp.emp_c_cep,
                        emp_d_contrato = emp.emp_d_contrato != null ? Convert.ToDateTime(emp.emp_d_contrato).ToString("dd-MM-yyyy") : "",
                        emp_d_inclusao = Convert.ToDateTime(emp.emp_d_inclusao).ToString("dd/MM/yyyy"),
                        emp_c_rua = emp.emp_c_rua,
                        emp_c_numero = emp.emp_c_numero,
                        emp_c_complemento = emp.emp_c_complemento,
                        emp_c_bairro = emp.emp_c_bairro,
                        emp_c_observacao = emp.emp_c_observacao,
                        emp_est_n_codigo = emp.emp_est_n_codigo.ToString(),
                        emp_cid_n_codigo = emp.emp_cid_n_codigo.ToString(),
                        emp_c_ie = emp.emp_c_ie,
                        emp_c_pessoaContato = emp.emp_c_pessoaContato,
                        emp_c_foneComercial = emp.emp_c_foneComercial,
                        emp_c_foneComercial2 = emp.emp_c_foneComercial2,
                        emp_c_celular = emp.emp_c_celular,
                        emp_c_RangeRamais = emp.emp_c_RangeRamais,
                        emp_c_ramais = emp.emp_c_ramais,
                        emp_c_RangePortas = emp.emp_c_RangePortas,
                        emp_mol_n_codigo = emp.emp_mol_n_codigo.ToString(),
                        emp_mol_connectSolutions = mol.mol_b_connectSolutions.ToString(),
                        emp_mol_connectWork = mol.mol_b_OrdemServico.ToString(),
                        emp_mol_connectAccess = mol.mol_b_controleDeAcesso.ToString(),
                        emp_mol_connectGuard = mol.mol_b_MonitoriamentoPerimetral.ToString(),
                        emp_mol_connectView = mol.mol_b_CFTV.ToString(),
                        emp_mol_connectSync = mol.mol_b_connectSync.ToString(),
                        emp_mol_connectPro = mol.mol_b_connectPRO.ToString(),
                        emp_mol_connectViewAccess = mol.mol_b_accessView.ToString(),
                        emp_dis_n_codigo = emp.emp_dis_n_codigo.ToString(),
                    }).FirstOrDefault();
        }

        public string VerificaDuplicado(EmpresaViewModel model)
        {
            string retorno = "";

            var queryEmp = from emp in Context.tb_emp_empresa
                           where emp.emp_n_codigo != Convert.ToInt32(model.emp_n_codigo)
                           select new EmpresaViewModel
                           {
                               emp_n_codigo = emp.emp_n_codigo.ToString(),
                               emp_c_cnpj = emp.emp_c_cnpj,
                               emp_c_email = emp.emp_c_email
                           };

            var queryOpe = from ope in Context.tb_ope_operador
                           select new OperadorViewModel
                           {
                               ope_c_email = ope.ope_c_email
                           };

            var queryPro = from pro in Context.tb_pro_proprietario
                           select new ProprietarioViewModel
                           {
                               pro_c_email = pro.pro_c_email
                           };

            if (!string.IsNullOrEmpty(model.emp_c_cnpj))
            {
                int result = queryEmp.Where(w => w.emp_c_cnpj.Equals(model.emp_c_cnpj)).Count();
                if (result > 0)
                {
                    retorno = "CNPJ_DUPLICADO";
                    return retorno;
                }
            }

            if (!string.IsNullOrEmpty(model.emp_c_email))
            {
                int result = queryEmp.Where(w => w.emp_c_email.Equals(model.emp_c_email)).Count();
                result += queryOpe.Where(w => w.ope_c_email.Equals(model.emp_c_email)).Count();
                result += queryPro.Where(w => w.pro_c_email.Equals(model.emp_c_email)).Count();

                if (result > 0)
                {
                    retorno = "EMAIL_DUPLICADO";
                    return retorno;

                }
            }
            string range_ramais = model.emp_c_RangeRamais;
            string range_ramais_invalidos = "";


            if (model.emp_c_ramais != null && model.emp_c_ramais != "")
            {
                string range_valores_inseridos = model.emp_c_ramais;
                int Range1 = Convert.ToInt32(model.emp_c_RangeRamais.Split('-')[0]);
                int Range2 = Convert.ToInt32(model.emp_c_RangeRamais.Split('-')[1]);

                foreach (var item in queryEmp)
                {
                    int Range1Temp = Convert.ToInt32(!string.IsNullOrEmpty(item.emp_c_RangeRamais) ? item.emp_c_RangeRamais.Split('-')[0] : "0");
                    int Range2Temp = Convert.ToInt32(!string.IsNullOrEmpty(item.emp_c_RangeRamais) ? item.emp_c_RangeRamais.Split('-')[1] : "0");
                    if ((Range1 >= Range1Temp && Range1 <= Range2Temp) || (Range2 >= Range1Temp && Range2 <= Range2Temp))
                    {
                        retorno = "rangeRamasDuplicado";
                        return retorno;
                    }
                }

                range_ramais_invalidos = validaRangeRamais(range_ramais, range_valores_inseridos);
                if (range_ramais_invalidos != "")
                {
                    retorno = "ramaisInvalidos";
                    return retorno;
                }
            }

            return retorno;
        }

        private string validaRangeRamais(string range_ramais, string range_valores_inseridos)
        {
            string retorno = "";

            string[] intervalo = range_ramais.Split('-');
            string ramais_invalidos = "";
            foreach (var item in range_valores_inseridos.Split(','))
            {
                if (!(Convert.ToInt32(item) >= Convert.ToInt32(intervalo[0]) && Convert.ToInt32(item) <= Convert.ToInt32(intervalo[1])))
                {
                    ramais_invalidos += item + ",";
                }
            }
            if (ramais_invalidos != "")
            {
                retorno = ramais_invalidos.Substring(0, ramais_invalidos.Length - 1);
            }
            return retorno;
        }

        public bool DeletarEmpresa(int id)
        {
            try
            {
                Delete(context.tb_emp_empresa.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public List<EmpresaViewModel> GetRelEmpresa(DistribuidorViewModel model)
        {
            var query = (from emp in context.tb_emp_empresa
                         join cid in Context.tb_cid_cidade on emp.emp_cid_n_codigo equals cid.cid_n_codigo
                         join est in Context.tb_est_estado on emp.emp_est_n_codigo equals est.est_n_codigo
                         select new EmpresaViewModel()
                         {
                             emp_n_codigo = emp.emp_n_codigo.ToString(),
                             emp_c_nomeFantasia = emp.emp_c_nomeFantasia.ToUpper(),
                             emp_c_cnpj = emp.emp_c_cnpj,
                             Cidade = cid.cid_c_nome.ToUpper() + " - " + est.est_c_sigla.ToUpper(),
                             count_cliente = emp.tb_cli_cliente.Count().ToString(),
                             emp_dis_n_codigo = string.IsNullOrEmpty(emp.emp_dis_n_codigo.ToString()) ? "0" : emp.emp_dis_n_codigo.ToString()
                         }).ToList();

            var lista = new List<string>();
            if (model.listaIdsDist != null && model.listaIdsDist.Count() > 0)
            {
                foreach (var item in model.listaIdsDist)
                {
                    lista.Add(item);
                }

                query = query.Where(x => lista.Contains(x.emp_dis_n_codigo)).ToList();
            }

            return query;
        }

        public List<EmpresaViewModel> getEmpresaCnpj(EmpresaViewModel model)
        {
            /*
                Esses 'joins' não estavam trazendo registros, verificar se são necessários
                    join cli in Context.tb_cli_cliente on emp.emp_n_codigo equals cli.cli_n_codigo
                    join cid in Context.tb_cid_cidade on cli.cli_cid_n_codigo equals cid.cid_n_codigo
                    join est in Context.tb_est_estado on cli.cli_est_n_codigo equals est.est_n_codigo
             */
            var query = (from emp in context.tb_emp_empresa
                         where emp.emp_c_cnpj == model.emp_c_cnpj
                         select new EmpresaViewModel()
                         {
                             emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                             emp_n_codigo = emp.emp_n_codigo.ToString()
                         }).ToList();
            return query;
        }

        public byte[] GeraExcel(EmpresaFilterModel filter)
        {
            var query = (from emp in Context.tb_emp_empresa
                         join cid in Context.tb_cid_cidade on emp.emp_cid_n_codigo equals cid.cid_n_codigo
                         join est in Context.tb_est_estado on cid.cid_est_n_codigo equals est.est_n_codigo
                         select new EmpresaViewModel
                         {
                             emp_b_ativo = emp.emp_b_ativo.ToString(),
                             emp_est_n_codigo = emp.emp_est_n_codigo.ToString(),
                             emp_cid_n_codigo = emp.emp_cid_n_codigo.ToString(),
                             emp_b_tipoGaren = emp.emp_b_tipoGaren.ToString(),
                             emp_c_bairro = emp.emp_c_bairro,
                             emp_c_celular = emp.emp_c_celular,
                             emp_c_celular2 = emp.emp_c_celular2,
                             emp_c_cep = emp.emp_c_cep,
                             emp_c_cnpj = emp.emp_c_cnpj,
                             emp_c_complemento = emp.emp_c_complemento,
                             emp_c_contatoEmail1 = emp.emp_c_contatoEmail1,
                             emp_c_contatoEmail2 = emp.emp_c_contatoEmail2,
                             emp_c_contatoNome1 = emp.emp_c_contatoNome1,
                             emp_c_contatoNome2 = emp.emp_c_contatoNome2,
                             emp_c_contatoTelefone1 = emp.emp_c_contatoTelefone1,
                             emp_c_contatoTelefone2 = emp.emp_c_contatoTelefone2,
                             emp_c_email = emp.emp_c_email,
                             emp_c_email2 = emp.emp_c_email2,
                             emp_c_foneComercial = emp.emp_c_foneComercial,
                             emp_c_foneComercial2 = emp.emp_c_foneComercial2,
                             Cidade = cid.cid_c_nome,
                             emp_c_ie = emp.emp_c_ie,
                             emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                             emp_c_numero = emp.emp_c_numero,
                             emp_c_observacao = emp.emp_c_observacao,
                             emp_c_pessoaContato = emp.emp_c_pessoaContato,
                             emp_c_ramais = emp.emp_c_ramais,
                             emp_c_RangePortas = emp.emp_c_RangePortas,
                             emp_c_RangeRamais = emp.emp_c_RangeRamais,
                             emp_c_razaoSocial = emp.emp_c_razaoSocial,
                             emp_c_rua = emp.emp_c_rua,
                             emp_c_unique = emp.emp_c_unique.ToString(),
                             emp_c_usuario = emp.emp_c_usuario,
                             emp_d_alteracao = emp.emp_d_alteracao.ToString(),
                             emp_d_atualizado = emp.emp_d_atualizado.ToString(),
                             emp_d_contrato = emp.emp_d_contrato.ToString(),
                             emp_d_inclusao = emp.emp_d_inclusao.ToString("dd/MM/yyyy"),
                             emp_d_modificacao = emp.emp_d_modificacao.ToString(),
                             emp_fem_n_codigo = emp.emp_fem_n_codigo.ToString(),
                             emp_mol_n_codigo = emp.emp_mol_n_codigo.ToString(),
                             emp_n_codigo = emp.emp_n_codigo.ToString(),
                             Estado = est.est_c_descricao + "-" + est.est_c_sigla,
                             buscaSimples = emp.emp_c_nomeFantasia + " " + emp.emp_c_cnpj
                         });

            //Filtros
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_c_razaoSocial_filter))
            {
                query = query.Where(w => w.emp_c_razaoSocial.Contains(filter.emp_c_razaoSocial_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_c_nomeFantasia_filter))
            {
                query = query.Where(w => w.emp_c_nomeFantasia.Contains(filter.emp_c_nomeFantasia_filter));
            }

            if (!string.IsNullOrEmpty(filter.emp_c_cnpj_filter))
            {
                query = query.Where(w => w.emp_c_cnpj.Contains(filter.emp_c_cnpj_filter));
            }

            if (!string.IsNullOrEmpty(filter.Estado_filter))
            {
                query = query.Where(w => w.Estado.Contains(filter.Estado_filter));
            }

            if (!string.IsNullOrEmpty(filter.Cidade_filter))
            {
                query = query.Where(w => w.Cidade.Contains(filter.Cidade_filter));
            }

            if (!string.IsNullOrEmpty(filter.Ie))
            {
                query = query.Where(w => w.emp_c_ie.Contains(filter.Ie));
            }
            if (!string.IsNullOrEmpty(filter.razaoSocial))
            {
                query = query.Where(w => w.emp_c_razaoSocial.Contains(filter.razaoSocial));
            }

            var listaEmpresas = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                   "Código",
                    "Razão Social",
                    "Nome Fantasia",
                    "CNPJ",
                    "IE",
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
                        worksheet.Cells["A" + j].Value = empresa.emp_n_codigo;
                        worksheet.Cells["B" + j].Value = empresa.emp_c_razaoSocial;
                        worksheet.Cells["C" + j].Value = empresa.emp_c_nomeFantasia;
                        worksheet.Cells["D" + j].Value = empresa.emp_c_cnpj;
                        worksheet.Cells["E" + j].Value = empresa.emp_c_ie;
                        worksheet.Cells["F" + j].Value = empresa.Estado;
                        worksheet.Cells["G" + j].Value = empresa.Cidade;

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

        public List<ComboEmpresaViewModel> ObterComboEmpresa(string empresasId)
        {

            var ret = from emp in Context.tb_emp_empresa
                      .OrderBy(x => x.emp_c_nomeFantasia)
                      select new ComboEmpresaViewModel
                      {
                          emp_n_codigo = emp.emp_n_codigo,
                          emp_c_nomeFantasia = emp.emp_c_nomeFantasia
                      };

            if (!string.IsNullOrEmpty(empresasId))
            {
                var _idsEmpresa = empresasId.Split(",");
                var ids = new List<int>();
                foreach (var id in _idsEmpresa)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        int.TryParse(id, out int _id);
                        if (_id != 0)
                        {
                            ids.Add(_id);
                        }
                    }
                }

                if (ids.Any())
                {
                    ret = ret.Where(x => ids.Contains(x.emp_n_codigo));
                }
            }

            return ret.ToList();

        }

        //retorna combo empresa de acordo com o distribuidor
        public List<EmpresaViewModel> GetComboEmpresa(int id)
        {
            //Se zero, lista todos clientes
            if (id == 0)
            {
                return (from emp in context.tb_emp_empresa
                        select new EmpresaViewModel()
                        {
                            emp_n_codigo = emp.emp_n_codigo.ToString(),
                            emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                        }).OrderBy(y => y.emp_c_nomeFantasia).ToList();
            }
            else
            {
                return (from emp in context.tb_emp_empresa
                        where emp.emp_dis_n_codigo == id
                        select new EmpresaViewModel()
                        {
                            emp_n_codigo = emp.emp_n_codigo.ToString(),
                            emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                        }).OrderBy(y => y.emp_c_nomeFantasia).ToList();
            }
        }

        //Retorna combos de Integrador de acordo com o usuário logado (Distribuidor por id ou proprietário)
        public List<EmpresaViewModel> GetEmpresaByDistribuidor(int id)
        {
            var query = (from emp in context.tb_emp_empresa
                         where emp.emp_dis_n_codigo == id
                         select new EmpresaViewModel()
                         {
                             emp_n_codigo = emp.emp_n_codigo.ToString(),
                             emp_c_razaoSocial = emp.emp_c_razaoSocial,
                             emp_c_nomeFantasia = emp.emp_c_nomeFantasia,

                         });

            return query.OrderBy(x => x.emp_c_nomeFantasia).ToList();
        }

        public List<ComboEmpresaViewModel> ComboIntegradorRelMovimentacao()
        {

            var empresas = (from emp in context.tb_emp_empresa
                            join cli in context.tb_cli_cliente on emp.emp_n_codigo equals cli.cli_emp_n_codigo
                            where cli.cli_tcl_n_codigo == 2 && cli.cli_b_ativo == true
                            select new ComboEmpresaViewModel
                            {
                                emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                                emp_n_codigo = emp.emp_n_codigo
                            });

            return empresas.Distinct().ToList();

        }

        public string[] GetRamaisEmpresa(int id)
        {
            var ramais = (from emp in context.tb_emp_empresa
                          where emp.emp_n_codigo == id
                          select emp.emp_c_ramais).FirstOrDefault();

            if (!string.IsNullOrEmpty(ramais))
            {
                return ramais.Split(",");
            }

            return null;
        }
    }
}
