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
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class OperadorService : RepositoryBase<tb_ope_operador>, IOperadorService
    {
        private IconnectCoreContext context;

        public OperadorService(IconnectCoreContext context) : base(context)
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

        private IModuloService _modulo;
        public IModuloService Modulo
        {
            get
            {
                if (_modulo == null)
                {
                    _modulo = new ModuloService(context);
                }
                return _modulo;
            }
        }

        private IPermissaoClienteService _permissaoCliente;
        public IPermissaoClienteService PermissaoCliente
        {
            get
            {
                if (_permissaoCliente == null)
                {
                    _permissaoCliente = new PermissaoClienteService(context);
                }
                return _permissaoCliente;
            }
        }

        public IPagedList<OperadorViewModel> GetOperadorFiltrado(OperadorFilterModel filter)
        {
            var query = ObterQueryOperadorFiltrados(filter);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        private IQueryable<OperadorViewModel> ObterQueryOperadorFiltrados(OperadorFilterModel filter, bool excel = false)
        {
            var query = (from ope in Context.tb_ope_operador
                         join emp in Context.tb_emp_empresa on ope.ope_emp_n_codigo equals emp.emp_n_codigo into tempEmp
                         from emp in tempEmp.DefaultIfEmpty()
                         orderby ope.ope_b_ativoInativo.Value ? "ATIVO" : "INATIVO" ascending, ope.ope_c_nome
                         select new OperadorViewModel
                         {
                             ope_n_codigo = ope.ope_n_codigo.ToString(),
                             ope_c_nome = ope.ope_c_nome,
                             ope_d_dataNascimento = ope.ope_d_dataNascimento.ToString(),
                             ope_c_rg = ope.ope_c_rg,
                             ope_c_cpf = ope.ope_c_cpf,
                             ope_c_telefone = ope.ope_c_telefone,
                             ope_c_celular = ope.ope_c_celular,
                             ope_c_email = ope.ope_c_email,
                             ope_c_email2 = ope.ope_c_email2,
                             ope_c_rua = ope.ope_c_rua,
                             ope_c_numero = ope.ope_c_numero,
                             ope_c_complemento = ope.ope_c_complemento,
                             ope_c_bairro = ope.ope_c_bairro,
                             ope_c_cep = ope.ope_c_cep,
                             ope_cid_n_codigo = ope.ope_cid_n_codigo.ToString(),
                             ope_est_n_codigo = ope.ope_est_n_codigo.ToString(),
                             ope_c_observacao = ope.ope_c_observacao,
                             ope_ace_n_codigo = ope.ope_ace_n_codigo.ToString(),
                             ope_emp_n_codigo = ope.ope_emp_n_codigo.ToString(),
                             ope_b_ativoInativo = ope.ope_b_ativoInativo.Value ? "ATIVO" : "INATIVO",
                             ope_mol_n_codigo = ope.ope_mol_n_codigo.ToString(),
                             ope_cli_n_atendimento = ope.ope_cli_n_atendimento.ToString(),
                             ope_gpp_n_codigo = ope.ope_gpp_n_codigo.ToString(),
                             ope_d_alteracao = ope.ope_d_alteracao.ToString(),
                             ope_c_usuario = ope.ope_c_usuario,
                             ope_b_todosClientes = ope.ope_b_todosClientes.ToString(),
                             ope_d_modificacao = ope.ope_d_modificacao.ToString(),
                             ope_c_cargo = ope.ope_c_cargo,
                             ope_d_ultimoContato = ope.ope_d_ultimoContato.ToString(),
                             ope_c_unique = ope.ope_c_unique.ToString(),
                             ope_d_atualizado = ope.ope_d_atualizado.ToString(),
                             ope_d_inclusao = ope.ope_d_inclusao.ToString(),
                             ope_b_solicitaRamal = ope.ope_b_solicitaRamal.Value ? "SIM" : "NÃO",
                             ope_b_admIconnect = ope.ope_b_admIconnect.ToString(),
                             ope_emp_n_codigo_ramal = ope.ope_emp_n_codigo_ramal.ToString(),
                             ope_pop_n_codigo = ope.ope_pop_n_codigo.ToString(),
                             NomeEmpresa = emp.emp_c_nomeFantasia != null ? emp.emp_c_nomeFantasia : "ADM. ICONNECT",
                             buscaSimples = ope.ope_c_nome + " " + ope.ope_c_cpf + " " + ope.ope_c_rg
                         });
            if (!string.IsNullOrEmpty(filter.idEmp) && (!filter?.idEmp?.Equals("todos") ?? false) && (!filter?.idEmp?.Equals("0") ?? false))
            {
                var ids = filter.idEmp;
                query = query.Where(w => ids.Contains(w.ope_emp_n_codigo));
            }
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.status_filter))
            {
                query = query.Where(w => w.ope_b_ativoInativo == filter.status_filter);
            }

            if (!string.IsNullOrEmpty(filter.ope_c_nome_filter))
            {
                query = query.Where(w => w.ope_c_nome.Contains(filter.ope_c_nome_filter));
            }

            if (!string.IsNullOrEmpty(filter.nome_empresa_filter))
            {
                query = query.Where(w => w.NomeEmpresa.Contains(filter.nome_empresa_filter));
            }

            if (!string.IsNullOrEmpty(filter.ope_c_cpf_filter))
            {
                query = query.Where(w => w.ope_c_cpf.Contains(filter.ope_c_cpf_filter));
            }

            if (!string.IsNullOrEmpty(filter.ope_c_telefone_filter))
            {
                filter.ope_c_telefone_filter = filter.ope_c_telefone_filter.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                query = query.Where(w => w.ope_c_telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "").Contains(filter.ope_c_telefone_filter));
            }

            if (!string.IsNullOrEmpty(filter.ope_c_celular_filter))
            {
                filter.ope_c_celular_filter = filter.ope_c_celular_filter.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                query = query.Where(w => w.ope_c_celular.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "").Contains(filter.ope_c_celular_filter));
            }

            if (!string.IsNullOrEmpty(filter.ope_c_email_filter))
            {
                query = query.Where(w => w.ope_c_email.Contains(filter.ope_c_email_filter));
            }

            return query;
        }

        public OperadorViewModel GetOperador(int id)
        {
            var operador = (from ope in context.tb_ope_operador
                            where ope.ope_n_codigo == id
                            select new OperadorViewModel()
                            {
                                ope_n_codigo = ope.ope_n_codigo.ToString(),
                                ope_c_nome = ope.ope_c_nome,
                                ope_d_dataNascimento = ope.ope_d_dataNascimento.Value == null ? string.Empty : ope.ope_d_dataNascimento.Value.ToString("yyyy-MM-dd"),
                                ope_c_rg = ope.ope_c_rg,
                                ope_c_cpf = ope.ope_c_cpf,
                                ope_c_telefone = ope.ope_c_telefone,
                                ope_c_celular = ope.ope_c_celular,
                                ope_c_email = ope.ope_c_email,
                                ope_c_email2 = ope.ope_c_email2,
                                ope_c_rua = ope.ope_c_rua,
                                ope_c_numero = ope.ope_c_numero,
                                ope_c_complemento = ope.ope_c_complemento,
                                ope_c_bairro = ope.ope_c_bairro,
                                ope_c_cep = ope.ope_c_cep,
                                ope_cid_n_codigo = ope.ope_cid_n_codigo.ToString(),
                                ope_est_n_codigo = ope.ope_est_n_codigo.ToString(),
                                ope_c_observacao = ope.ope_c_observacao,
                                ope_ace_n_codigo = ope.ope_ace_n_codigo.ToString(),
                                ope_emp_n_codigo = ope.ope_emp_n_codigo != null ? ope.ope_emp_n_codigo.ToString() : "0",
                                ope_b_ativoInativo = ope.ope_b_ativoInativo.Value ? "ATIVO" : "INATIVO",
                                ope_mol_n_codigo = ope.ope_mol_n_codigo.ToString(),
                                ope_cli_n_atendimento = ope.ope_cli_n_atendimento.ToString(),
                                ope_gpp_n_codigo = ope.ope_gpp_n_codigo.ToString(),
                                ope_d_alteracao = ope.ope_d_alteracao.ToString(),
                                ope_c_usuario = ope.ope_c_usuario,
                                ope_b_todosClientes = ope.ope_b_todosClientes.ToString(),
                                ope_d_modificacao = ope.ope_d_modificacao.ToString(),
                                ope_c_cargo = ope.ope_c_cargo,
                                ope_d_ultimoContato = ope.ope_d_ultimoContato.ToString(),
                                ope_c_unique = ope.ope_c_unique.ToString(),
                                ope_d_atualizado = ope.ope_d_atualizado.ToString(),
                                ope_d_inclusao = ope.ope_d_inclusao.ToString(),
                                ope_b_solicitaRamal = ope.ope_b_solicitaRamal.Value ? "SIM" : "NÃO",
                                ope_b_admIconnect = ope.ope_b_admIconnect.ToString(),
                                ope_emp_n_codigo_ramal = ope.ope_emp_n_codigo_ramal.ToString(),
                                ope_pop_n_codigo = ope.ope_pop_n_codigo.ToString(),
                            })?.FirstOrDefault() ?? new OperadorViewModel();

            operador.modulo = Modulo.GetModulos(Convert.ToInt32(operador.ope_mol_n_codigo));
            operador.acesso = Acesso.GetAcesso(Convert.ToInt32(operador.ope_ace_n_codigo));

            return operador;
        }

        public List<OperadorViewModel> GetOperadoresByEmpresa(int idEmpresa)
        {
            return (from ope in context.tb_ope_operador
                    orderby ope.ope_c_nome ascending
                    where ope.ope_emp_n_codigo == idEmpresa && ope.ope_b_ativoInativo == true
                    select new OperadorViewModel()
                    {
                        ope_n_codigo = ope.ope_n_codigo.ToString(),
                        ope_c_nome = ope.ope_c_nome,
                        ope_d_dataNascimento = ope.ope_d_dataNascimento.ToString(),
                        ope_c_rg = ope.ope_c_rg,
                        ope_c_cpf = ope.ope_c_cpf,
                        ope_c_telefone = ope.ope_c_telefone,
                        ope_c_celular = ope.ope_c_celular,
                        ope_c_email = ope.ope_c_email,
                        ope_c_email2 = ope.ope_c_email2,
                        ope_c_rua = ope.ope_c_rua,
                        ope_c_numero = ope.ope_c_numero,
                        ope_c_complemento = ope.ope_c_complemento,
                        ope_c_bairro = ope.ope_c_bairro,
                        ope_c_cep = ope.ope_c_cep,
                        ope_cid_n_codigo = ope.ope_cid_n_codigo.ToString(),
                        ope_est_n_codigo = ope.ope_est_n_codigo.ToString(),
                        ope_c_observacao = ope.ope_c_observacao,
                        ope_ace_n_codigo = ope.ope_ace_n_codigo.ToString(),
                        ope_emp_n_codigo = ope.ope_emp_n_codigo.ToString(),
                        ope_b_ativoInativo = ope.ope_b_ativoInativo.ToString(),
                        ope_mol_n_codigo = ope.ope_mol_n_codigo.ToString(),
                        ope_cli_n_atendimento = ope.ope_cli_n_atendimento.ToString(),
                        ope_gpp_n_codigo = ope.ope_gpp_n_codigo.ToString(),
                        ope_d_alteracao = ope.ope_d_alteracao.ToString(),
                        ope_c_usuario = ope.ope_c_usuario,
                        ope_b_todosClientes = ope.ope_b_todosClientes.ToString(),
                        ope_d_modificacao = ope.ope_d_modificacao.ToString(),
                        ope_c_cargo = ope.ope_c_cargo,
                        ope_d_ultimoContato = ope.ope_d_ultimoContato.ToString(),
                        ope_c_unique = ope.ope_c_unique.ToString(),
                        ope_d_atualizado = ope.ope_d_atualizado.ToString(),
                        ope_d_inclusao = ope.ope_d_inclusao.ToString(),
                        ope_b_solicitaRamal = ope.ope_b_solicitaRamal.Value ? "SIM" : "NÃO",
                        ope_b_admIconnect = ope.ope_b_admIconnect.ToString(),
                        ope_emp_n_codigo_ramal = ope.ope_emp_n_codigo_ramal.ToString(),
                    }).ToList();
        }

        public int SalvarOperador(OperadorViewModel model)
        {
            VerificarDuplicidade(model);

            var acesso = new AcessoViewModel
            {
                ace_n_codigo = !string.IsNullOrEmpty(model.ope_ace_n_codigo) ? Convert.ToInt32(model.ope_ace_n_codigo) : new int(),
                ace_c_login = model?.acesso.ace_c_login,
                ace_c_senha = model?.acesso.ace_c_senha,
                ace_per_n_codigo = model.ope_emp_n_codigo == "0" ? 8 : 5,
            };

            Acesso.InsertOrUpdate(acesso);
            model.ope_ace_n_codigo = acesso.ace_n_codigo.ToString();

            //Inserir/atualizar Permissão módulos
            var modulo = new ModuloViewModel
            {
                mol_n_codigo = model.ope_mol_n_codigo,
                mol_b_connectSolutions = model.modulo.mol_b_connectSolutions,
                mol_b_OrdemServico = model.modulo.mol_b_OrdemServico,
                mol_b_controleDeAcesso = model.modulo.mol_b_controleDeAcesso,
                mol_b_MonitoriamentoPerimetral = model.modulo.mol_b_MonitoriamentoPerimetral,
                mol_b_CFTV = model.modulo.mol_b_CFTV
            };

            modulo = Modulo.InsertOrUpdate(modulo);
            model.ope_mol_n_codigo = modulo.mol_n_codigo.ToString();

            //Ramal
            int? codEmpRamal = null;
            if (!string.IsNullOrEmpty(model.ope_emp_n_codigo_ramal) && !model.ope_emp_n_codigo_ramal.Equals("0"))
            {
                codEmpRamal = Convert.ToInt32(model.ope_emp_n_codigo_ramal);
            }

            //Empresa
            int? idEmpresa = null;
            if (!string.IsNullOrEmpty(model.ope_emp_n_codigo))
            {
                idEmpresa = Convert.ToInt32(model.ope_emp_n_codigo);
            }

            //PerfilOperador
            int? perfilOperador = null;
            if (!string.IsNullOrEmpty(model.ope_pop_n_codigo) && !model.ope_pop_n_codigo.Equals("0"))
            {
                perfilOperador = Convert.ToInt32(model.ope_pop_n_codigo);
            }

            tb_ope_operador operador;

            if (string.IsNullOrEmpty(model.ope_n_codigo) || model.ope_n_codigo.Equals("0"))
            {
                operador = new tb_ope_operador()
                {
                    ope_c_nome = model.ope_c_nome,
                    ope_d_dataNascimento = !string.IsNullOrEmpty(model?.ope_d_dataNascimento) ? Convert.ToDateTime(model?.ope_d_dataNascimento) : new DateTime?(),
                    ope_c_rg = model.ope_c_rg,
                    ope_c_cpf = model.ope_c_cpf,
                    ope_c_telefone = model.ope_c_telefone,
                    ope_c_celular = model.ope_c_celular,
                    ope_c_email = model.ope_c_email,
                    ope_c_email2 = model.ope_c_email2,
                    ope_c_rua = model.ope_c_rua,
                    ope_c_numero = model.ope_c_numero,
                    ope_c_complemento = model.ope_c_complemento,
                    ope_c_bairro = model.ope_c_bairro,
                    ope_c_cep = model.ope_c_cep,
                    ope_cid_n_codigo = !string.IsNullOrEmpty(model.ope_cid_n_codigo) && !model.ope_cid_n_codigo.Equals("0") ? Convert.ToInt32(model.ope_cid_n_codigo) : new int?(),
                    ope_est_n_codigo = !string.IsNullOrEmpty(model.ope_est_n_codigo) && !model.ope_est_n_codigo.Equals("0") ? Convert.ToInt32(model.ope_est_n_codigo) : new int?(),
                    ope_c_observacao = model.ope_c_observacao,
                    ope_ace_n_codigo = !string.IsNullOrEmpty(model.ope_ace_n_codigo) && !model.ope_ace_n_codigo.Equals("0") ? Convert.ToInt32(model.ope_ace_n_codigo) : new int?(),
                    ope_emp_n_codigo = idEmpresa,
                    ope_b_ativoInativo = !string.IsNullOrEmpty(model.ope_b_ativoInativo) ? Convert.ToBoolean(model.ope_b_ativoInativo) : new bool?(),
                    ope_mol_n_codigo = !string.IsNullOrEmpty(model.ope_mol_n_codigo) && !model.ope_mol_n_codigo.Equals("0") ? Convert.ToInt32(model.ope_mol_n_codigo) : new int?(),
                    ope_cli_n_atendimento = null,
                    ope_gpp_n_codigo = null,
                    ope_d_alteracao = DateTime.Now,
                    ope_c_usuario = "FELIPE",
                    ope_b_todosClientes = !string.IsNullOrEmpty(model.ope_b_todosClientes) ? Convert.ToBoolean(model.ope_b_todosClientes) : new bool?(),
                    ope_d_modificacao = DateTime.Now,
                    ope_c_cargo = model.ope_c_cargo,
                    ope_d_ultimoContato = DateTime.Now,
                    ope_c_unique = Guid.NewGuid(),
                    ope_d_atualizado = DateTime.Now,
                    ope_d_inclusao = DateTime.Now,
                    ope_b_solicitaRamal = !string.IsNullOrEmpty(model.ope_b_solicitaRamal) ? Convert.ToBoolean(model.ope_b_solicitaRamal) : new bool?(),
                    ope_b_admIconnect = !string.IsNullOrEmpty(model.ope_b_admIconnect) ? Convert.ToBoolean(model.ope_b_admIconnect) : new bool?(),
                    ope_emp_n_codigo_ramal = codEmpRamal,
                    ope_pop_n_codigo = perfilOperador
                };

                Insert(operador);
                context.SaveChanges();

                PermissaoCliente.VincularPermissoes(operador.ope_n_codigo);
            }
            else
            {
                operador = (from ope in context.tb_ope_operador where ope.ope_n_codigo == Convert.ToInt32(model.ope_n_codigo) select ope)?.FirstOrDefault();
                operador.ope_n_codigo = !string.IsNullOrEmpty(model.ope_n_codigo) ? Convert.ToInt32(model.ope_n_codigo) : new int();
                operador.ope_c_nome = model.ope_c_nome;
                operador.ope_d_dataNascimento = !string.IsNullOrEmpty(model.ope_d_dataNascimento) ? Convert.ToDateTime(model.ope_d_dataNascimento) : new DateTime?();
                operador.ope_c_rg = model.ope_c_rg;
                operador.ope_c_cpf = model.ope_c_cpf;
                operador.ope_c_telefone = model.ope_c_telefone;
                operador.ope_c_celular = model.ope_c_celular;
                operador.ope_c_email = model.ope_c_email;
                operador.ope_c_email2 = model.ope_c_email2;
                operador.ope_c_rua = model.ope_c_rua;
                operador.ope_c_numero = model.ope_c_numero;
                operador.ope_c_complemento = model.ope_c_complemento;
                operador.ope_c_bairro = model.ope_c_bairro;
                operador.ope_c_cep = model.ope_c_cep;
                operador.ope_cid_n_codigo = !string.IsNullOrEmpty(model.ope_cid_n_codigo) ? Convert.ToInt32(model.ope_cid_n_codigo) : new int?();
                operador.ope_est_n_codigo = !string.IsNullOrEmpty(model.ope_est_n_codigo) ? Convert.ToInt32(model.ope_est_n_codigo) : new int?();
                operador.ope_c_observacao = model.ope_c_observacao;
                operador.ope_ace_n_codigo = !string.IsNullOrEmpty(model.ope_ace_n_codigo) ? Convert.ToInt32(model.ope_ace_n_codigo) : new int?();
                operador.ope_emp_n_codigo = !string.IsNullOrEmpty(model.ope_emp_n_codigo) && !model.ope_emp_n_codigo.Equals("0") ? Convert.ToInt32(model.ope_emp_n_codigo) : new int?();
                operador.ope_b_ativoInativo = !string.IsNullOrEmpty(model.ope_b_ativoInativo) ? Convert.ToBoolean(model.ope_b_ativoInativo) : new bool?();
                operador.ope_mol_n_codigo = !string.IsNullOrEmpty(model.ope_mol_n_codigo) ? Convert.ToInt32(model.ope_mol_n_codigo) : new int?();
                operador.ope_cli_n_atendimento = null;
                operador.ope_gpp_n_codigo = null;
                operador.ope_d_alteracao = DateTime.Now;
                operador.ope_c_usuario = model.ope_c_usuario;
                operador.ope_b_todosClientes = !string.IsNullOrEmpty(model.ope_b_todosClientes) ? Convert.ToBoolean(model.ope_b_todosClientes) : new bool?();
                operador.ope_d_modificacao = DateTime.Now;
                operador.ope_c_cargo = model.ope_c_cargo;
                operador.ope_d_ultimoContato = !string.IsNullOrEmpty(model.ope_d_ultimoContato) ? Convert.ToDateTime(model.ope_d_ultimoContato) : new DateTime?();
                operador.ope_d_atualizado = DateTime.Now;
                operador.ope_b_solicitaRamal = !string.IsNullOrEmpty(model.ope_b_solicitaRamal) ? Convert.ToBoolean(model.ope_b_solicitaRamal) : new bool?();
                operador.ope_b_admIconnect = !string.IsNullOrEmpty(model.ope_b_admIconnect) ? Convert.ToBoolean(model.ope_b_admIconnect) : new bool?();
                operador.ope_emp_n_codigo_ramal = !string.IsNullOrEmpty(model.ope_emp_n_codigo_ramal) && !model.ope_emp_n_codigo_ramal.Equals("0") ? Convert.ToInt32(model.ope_emp_n_codigo_ramal) : new int?();
                operador.ope_pop_n_codigo = !string.IsNullOrEmpty(model.ope_pop_n_codigo) && !model.ope_pop_n_codigo.Equals("0") ? Convert.ToInt32(model.ope_pop_n_codigo) : new int?(); ;
                operador.ope_d_ultimoContato = null;

                Update(operador);
                context.SaveChanges();
            }

            return operador.ope_n_codigo;
        }

        public bool DeletarOperador(int id)
        {
            try
            {
                int result = Context.tb_ope_operador.FirstOrDefault(w => w.ope_n_codigo == id).ope_ace_n_codigo.Value;

                Delete(context.tb_ope_operador.Find(id));
                context.SaveChanges();
                Acesso.DeletarAcesso(result);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void VerificarDuplicidade(OperadorViewModel model)
        {
            if (!string.IsNullOrEmpty(model.ope_c_rg))
            {
                int result = Context.tb_ope_operador.Where(w => w.ope_n_codigo != Convert.ToInt32(model.ope_n_codigo) && w.ope_c_rg.Equals(model.ope_c_rg)).Count();
                if (result > 0)
                {
                    throw new MensagemException("Já existe um usuário registrado com este RG.");
                }
            }

            if (!string.IsNullOrEmpty(model.ope_c_cpf))
            {
                int result = Context.tb_ope_operador.Where(w => w.ope_n_codigo != Convert.ToInt32(model.ope_n_codigo) && w.ope_c_cpf.Equals(model.ope_c_cpf)).Count();
                if (result > 0)
                {
                    throw new MensagemException("Já existe um usuário registrado com este CPF.");
                }
            }

            if (!string.IsNullOrEmpty(model.ope_c_email))
            {
                int result = Context.tb_ope_operador.Where(w => w.ope_n_codigo != Convert.ToInt32(model.ope_n_codigo) && w.ope_c_email.Equals(model.ope_c_email)).Count();
                if (result > 0)
                {
                    throw new MensagemException("Já existe um usuário registrado com este E-mail.");
                }
            }
        }

        public byte[] GeraExcel(OperadorFilterModel filter)
        {
            var query = ObterQueryOperadorFiltrados(filter, true);
            var lstOperador = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Status",
                    "Nome",
                    "Cargo",
                    "Empresa",
                    "RG",
                    "CPF",
                    "Telefone",
                    "Celular",
                    "E-mail",
                    "E-mail Sec.",
                    "Dt. Nascimento",
                    "Rua",
                    "Núm.",
                    "Complemento",
                    "Bairro",
                    "Cidade",
                    "Estado",
                    "CEP",
                    "Solicitar Ramal?",
                };

                var worksheet = package.Workbook.Worksheets.Add("Usuarios");
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
                    foreach (var operador in lstOperador)
                    {
                        worksheet.Cells["A" + j].Value = operador.ope_n_codigo;
                        worksheet.Cells["B" + j].Value = operador.ope_b_ativoInativo;
                        worksheet.Cells["C" + j].Value = operador.ope_c_nome;
                        worksheet.Cells["D" + j].Value = operador.ope_c_cargo;
                        worksheet.Cells["E" + j].Value = operador.NomeEmpresa;
                        worksheet.Cells["F" + j].Value = operador.ope_c_rg;
                        worksheet.Cells["G" + j].Value = operador.ope_c_cpf;
                        worksheet.Cells["H" + j].Value = operador.ope_c_telefone;
                        worksheet.Cells["I" + j].Value = operador.ope_c_celular;
                        worksheet.Cells["J" + j].Value = operador.ope_c_email;
                        worksheet.Cells["K" + j].Value = operador.ope_c_email2;
                        worksheet.Cells["L" + j].Value = operador.ope_d_dataNascimento;
                        worksheet.Cells["M" + j].Value = operador.ope_c_rua;
                        worksheet.Cells["N" + j].Value = operador.ope_c_numero;
                        worksheet.Cells["O" + j].Value = operador.ope_c_complemento;
                        worksheet.Cells["P" + j].Value = operador.ope_c_bairro;
                        worksheet.Cells["Q" + j].Value = operador.NomeCidade;
                        worksheet.Cells["R" + j].Value = operador.NomeEstado;
                        worksheet.Cells["S" + j].Value = operador.ope_c_cep;
                        worksheet.Cells["T" + j].Value = operador.ope_b_solicitaRamal;
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

        public LayoutViewModel GetByCabecalho(int idCabecalho)
        {

            return (from lay in Context.tb_lay_layout
                    where lay.lay_cla_n_codigo == idCabecalho

                    select new LayoutViewModel
                    {
                        lay_n_codigo = lay.lay_n_codigo.ToString(),
                        lay_cli_n_codigo = lay.lay_cli_n_codigo.ToString(),
                        lay_ddv_n_codigo = lay.lay_ddv_n_codigo.ToString(),


                    }).FirstOrDefault();
        }

        public List<GenericList> GetOperadoresCliente(int idCliente)
        {
            return (from o in Context.tb_ope_operador
                    join pec in Context.tb_pec_permissaoCliente on o.ope_n_codigo equals pec.pec_ope_n_codigo
                    where pec.pec_cli_n_codigo == idCliente && o.ope_b_ativoInativo == true
                    select new GenericList()
                    {
                        value = o.ope_n_codigo.ToString(),
                        text = o.ope_c_nome,
                        grupo = "Operador Online"


                    }).ToList();
        }

        public List<GenericList> ListarPerfis()
        {
            return (from p in Context.tb_pop_perfilOperador
                    select new GenericList()
                    {
                        value = p.pop_n_codigo.ToString(),
                        text = p.pop_c_nome,
                        grupo = "Operador Online"
                    }).ToList();
        }
    }
}