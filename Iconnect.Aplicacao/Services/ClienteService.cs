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
using System.Globalization;
using Iconnect.Portal.Helpers;
using System.IO;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class ClienteService : RepositoryBase<tb_cli_cliente>, IClienteService
    {
        private IconnectCoreContext context;

        public ClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IZeladorClienteService _zeladorCliente;
        public IZeladorClienteService ZeladorCliente
        {
            get
            {
                if (_zeladorCliente == null)
                {
                    _zeladorCliente = new ZeladorClienteService(context);
                }
                return _zeladorCliente;
            }
        }

        private IDispositivoCFTVService _dispositivoCFTV;
        public IDispositivoCFTVService DispositivoCFTV
        {
            get
            {
                if (_dispositivoCFTV == null)
                {
                    _dispositivoCFTV = new DispositivoCFTVService(context);
                }
                return _dispositivoCFTV;
            }
        }

        private IEquipamentoClienteService _equipamentoCliente;
        public IEquipamentoClienteService EquipamentoCliente
        {
            get
            {
                if (_equipamentoCliente == null)
                {
                    _equipamentoCliente = new EquipamentoClienteService(context);
                }
                return _equipamentoCliente;
            }
        }
        private IMotivoOcorrenciaService _motivoOcorrencia;
        public IMotivoOcorrenciaService MotivoOcorrencia
        {
            get
            {
                if (_motivoOcorrencia == null)
                {
                    _motivoOcorrencia = new MotivoOcorrenciaService(context);
                }
                return _motivoOcorrencia;
            }
        }

        private IVigilanteClienteService _vigilanteCliente;
        public IVigilanteClienteService VigilanteCliente
        {
            get
            {
                if (_vigilanteCliente == null)
                {
                    _vigilanteCliente = new VigilanteClienteService(context);
                }
                return _vigilanteCliente;
            }
        }

        private IZoneamentoClienteService _zoneamentoCliente;
        public IZoneamentoClienteService ZoneamentoCliente
        {
            get
            {
                if (_zoneamentoCliente == null)
                {
                    _zoneamentoCliente = new ZoneamentoClienteService(context);
                }
                return _zoneamentoCliente;
            }
        }

        private ILayoutService _layout;
        public ILayoutService Layout
        {
            get
            {
                if (_layout == null)
                {
                    _layout = new LayoutService(context);
                }
                return _layout;
            }
        }

        private IMapeamentoPontoAcessoService _apeamentoPontoAcesso;
        public IMapeamentoPontoAcessoService MapeamentoPontoAcesso
        {
            get
            {
                if (_apeamentoPontoAcesso == null)
                {
                    _apeamentoPontoAcesso = new MapeamentoPontoAcessoService(context);
                }
                return _apeamentoPontoAcesso;
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

        private IEmailService _email;
        public IEmailService Email
        {
            get
            {
                if (_email == null)
                {
                    _email = new EmailService(context);
                }
                return _email;
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
        private ISegurancaService _segurancao;
        public ISegurancaService Seguranca
        {
            get
            {
                if (_segurancao == null)
                {
                    _segurancao = new SegurancaService(context);
                }
                return _segurancao;
            }
        }

        private ILocalidadeClienteService _localidade;
        public ILocalidadeClienteService Localidade
        {
            get
            {
                if (_localidade == null)
                {
                    _localidade = new LocalidadeClienteService(context);
                }
                return _localidade;
            }
        }

        private IDuvidasAppService _duvidasCliente;
        public IDuvidasAppService DuvidasAppCliente
        {
            get
            {
                if (_duvidasCliente == null)
                {
                    _duvidasCliente = new DuvidasAppService(context);
                }
                return _duvidasCliente;
            }
        }

        private ILicencasService _licenca;
        public ILicencasService Licenca
        {
            get
            {
                if (_licenca == null)
                {
                    _licenca = new LicencasService(context);
                }
                return _licenca;
            }
        }


        public ClienteViewModel GetCliente(int id, bool userIsAdmin = false)
        {

            int sms = (from lsm in Context.tb_lsm_logSMS select lsm).Count();

            return (from c in Context.tb_cli_cliente
                    join emp in Context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                    where c.cli_n_codigo == id
                    select new ClienteViewModel()
                    {
                        cli_n_codigo = c.cli_n_codigo.ToString(),
                        cli_b_ativo = c.cli_b_ativo.ToString(),
                        cli_b_controleAcesso = c.cli_b_controleAcesso,
                        cli_b_licencaAtiva = c.cli_b_licencaAtiva,
                        cli_can_n_access = c.cli_can_n_access,
                        cli_can_n_panoramica = c.cli_can_n_panoramica.ToString(),
                        cli_cid_n_codigo = c.cli_cid_n_codigo.ToString(),
                        cli_c_bairro = c.cli_c_bairro,
                        cli_c_celular = c.cli_c_celular,
                        cli_c_celular2 = c.cli_c_celular2,
                        cli_c_celularAdministradora = c.cli_c_celularAdministradora,
                        cli_c_centralVoip = c.cli_c_centralVoip,
                        cli_c_cep = c.cli_c_cep,
                        cli_c_chave = c.cli_c_chave,
                        cli_c_cnpj = c.cli_c_cnpj,
                        cli_c_codigoReferencia = c.cli_c_codigoReferencia,
                        cli_c_codInstalacaoOffline = c.cli_c_codInstalacaoOffline,
                        cli_c_codInstalacaoRenovacao = c.cli_c_codInstalacaoRenovacao,
                        cli_c_complemento = c.cli_c_complemento,
                        cli_c_contraSenha = c.cli_c_contraSenha,
                        cli_c_dominio = c.cli_c_dominio,
                        cli_c_dominioSIP = c.cli_c_dominioSIP,
                        cli_c_email = c.cli_c_email,
                        cli_c_email2 = c.cli_c_email2,
                        cli_c_emailAdministradora = c.cli_c_emailAdministradora,
                        cli_c_fantasiaAdministradora = c.cli_c_fantasiaAdministradora,
                        cli_c_ie = c.cli_c_ie,
                        cli_c_ip = c.cli_c_ip,
                        cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                        cli_c_numero = c.cli_c_numero,
                        cli_c_observacao = c.cli_c_observacao,
                        cli_c_pessoaContato = c.cli_c_pessoaContato,
                        cli_c_pessoaContatoAdministradora = c.cli_c_pessoaContatoAdministradora,
                        cli_c_porta = c.cli_c_porta,
                        cli_c_portaSIP = c.cli_c_portaSIP,
                        cli_c_ramalPortaria = c.cli_c_ramalPortaria,
                        cli_c_ramais = c.cli_c_ramais,
                        cli_c_ramal = c.cli_c_ramal,
                        cli_c_range_periodo_aplicadorTicket = c.cli_c_range_periodo_aplicadorTicket,
                        cli_c_razaoSocial = c.cli_c_razaoSocial,
                        cli_c_rua = c.cli_c_rua,
                        cli_c_senha = c.cli_c_senha,
                        cli_c_senhaSIP = c.cli_c_senhaSIP,
                        cli_c_serial = c.cli_c_serial,
                        cli_c_telefoneAdministradora = c.cli_c_telefoneAdministradora,
                        cli_c_telefoneComercial = c.cli_c_telefoneComercial,
                        cli_c_telefoneComercial2 = c.cli_c_telefoneComercial2,
                        cli_c_tipoRede = c.cli_c_tipoRede,
                        cli_c_unique = c.cli_c_unique,
                        cli_c_usuario = c.cli_c_usuario,
                        cli_c_zona = c.cli_c_zona,
                        cli_d_alteracao = c.cli_d_alteracao,
                        cli_d_atualizado = c.cli_d_atualizado,
                        cli_d_dataCriacao = c.cli_d_dataCriacao,
                        cli_d_dataExpiracao = c.cli_d_dataExpiracao,
                        cli_d_dataUltimaSincronizacaoCloud = c.cli_d_dataUltimaSincronizacaoCloud,
                        cli_d_dataVencimentoLicenca = c.cli_d_dataVencimentoLicenca.Value.ToString("yyyy-MM-dd"),
                        cli_d_inclusao = c.cli_d_inclusao.Value.ToString("dd/MM/yyyy"),
                        cli_d_inicioContrato = c.cli_d_inicioContrato.Value.ToString("yyyy-MM-dd"),
                        cli_d_inicioLicenca = c.cli_d_inicioLicenca.Value.ToString("yyyy-MM-dd"),
                        cli_d_modificacao = c.cli_d_modificacao,
                        cli_d_ultimoContatoSolution = c.cli_d_ultimoContatoSolution,
                        cli_emp_n_codigo = c.cli_emp_n_codigo.ToString(),
                        cli_est_n_codigo = c.cli_est_n_codigo.ToString(),
                        cli_lay_n_codigo = c.cli_lay_n_codigo,
                        cli_mol_n_codigo = c.cli_mol_n_codigo.ToString(),
                        cli_n_diaVencimento = c.cli_n_diaVencimento.ToString(),
                        cli_n_numDiasExpiracao = c.cli_n_numDiasExpiracao.ToString(),
                        cli_n_tempoGravacaoGoogleDrive = c.cli_n_tempoGravacaoGoogleDrive,
                        cli_n_valorLicenca = c.cli_n_valorLicenca.ToString(),
                        cli_tcl_n_codigo = c.cli_tcl_n_codigo.ToString(),
                        cli_smsEnviados = sms.ToString(),
                        cli_n_horasExpiracaoTokenDelivery = c.cli_n_horasExpiracaoTokenDelivery.ToString(),
                        cli_b_disparoSMS = c.cli_b_disparoSMS.ToString(),
                        emp_rangeRamais = emp.emp_c_RangeRamais,
                        tipoGaren = emp.emp_b_tipoGaren.ToString(),
                        cli_c_emailSegTrabalho = c.cli_c_emailSegTrabalho,
                        cli_c_senhaAppGarenConnect = c.cli_c_senhaAppGarenConnect,
                        cli_b_free = userIsAdmin ? false : c.cli_b_free,
                        cli_b_freeLicença = c.cli_b_free,
                        cli_c_tituloInstitucional = c.cli_c_tituloInstitucional,
                        cli_c_descricaoInstitucional = c.cli_c_descricaoInstitucional,
                        cli_fot_fachada_n_codigo = c.cli_fot_fachada_n_codigo.ToString()
                    }).FirstOrDefault();
        }

        public List<ClienteViewModel> ListarTodos(string ids, bool userIsAdmin = false)
        {
            var cli = (from c in Context.tb_cli_cliente
                       join emp in Context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                       where c.cli_b_ativo == true
                       orderby c.cli_c_nomeFantasia
                       select new ClienteViewModel()
                       {
                           cli_n_codigo = c.cli_n_codigo.ToString(),
                           cli_b_ativo = c.cli_b_ativo.ToString(),
                           cli_b_controleAcesso = c.cli_b_controleAcesso,
                           cli_b_licencaAtiva = c.cli_b_licencaAtiva,
                           cli_b_free = userIsAdmin ? false : c.cli_b_free,
                           cli_can_n_access = c.cli_can_n_access,
                           cli_can_n_panoramica = c.cli_can_n_panoramica.ToString(),
                           cli_cid_n_codigo = c.cli_cid_n_codigo.ToString(),
                           cli_c_bairro = c.cli_c_bairro,
                           cli_c_celular = c.cli_c_celular,
                           cli_c_celular2 = c.cli_c_celular2,
                           cli_c_celularAdministradora = c.cli_c_celularAdministradora,
                           cli_c_centralVoip = c.cli_c_centralVoip,
                           cli_c_cep = c.cli_c_cep,
                           cli_c_chave = c.cli_c_chave,
                           cli_c_cnpj = c.cli_c_cnpj,
                           cli_c_codigoReferencia = c.cli_c_codigoReferencia,
                           cli_c_codInstalacaoOffline = c.cli_c_codInstalacaoOffline,
                           cli_c_codInstalacaoRenovacao = c.cli_c_codInstalacaoRenovacao,
                           cli_c_complemento = c.cli_c_complemento,
                           cli_c_contraSenha = c.cli_c_contraSenha,
                           cli_c_dominio = c.cli_c_dominio,
                           cli_c_dominioSIP = c.cli_c_dominioSIP,
                           cli_c_email = c.cli_c_email,
                           cli_c_email2 = c.cli_c_email2,
                           cli_c_emailAdministradora = c.cli_c_emailAdministradora,
                           cli_c_fantasiaAdministradora = c.cli_c_fantasiaAdministradora,
                           cli_c_ie = c.cli_c_ie,
                           cli_c_ip = c.cli_c_ip,
                           cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                           cli_c_numero = c.cli_c_numero,
                           cli_c_observacao = c.cli_c_observacao,
                           cli_c_pessoaContato = c.cli_c_pessoaContato,
                           cli_c_pessoaContatoAdministradora = c.cli_c_pessoaContatoAdministradora,
                           cli_c_porta = c.cli_c_porta,
                           cli_c_portaSIP = c.cli_c_portaSIP,
                           cli_c_ramais = c.cli_c_ramais,
                           cli_c_ramal = c.cli_c_ramal,
                           cli_c_range_periodo_aplicadorTicket = c.cli_c_range_periodo_aplicadorTicket,
                           cli_c_razaoSocial = c.cli_c_razaoSocial,
                           cli_c_rua = c.cli_c_rua,
                           cli_c_senha = c.cli_c_senha,
                           cli_c_senhaSIP = c.cli_c_senhaSIP,
                           cli_c_serial = c.cli_c_serial,
                           cli_c_telefoneAdministradora = c.cli_c_telefoneAdministradora,
                           cli_c_telefoneComercial = c.cli_c_telefoneComercial,
                           cli_c_telefoneComercial2 = c.cli_c_telefoneComercial2,
                           cli_c_tipoRede = c.cli_c_tipoRede,
                           cli_c_unique = c.cli_c_unique,
                           cli_c_usuario = c.cli_c_usuario,
                           cli_c_zona = c.cli_c_zona,
                           cli_d_alteracao = c.cli_d_alteracao,
                           cli_d_atualizado = c.cli_d_atualizado,
                           cli_d_dataCriacao = c.cli_d_dataCriacao,
                           cli_d_dataExpiracao = c.cli_d_dataExpiracao,
                           cli_d_dataUltimaSincronizacaoCloud = c.cli_d_dataUltimaSincronizacaoCloud,
                           cli_d_dataVencimentoLicenca = c.cli_d_dataVencimentoLicenca.Value.ToString("dd/MM/yyyy"),
                           cli_d_inclusao = c.cli_d_inclusao.Value.ToString("dd/MM/yyyy"),
                           cli_d_inicioContrato = c.cli_d_inicioContrato.Value.ToString("dd/MM/yyyy"),
                           cli_d_inicioLicenca = c.cli_d_inicioLicenca.Value.ToString("dd/MM/yyyy"),
                           cli_d_modificacao = c.cli_d_modificacao,
                           cli_d_ultimoContatoSolution = c.cli_d_ultimoContatoSolution,
                           cli_emp_n_codigo = c.cli_emp_n_codigo.ToString(),
                           cli_est_n_codigo = c.cli_est_n_codigo.ToString(),
                           cli_lay_n_codigo = c.cli_lay_n_codigo,
                           cli_mol_n_codigo = c.cli_mol_n_codigo.ToString(),
                           cli_n_diaVencimento = c.cli_n_diaVencimento.ToString(),
                           cli_n_horasExpiracaoTokenDelivery = c.cli_n_horasExpiracaoTokenDelivery.ToString(),
                           cli_n_numDiasExpiracao = c.cli_n_numDiasExpiracao.ToString(),
                           cli_n_tempoGravacaoGoogleDrive = c.cli_n_tempoGravacaoGoogleDrive,
                           cli_n_valorLicenca = c.cli_n_valorLicenca.ToString(),
                           cli_tcl_n_codigo = c.cli_tcl_n_codigo.ToString(),
                           cli_c_tituloInstitucional = c.cli_c_tituloInstitucional,
                           cli_c_descricaoInstitucional = c.cli_c_descricaoInstitucional,
                           Empresa = emp.emp_c_nomeFantasia,
                           cli_fot_fachada_n_codigo = c.cli_fot_fachada_n_codigo.ToString()
                       }).ToList();

            if (ids != "todos")
                cli = cli.Where(x => ids.Split(',').Contains(x.cli_n_codigo))?.ToList();

            return cli;
        }

        public List<TipoClienteViewModel> ListarTipos()
        {
            return (from tcl in Context.tb_tcl_tipoCliente
                    select new TipoClienteViewModel()
                    {
                        tcl_c_nome = tcl.tcl_c_nome,
                        tcl_n_codigo = tcl.tcl_n_codigo.ToString()
                    }).ToList();

        }

        public List<ClienteViewModel> GetClientes(int idEmpresa, string idsClientes)
        {
            //Se zero, lista todos clientes
            if (idEmpresa == 0)
            {
                var query = from c in Context.tb_cli_cliente
                            join emp in Context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                            where c.cli_b_ativo == true
                            orderby c.cli_c_nomeFantasia
                            select new ClienteViewModel()
                            {
                                cli_n_codigo = c.cli_n_codigo.ToString(),
                                cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                                Empresa = emp.emp_c_nomeFantasia,
                            };

                if (!string.IsNullOrEmpty(idsClientes) && (!idsClientes?.Equals("todos") ?? false) && (!idsClientes?.Equals("NULL") ?? false))
                {
                    var ids = idsClientes.Split(",");
                    query = query.Where(w => ids.Contains(w.cli_n_codigo));
                }

                return query.ToList();
            }
            else
            {
                var query = from c in Context.tb_cli_cliente
                            join emp in Context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                            where c.cli_b_ativo == true && c.cli_emp_n_codigo == idEmpresa
                            orderby c.cli_c_nomeFantasia
                            select new ClienteViewModel()
                            {
                                cli_n_codigo = c.cli_n_codigo.ToString(),
                                cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                                Empresa = emp.emp_c_nomeFantasia,
                            };

                if (!string.IsNullOrEmpty(idsClientes) && (!idsClientes?.Equals("todos") ?? false) && (!idsClientes?.Equals("NULL") ?? false))
                {
                    var ids = idsClientes.Split(",");
                    query = query.Where(w => ids.Contains(w.cli_n_codigo));
                }

                return query.ToList();
            }
        }

        public List<ClienteViewModel> GetClienteEmpresarial(int id, string clientes)
        {
            //Se zero, lista todos clientes
            List<ClienteViewModel> lista = new List<ClienteViewModel>();
            List<ClienteViewModel> listaAux = new List<ClienteViewModel>();
            if (id == 0)
            {
                lista = (from c in Context.tb_cli_cliente
                         join emp in Context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                         where c.cli_b_ativo == true && c.cli_tcl_n_codigo == 2
                         select new ClienteViewModel()
                         {
                             cli_n_codigo = c.cli_n_codigo.ToString(),
                             cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                             Empresa = emp.emp_c_nomeFantasia,
                         }).OrderBy(x => x.Empresa).ThenBy(y => y.cli_c_nomeFantasia).ToList();
            }
            else
            {
                lista = (from c in Context.tb_cli_cliente
                         join emp in Context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                         where (c.cli_tcl_n_codigo == 2 || c.cli_tcl_n_codigo == 3) && c.cli_b_ativo == true && c.cli_emp_n_codigo == id
                         select new ClienteViewModel()
                         {
                             cli_n_codigo = c.cli_n_codigo.ToString(),
                             cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                             Empresa = emp.emp_c_nomeFantasia,
                         }).OrderBy(x => x.Empresa).ThenBy(y => y.cli_c_nomeFantasia).ToList();
            }
            if (string.IsNullOrEmpty(clientes) || clientes != "todos")
            {
                var clientesArray = clientes.Split(",");
                foreach (var c in clientesArray)
                {
                    listaAux = lista.Where(x => x.cli_n_codigo.Contains(c)).ToList();
                }
                lista = listaAux;
            }
            return lista;
        }

        public IPagedList<ClienteViewModel> GetClienteFiltrado(ClienteFilterModel filter)
        {
            var query = ObterQueryClientesFiltrados(filter);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public List<ClienteViewModel> GetRelClientes(EmpresaViewModel model)
        {
            int idEmp = Convert.ToInt32(model.emp_n_codigo);
            var query = (from cli in context.tb_cli_cliente
                         join emp in Context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                         join cid in Context.tb_cid_cidade on cli.cli_cid_n_codigo equals cid.cid_n_codigo
                         join est in Context.tb_est_estado on cli.cli_est_n_codigo equals est.est_n_codigo
                         where cli.cli_emp_n_codigo == idEmp || emp.emp_c_cnpj == model.emp_c_cnpj
                         orderby cli.cli_c_nomeFantasia
                         select new ClienteViewModel()
                         {
                             cli_c_nomeFantasia = cli.cli_c_nomeFantasia.ToUpper(),
                             cli_c_cnpj = cli.cli_c_cnpj,
                             Cidade = cid.cid_c_nome.ToUpper(),
                             Estado = est.est_c_sigla.ToUpper(),
                             cli_d_inicioContrato = (cli.cli_d_inicioContrato != null ? cli.cli_d_inicioContrato.Value.ToString("MM/dd/yyyy HH:mm") : ""),
                             cli_c_telefoneComercial = cli.cli_c_telefoneComercial,
                             Empresa = emp.emp_c_nomeFantasia

                         }).ToList();

            return query;
        }

        public List<ClienteViewModel> GetRelClientesLicenca(ClienteViewModel model)
        {
            int idEmp = Convert.ToInt32(model.emp_n_codigo);
            var query = new List<ClienteViewModel>();
            if (model.cli_n_codigo != null || model.emp_n_codigo != null)
            {
                if (model.cli_n_codigo != null)
                {
                    int idCli = Convert.ToInt32(model.cli_n_codigo);
                    query = (from cli in context.tb_cli_cliente
                             join emp in Context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                             join cid in Context.tb_cid_cidade on cli.cli_cid_n_codigo equals cid.cid_n_codigo
                             join est in Context.tb_est_estado on cli.cli_est_n_codigo equals est.est_n_codigo
                             join mol in Context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                             where cli.cli_n_codigo == idCli
                             orderby cli.cli_c_nomeFantasia
                             select new ClienteViewModel()
                             {
                                 cli_c_nomeFantasia = cli.cli_c_nomeFantasia.ToUpper(),
                                 cli_c_cnpj = cli.cli_c_cnpj,
                                 Cidade = cid.cid_c_nome.ToUpper(),
                                 Estado = est.est_c_sigla.ToUpper(),
                                 cli_d_inicioContrato = cli.cli_d_inicioContrato.ToString(),
                                 cli_c_telefoneComercial = cli.cli_c_telefoneComercial,
                                 cli_d_dataVencimentoLicenca = (cli.cli_d_dataVencimentoLicenca != null ? cli.cli_d_dataVencimentoLicenca.Value.ToString("MM/dd/yyyy HH:mm") : ""),
                                 cli_n_valorLicenca = cli.cli_n_valorLicenca.ToString(),
                                 mol_b_controleDeAcesso = (mol.mol_b_controleDeAcesso != null ? ((mol.mol_b_controleDeAcesso != null ? mol.mol_b_controleDeAcesso : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_MonitoriamentoPerimetral = (mol.mol_b_MonitoriamentoPerimetral != null ? ((mol.mol_b_MonitoriamentoPerimetral != null ? mol.mol_b_MonitoriamentoPerimetral : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_CFTV = (mol.mol_b_CFTV != null ? ((mol.mol_b_CFTV != null ? mol.mol_b_CFTV : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_OrdemServico = (mol.mol_b_OrdemServico != null ? ((mol.mol_b_OrdemServico != null ? mol.mol_b_OrdemServico : false) == true ? "SIM" : "NÃO") : ""),
                                 Empresa = emp.emp_c_nomeFantasia

                             }).ToList();
                }
                else
                {
                    query = (from cli in context.tb_cli_cliente
                             join emp in Context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                             join cid in Context.tb_cid_cidade on cli.cli_cid_n_codigo equals cid.cid_n_codigo
                             join est in Context.tb_est_estado on cli.cli_est_n_codigo equals est.est_n_codigo
                             join mol in Context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                             where emp.emp_n_codigo == idEmp
                             orderby cli.cli_c_nomeFantasia
                             select new ClienteViewModel()
                             {
                                 cli_c_nomeFantasia = cli.cli_c_nomeFantasia.ToUpper(),
                                 cli_c_cnpj = cli.cli_c_cnpj,
                                 Cidade = cid.cid_c_nome.ToUpper(),
                                 Estado = est.est_c_sigla.ToUpper(),
                                 cli_d_inicioContrato = cli.cli_d_inicioContrato.ToString(),
                                 cli_c_telefoneComercial = cli.cli_c_telefoneComercial,
                                 cli_d_dataVencimentoLicenca = (cli.cli_d_dataVencimentoLicenca != null ? cli.cli_d_dataVencimentoLicenca.Value.ToString("MM/dd/yyyy HH:mm") : ""),
                                 cli_n_valorLicenca = cli.cli_n_valorLicenca.ToString(),
                                 mol_b_controleDeAcesso = (mol.mol_b_controleDeAcesso != null ? ((mol.mol_b_controleDeAcesso != null ? mol.mol_b_controleDeAcesso : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_MonitoriamentoPerimetral = (mol.mol_b_MonitoriamentoPerimetral != null ? ((mol.mol_b_MonitoriamentoPerimetral != null ? mol.mol_b_MonitoriamentoPerimetral : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_CFTV = (mol.mol_b_CFTV != null ? ((mol.mol_b_CFTV != null ? mol.mol_b_CFTV : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_OrdemServico = (mol.mol_b_OrdemServico != null ? ((mol.mol_b_OrdemServico != null ? mol.mol_b_OrdemServico : false) == true ? "SIM" : "NÃO") : ""),
                                 Empresa = emp.emp_c_nomeFantasia

                             }).ToList();
                }

            }
            else
            {
                query = (from cli in context.tb_cli_cliente
                         join emp in Context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                         join cid in Context.tb_cid_cidade on cli.cli_cid_n_codigo equals cid.cid_n_codigo
                         join est in Context.tb_est_estado on cli.cli_est_n_codigo equals est.est_n_codigo
                         join mol in Context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                         orderby cli.cli_c_nomeFantasia
                         select new ClienteViewModel()
                         {
                             cli_c_nomeFantasia = cli.cli_c_nomeFantasia.ToUpper(),
                             cli_c_cnpj = cli.cli_c_cnpj,
                             Cidade = cid.cid_c_nome.ToUpper(),
                             Estado = est.est_c_sigla.ToUpper(),
                             cli_d_inicioContrato = cli.cli_d_inicioContrato.ToString(),
                             cli_c_telefoneComercial = cli.cli_c_telefoneComercial,
                             cli_d_dataVencimentoLicenca = (cli.cli_d_dataVencimentoLicenca != null ? cli.cli_d_dataVencimentoLicenca.Value.ToString("MM/dd/yyyy HH:mm") : ""),
                             cli_n_valorLicenca = cli.cli_n_valorLicenca.ToString(),
                             mol_b_controleDeAcesso = (mol.mol_b_controleDeAcesso != null ? ((mol.mol_b_controleDeAcesso != null ? mol.mol_b_controleDeAcesso : false) == true ? "SIM" : "NÃO") : ""),
                             mol_b_MonitoriamentoPerimetral = (mol.mol_b_MonitoriamentoPerimetral != null ? ((mol.mol_b_MonitoriamentoPerimetral != null ? mol.mol_b_MonitoriamentoPerimetral : false) == true ? "SIM" : "NÃO") : ""),
                             mol_b_CFTV = (mol.mol_b_CFTV != null ? ((mol.mol_b_CFTV != null ? mol.mol_b_CFTV : false) == true ? "SIM" : "NÃO") : ""),
                             mol_b_OrdemServico = (mol.mol_b_OrdemServico != null ? ((mol.mol_b_OrdemServico != null ? mol.mol_b_OrdemServico : false) == true ? "SIM" : "NÃO") : ""),
                             Empresa = emp.emp_c_nomeFantasia

                         }).ToList();
            }
            return query;
        }

        public List<ClienteViewModel> getClienteCnpj(ClienteViewModel model)
        {
            var query = (from cli in context.tb_cli_cliente
                         join emp in Context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                         join cid in Context.tb_cid_cidade on cli.cli_cid_n_codigo equals cid.cid_n_codigo
                         join est in Context.tb_est_estado on cli.cli_est_n_codigo equals est.est_n_codigo
                         where cli.cli_c_cnpj == model.cli_c_cnpj
                         select new ClienteViewModel()
                         {
                             cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                             cli_n_codigo = cli.cli_n_codigo.ToString(),
                             cli_emp_n_codigo = emp.emp_n_codigo.ToString()
                         }).ToList();


            return query;
        }

        public object InsertOrUpdate(ClienteViewModel model)
        {
            try
            {
                Retorno retorno = new Retorno();

                int codEmp = Convert.ToInt32(model.cli_emp_n_codigo);
                int codCli = Convert.ToInt32(model.cli_n_codigo);

                var duplicado = VerificaDuplicado(model);

                if (!String.IsNullOrEmpty(duplicado))
                {
                    retorno.conteudo = duplicado;
                    return retorno;
                }

                if (model.cli_c_ramais != "")
                {
                    retorno = validaRamais(model.cli_c_ramais, codCli, codEmp);

                    if (retorno.status == "RAMAL_DUPLICADO" || retorno.status == "RAMAL_INVALIDO")
                    {
                        return retorno;
                    }
                }

                tb_cli_cliente cliente;

                string dataInclusao = model.cli_d_inclusao;
                if (!string.IsNullOrEmpty(model.cli_d_inclusao))
                {
                    var dataSplit = model.cli_d_inclusao.Split("/");
                    if (dataSplit.Length == 3)
                    {
                        dataInclusao = $"{dataSplit[2]}/{dataSplit[1]}/{dataSplit[0]}";
                    }
                }

                DateTime.TryParse(dataInclusao, out DateTime _dataInclusao);

                if (codCli == 0)
                {
                    cliente = new tb_cli_cliente()
                    {
                        cli_b_ativo = false,
                        cli_emp_n_codigo = codEmp,
                        cli_c_codigoReferencia = model.cli_c_codigoReferencia,
                        cli_tcl_n_codigo = Convert.ToInt32(model.cli_tcl_n_codigo),
                        cli_c_razaoSocial = model.cli_c_razaoSocial,
                        cli_c_nomeFantasia = model.cli_c_nomeFantasia,
                        cli_d_inicioContrato = _dataInclusao,
                        cli_c_cnpj = model.cli_c_cnpj,
                        cli_c_ie = model.cli_c_ie,
                        cli_c_pessoaContato = model.cli_c_pessoaContato,
                        cli_c_email = model.cli_c_email,
                        cli_c_email2 = model.cli_c_email2,
                        cli_c_telefoneComercial = model.cli_c_telefoneComercial,
                        cli_c_telefoneComercial2 = model.cli_c_telefoneComercial2,
                        cli_c_celular = model.cli_c_celular,
                        cli_c_celular2 = model.cli_c_celular2,
                        cli_c_cep = model.cli_c_cep,
                        cli_c_rua = model.cli_c_rua,
                        cli_c_numero = model.cli_c_numero,
                        cli_c_complemento = model.cli_c_complemento,
                        cli_c_bairro = model.cli_c_bairro,
                        cli_c_observacao = model.cli_c_observacao,
                        cli_est_n_codigo = Convert.ToInt32(model.cli_est_n_codigo),
                        cli_cid_n_codigo = Convert.ToInt32(model.cli_cid_n_codigo),
                        cli_can_n_panoramica = Convert.ToInt32(model.cli_can_n_panoramica),
                        cli_c_fantasiaAdministradora = model.cli_c_fantasiaAdministradora,
                        cli_c_pessoaContatoAdministradora = model.cli_c_pessoaContatoAdministradora,
                        cli_c_emailAdministradora = model.cli_c_emailAdministradora,
                        cli_c_telefoneAdministradora = model.cli_c_telefoneAdministradora,
                        cli_c_celularAdministradora = model.cli_c_celularAdministradora,
                        cli_mol_n_codigo = Convert.ToInt32(model.Modulo.mol_n_codigo),
                        cli_c_ramais = model.cli_c_ramais,
                        cli_c_dominioSIP = model.cli_c_dominioSIP,
                        cli_c_portaSIP = model.cli_c_portaSIP,
                        cli_c_senhaSIP = model.cli_c_senhaSIP,
                        cli_c_emailSegTrabalho = model.cli_c_emailSegTrabalho,
                        cli_c_ramalPortaria = model.cli_c_ramalPortaria,

                        cli_c_tituloInstitucional = model.cli_c_tituloInstitucional,
                        cli_c_descricaoInstitucional = model.cli_c_descricaoInstitucional,

                        cli_c_unique = Guid.NewGuid(),
                        cli_d_alteracao = DateTime.Now,
                        cli_d_atualizado = DateTime.Now,
                        cli_d_dataCriacao = DateTime.Now,

                        // App
                        cli_c_senhaAppGarenConnect = model.Modulo.mol_b_connectGaren ? model.cli_c_senhaAppGarenConnect : string.Empty,
                        cli_lay_n_codigo = Convert.ToInt32(model.cli_lay_n_codigo),

                    };

                    Insert(cliente);

                    context.SaveChanges();

                    Localidade.Vincular(cliente.cli_n_codigo);
                    ZeladorCliente.Vincular(cliente.cli_n_codigo);
                    DispositivoCFTV.Vincular(cliente.cli_n_codigo);
                    EquipamentoCliente.Vincular(cliente.cli_n_codigo);
                    MotivoOcorrencia.Vincular(cliente.cli_n_codigo);
                    VigilanteCliente.Vincular(cliente.cli_n_codigo);
                    MotivoOcorrencia.Vincular(cliente.cli_n_codigo);
                    Layout.Vincular(cliente.cli_n_codigo);
                    MapeamentoPontoAcesso.Vincular(cliente.cli_n_codigo);
                    DuvidasAppCliente.Vincular(cliente.cli_n_codigo);
                    context.SaveChanges();

                    Licenca.MontaEmailNovoCliente(); //envia email para agente comercial e adm (ativação licença)
                }
                else
                {
                    cliente = (from _cliente in context.tb_cli_cliente where _cliente.cli_n_codigo == codCli select _cliente).FirstOrDefault();

                    cliente.cli_b_ativo = Convert.ToBoolean(model.cli_b_ativo);
                    cliente.cli_emp_n_codigo = codEmp;
                    cliente.cli_c_codigoReferencia = model.cli_c_codigoReferencia;
                    cliente.cli_tcl_n_codigo = Convert.ToInt32(model.cli_tcl_n_codigo);
                    cliente.cli_c_razaoSocial = model.cli_c_razaoSocial;
                    cliente.cli_c_nomeFantasia = model.cli_c_nomeFantasia;
                    cliente.cli_d_inicioContrato = Convert.ToDateTime(model.cli_d_inicioContrato);
                    cliente.cli_c_cnpj = model.cli_c_cnpj;
                    cliente.cli_c_ie = model.cli_c_ie;
                    cliente.cli_c_pessoaContato = model.cli_c_pessoaContato;
                    cliente.cli_c_email = model.cli_c_email;
                    cliente.cli_c_email2 = model.cli_c_email2;
                    cliente.cli_c_telefoneComercial = model.cli_c_telefoneComercial;
                    cliente.cli_c_telefoneComercial2 = model.cli_c_telefoneComercial2;
                    cliente.cli_c_celular = model.cli_c_celular;
                    cliente.cli_c_celular2 = model.cli_c_celular2;
                    cliente.cli_c_cep = model.cli_c_cep;
                    cliente.cli_c_rua = model.cli_c_rua;
                    cliente.cli_c_numero = model.cli_c_numero;
                    cliente.cli_c_complemento = model.cli_c_complemento;
                    cliente.cli_c_bairro = model.cli_c_bairro;
                    cliente.cli_c_observacao = model.cli_c_observacao;
                    cliente.cli_est_n_codigo = Convert.ToInt32(model.cli_est_n_codigo);
                    cliente.cli_cid_n_codigo = Convert.ToInt32(model.cli_cid_n_codigo);
                    cliente.cli_can_n_panoramica = Convert.ToInt32(model.cli_can_n_panoramica);
                    cliente.cli_c_fantasiaAdministradora = model.cli_c_fantasiaAdministradora;
                    cliente.cli_c_pessoaContatoAdministradora = model.cli_c_pessoaContatoAdministradora;
                    cliente.cli_c_emailAdministradora = model.cli_c_emailAdministradora;
                    cliente.cli_c_telefoneAdministradora = model.cli_c_telefoneAdministradora;
                    cliente.cli_c_celularAdministradora = model.cli_c_celularAdministradora;
                    cliente.cli_mol_n_codigo = Convert.ToInt32(model.Modulo.mol_n_codigo);
                    cliente.cli_c_ramais = model.cli_c_ramais;
                    cliente.cli_c_dominioSIP = model.cli_c_dominioSIP;
                    cliente.cli_c_portaSIP = model.cli_c_portaSIP;
                    cliente.cli_c_senhaSIP = model.cli_c_senhaSIP;
                    cliente.cli_c_ramalPortaria = model.cli_c_ramalPortaria;
                    cliente.cli_d_alteracao = DateTime.Now;
                    cliente.cli_d_atualizado = DateTime.Now;
                    cliente.cli_c_emailSegTrabalho = model.cli_c_emailSegTrabalho;

                    cliente.cli_c_tituloInstitucional = model.cli_c_tituloInstitucional;
                    cliente.cli_c_descricaoInstitucional = model.cli_c_descricaoInstitucional;

                    // App
                    cliente.cli_c_senhaAppGarenConnect = model.Modulo.mol_b_connectGaren ? model.cli_c_senhaAppGarenConnect : string.Empty;
                    cliente.cli_lay_n_codigo = Convert.ToInt32(model.cli_lay_n_codigo);

                    Update(cliente);

                    // Licenca.MontaEmailAlteracaoCliente(model);

                }
                context.SaveChanges();

                retorno.id = cliente.cli_n_codigo;
                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;

            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.ToString(), "ArquivoLog");
            }
            return false;
        }

        public string VerificaDuplicado(ClienteViewModel model)
        {
            string retorno = "";

            List<tb_cli_cliente> listaCnpj = context.tb_cli_cliente.Where(x => x.cli_c_cnpj == model.cli_c_cnpj && x.cli_n_codigo != Convert.ToInt32(model.cli_n_codigo)).ToList();
            List<tb_cli_cliente> listaEmail = context.tb_cli_cliente.Where(x => x.cli_c_email == model.cli_c_email && x.cli_n_codigo != Convert.ToInt32(model.cli_n_codigo)).ToList();

            if (listaCnpj.Count() > 0)
            {
                retorno = "CNPJ_DUPLICADO";
                return retorno;
            }
            else if (listaEmail.Count() > 0)
            {
                retorno = "EMAIL_DUPLICADO";
                return retorno;
            }
            else
            {
                return retorno;
            }
        }

        public byte[] GeraExcel(ClienteFilterModel filter)
        {
            var query = ObterQueryClientesFiltrados(filter, true);
            var listaEmpresas = query.ToList();

            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Razão Social",
                    "Nome Fantasia",
                    "CNPJ",
                    "Empresa",
                    "Estado",
                    "Cidade",
                    "Status",
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
                        worksheet.Cells["A" + j].Value = empresa.cli_n_codigo;
                        worksheet.Cells["B" + j].Value = empresa.cli_c_razaoSocial.ToUpper();
                        worksheet.Cells["C" + j].Value = empresa.cli_c_nomeFantasia.ToUpper();
                        worksheet.Cells["D" + j].Value = empresa.cli_c_cnpj;
                        worksheet.Cells["E" + j].Value = empresa.Empresa.ToUpper();
                        worksheet.Cells["F" + j].Value = empresa.Estado.ToUpper();
                        worksheet.Cells["G" + j].Value = empresa.Cidade.ToUpper();
                        worksheet.Cells["H" + j].Value = empresa.Status.ToUpper();
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

        public object GerarCodigoReferencia()
        {
            Retorno retorno = new Retorno();
            try
            {
                Random gerarCodigoReferencia = new Random();
                string conjuntoCaracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string codigoReferencia = "";
                string codigoReferenciaFinal = "";
                int qtde = 0;
                int valorRandom = 0;

                bool reprovado = true;

                while (reprovado)
                {
                    codigoReferenciaFinal = "";
                    codigoReferencia = "";
                    valorRandom = 0;

                    //1º Gera o código
                    for (int count = 0; count <= 2; count++)
                    {
                        valorRandom = gerarCodigoReferencia.Next(0, 25);
                        codigoReferencia += conjuntoCaracteres[valorRandom].ToString();
                        codigoReferencia += gerarCodigoReferencia.Next(0, 9).ToString();
                    }

                    //2º Sorteia os caracteres
                    valorRandom = 0;
                    for (int count = 0; count <= 5; count++)
                    {
                        qtde = codigoReferencia.Length;
                        valorRandom = gerarCodigoReferencia.Next(0, qtde);
                        codigoReferenciaFinal += codigoReferencia[valorRandom].ToString();
                        codigoReferencia = codigoReferencia.Remove(valorRandom, 1);
                    }


                    int qtdexistente = (from cli in Context.tb_cli_cliente where cli.cli_c_codigoReferencia == codigoReferenciaFinal select cli).Count();

                    if (qtdexistente == 0)
                    {
                        reprovado = false;
                    }
                }
                retorno.status = "ok";
                retorno.conteudo = codigoReferenciaFinal;

                return retorno;
            }
            catch (Exception erro)
            {
                retorno.status = "error";
                retorno.conteudo = "false";
                return retorno;

            }

        }

        public bool DeletarCliente(int id)
        {
            try
            {
                Delete(context.tb_cli_cliente.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Retorno validaRamais(string ramais, int codCli, int codEmp)
        {
            Retorno retorno = new Retorno();
            List<string> ListaRamaisAtual = new List<string>();
            List<string> listaRamaisBaseDados = new List<string>();
            List<tb_cli_cliente> ListaClientes = new List<tb_cli_cliente>();
            tb_emp_empresa onjEmpresa = new tb_emp_empresa();
            bool duplicado = false;

            onjEmpresa = (from emp in Context.tb_emp_empresa where emp.emp_n_codigo == codEmp select emp).FirstOrDefault();
            string range_ramais = onjEmpresa.emp_c_RangeRamais;
            string range_ramais_invalidos = "";
            string valor = "";

            if (ramais != null && ramais != "")
            {
                ListaClientes = (from cli in Context.tb_cli_cliente where cli.cli_n_codigo != codCli && cli.cli_emp_n_codigo == codEmp select cli).ToList();


                foreach (var item in ramais.Split(','))
                {
                    ListaRamaisAtual.Add(item);
                }
                foreach (var item in ListaClientes)
                {
                    if (!string.IsNullOrEmpty(item.cli_c_ramais))
                    {

                        foreach (var i in item.cli_c_ramais.Split(','))
                        {
                            listaRamaisBaseDados.Add(i);
                        }
                    }
                }
                foreach (var item in ListaRamaisAtual)
                {

                    foreach (var ramal in listaRamaisBaseDados)
                    {
                        if (item == ramal && ramal != "")
                        {
                            duplicado = true;
                            valor = item;
                        }
                    }
                }
                if (duplicado)
                {
                    retorno.status = "RAMAL_DUPLICADO";
                    retorno.conteudo = valor;
                    return retorno;
                }
                string range_valores_inseridos = ramais;

                if (range_ramais != null && range_ramais != "")
                    range_ramais_invalidos = validaRangeRamais(range_ramais, range_valores_inseridos);

                if (range_ramais_invalidos != "")
                {

                    retorno.status = "RAMAL_INVALIDO";
                    retorno.conteudo = range_ramais_invalidos;
                    return retorno;
                }

            }
            retorno.status = "VALIDO";
            retorno.conteudo = "true";
            return retorno;
        }

        private string validaRangeRamais(string range_ramais, string range_valores_inseridos)
        {
            string retorno = "";

            string[] intervalo = range_ramais.Split('-');
            string ramais_invalidos = "";
            foreach (var item in range_valores_inseridos.Split(','))
            {
                if (item == "")
                    continue;
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

        public object UpdateLicenca(ClienteViewModel model, string usuarioLogado)
        {
            Retorno retorno = new Retorno();
            ParametrosEmpresaViewModel parametro = new ParametrosEmpresaViewModel();
            try
            {
                bool enviaEmail = false;
                int codCli = Convert.ToInt32(model.cli_n_codigo);
                int codMol = Convert.ToInt32(model.cli_mol_n_codigo);
                bool statusCli = Convert.ToBoolean(model.cli_b_ativo);
                int idPerfil = 1; //-Provisório até conseguir o perfil
                string ativadoInativado = statusCli == true ? "ativado" : "inativado";

                if (codCli != 0)
                {
                    var cli = (from cliente in context.tb_cli_cliente where cliente.cli_n_codigo == codCli select cliente).FirstOrDefault();

                    if (cli.cli_b_ativo != statusCli)
                    {
                        //E diferente do que esta na base, sendo assim entendemos que a Iconnect entrou e modificou o registro.
                        enviaEmail = true;
                    }

                    cli.cli_d_modificacao = DateTime.Now;
                    cli.cli_n_valorLicenca = Convert.ToDecimal(model.cli_n_valorLicenca);
                    cli.cli_d_dataVencimentoLicenca = Convert.ToDateTime(model.cli_d_dataVencimentoLicenca);
                    cli.cli_d_inicioLicenca = Convert.ToDateTime(model.cli_d_inicioLicenca);
                    cli.cli_n_diaVencimento = Convert.ToInt32(model.cli_n_diaVencimento);
                    cli.cli_b_ativo = statusCli;
                    cli.cli_c_range_periodo_aplicadorTicket = model.cli_c_range_periodo_aplicadorTicket;
                    cli.cli_b_free = model.cli_b_freeLicença;
                    cli.cli_d_atualizado = DateTime.Now;
                    Update(cli);
                }
                context.SaveChanges();

                if (idPerfil == 1 && idPerfil != 0)
                {
                    Modulo.InsertOrUpdate(model.Modulo);
                }

                if (enviaEmail == true)
                {
                    var status = statusCli ? "Ativo" : "Inativo";
                    int codEmp = Convert.ToInt32(model.cli_emp_n_codigo);
                    var empresa = (from emp in Context.tb_emp_empresa where emp.emp_n_codigo == codEmp select emp).FirstOrDefault();
                    string tituloAssunto = ativadoInativado == "ativado" ? "ATIVAÇÃO" : "INATIVAÇÃO";

                    ParametrosEmpresaViewModel paremp = new ParametrosEmpresaViewModel();
                    EmailViewModel modelEma = new EmailViewModel();

                    paremp.par_c_chave = "DESTINATARIO_CLIENTE";

                    modelEma.ema_b_enviado = false;
                    modelEma.ema_c_assunto = $"{tituloAssunto} CLIENTE | " + model.cli_c_nomeFantasia;
                    modelEma.ema_c_corpo = LiberacaoClienteAtivo(empresa.emp_c_nomeFantasia, model.cli_c_nomeFantasia, model.cli_c_cnpj, DateTime.Now, ativadoInativado);
                    paremp.par_emp_n_codigo = codEmp;
                    parametro = Parametros.FindParametrosEmpresa(paremp);
                    modelEma.ema_c_destinatario = parametro.par_c_valor;
                    modelEma.ema_c_copiaOculta = "";
                    modelEma.ema_d_data = DateTime.Now;
                    modelEma.ema_c_copiaOculta = "";
                    modelEma.ema_b_enviado = false;
                    modelEma.ema_d_modificacao = DateTime.Now;

                    Email.InsertOrUpdate(modelEma);

                }

                retorno.status = "ok";
                retorno.conteudo = "true";

                return retorno;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        private string LiberacaoClienteAtivo(string emp_c_nomeFantasia, string cli_c_nomeFantasia, string cli_c_cnpj, DateTime data, string statusCli)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\Iconnect.Aplicacao\\Template\\EmailClienteAtivo.html";
                var caminhoArquivoAnterior = path.Replace("\\iconnect-portal", "");
                using FileStream fs = File.Open(caminhoArquivoAnterior, FileMode.Open, FileAccess.Read, FileShare.Read);

                StreamReader reader = new StreamReader(fs);
                StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());

                CorpoEmail = CorpoEmail
                    .Replace("{Empresa}", emp_c_nomeFantasia)
                    .Replace("{mensagem}", @$"Um cliente foi <b>{statusCli}</b> dentre as suas licenças. <BR><BR>" +
                                             "<b>Cliente:</b> " + cli_c_nomeFantasia + " - " + " CNPJ: " + cli_c_cnpj + "<BR><BR>" +
                                            "<b>Data:</b> " + Convert.ToDateTime(data).ToString("dd/MM/yyyy HH:mm") + "<BR><BR>");


                return CorpoEmail.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public object SalvarSerial(ClienteViewModel model)
        {
            Retorno retorno = new Retorno();
            try
            {
                string serial = "";
                int codCli = Convert.ToInt32(model.cli_n_codigo);
                if (codCli != 0)
                {
                    var cli = (from cliente in context.tb_cli_cliente where cliente.cli_n_codigo == codCli select cliente).FirstOrDefault();

                    cli.cli_c_codInstalacaoOffline = model.cli_c_codInstalacaoOffline.ToUpper();
                    cli.cli_n_numDiasExpiracao = Convert.ToInt32(model.cli_n_numDiasExpiracao);
                    cli.cli_c_serial = Seguranca.getSerial(model.cli_c_codInstalacaoOffline, Convert.ToInt32(model.cli_n_numDiasExpiracao)).ToUpper();
                    cli.cli_d_dataCriacao = Seguranca.getDataCriacao(model.cli_c_codInstalacaoOffline, cli.cli_c_serial);
                    cli.cli_d_dataExpiracao = Seguranca.getDataExpiracao(model.cli_c_codInstalacaoOffline, cli.cli_c_serial);
                    cli.cli_b_free = model.cli_b_freeLicença;
                    Update(cli);

                    serial = cli.cli_c_serial;
                }
                context.SaveChanges();
                retorno.status = "gerado";
                retorno.conteudo = serial;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = "error";
                retorno.status = "ERROR";

                return retorno;
            }
        }

        public bool RemoverLicenca(int id)
        {
            try
            {
                if (id != 0)
                {
                    var cli = (from cliente in context.tb_cli_cliente where cliente.cli_n_codigo == id select cliente).FirstOrDefault();

                    cli.cli_d_dataVencimentoLicenca = null;
                    cli.cli_d_inicioLicenca = null;
                    cli.cli_c_serial = null;
                    cli.cli_b_free = false;
                    cli.cli_n_diaVencimento = null;
                    cli.cli_n_numDiasExpiracao = null;
                    cli.cli_n_valorLicenca = null;
                    cli.cli_b_ativo = false;
                    cli.cli_c_codInstalacaoOffline = null;
                    cli.cli_d_modificacao = DateTime.Now;
                    cli.cli_d_atualizado = DateTime.Now;
                    cli.cli_c_range_periodo_aplicadorTicket = null;
                    Update(cli);

                    var mol = (from modulos in context.tb_mol_modulosLiberados where modulos.mol_n_codigo == cli.cli_mol_n_codigo select modulos).FirstOrDefault();
                    mol.mol_b_portariaVirtual = false;
                    mol.mol_b_MonitoriamentoPerimetral = false;
                    mol.mol_b_accessView = false;
                    mol.mol_b_connectSolutions = false;
                    mol.mol_b_connectGaren = false;
                    mol.mol_b_controleDeAcesso = false;
                    mol.mol_b_connectSync = false;
                    Modulo.Update(mol);

                }
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public int? getTipo(int id)
        {
            return (from cli in Context.tb_cli_cliente
                    where cli.cli_n_codigo == id
                    select cli.cli_tcl_n_codigo).FirstOrDefault();
        }

        public ClienteTipoFlagAcessoGratuitoViewModel GetTipo_FlagAcessoGratuito(int id, bool userIsAdmin = false)
        {
            return (from cli in Context.tb_cli_cliente
                    where cli.cli_n_codigo == id
                    select new ClienteTipoFlagAcessoGratuitoViewModel()
                    {
                        tipo = cli.cli_tcl_n_codigo,
                        acessoGratuito = userIsAdmin ? false : cli.cli_b_free
                    }).FirstOrDefault();
        }

        public bool? getModulo(int id)
        {
            bool valor = (from cli in Context.tb_cli_cliente
                          join mol in Context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                          where cli.cli_n_codigo == id
                          select mol.mol_b_connectGaren).FirstOrDefault();
            return valor;
        }

        public bool SalvaEmailSegTrabalho(ClienteViewModel model)
        {
            try
            {
                var cli = (from cliente in context.tb_cli_cliente where cliente.cli_n_codigo == Convert.ToInt32(model.cli_n_codigo) select cliente).FirstOrDefault();

                cli.cli_c_emailSegTrabalho = model.cli_c_emailSegTrabalho;
                cli.cli_d_alteracao = DateTime.Now;
                cli.cli_d_atualizado = DateTime.Now;

                Update(cli);

                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        private IQueryable<ClienteViewModel> ObterQueryClientesFiltrados(ClienteFilterModel filter, bool excel = false)
        {

            var query = (from cli in Context.tb_cli_cliente
                         join cid in Context.tb_cid_cidade on cli.cli_cid_n_codigo equals cid.cid_n_codigo
                         join est in Context.tb_est_estado on cli.cli_est_n_codigo equals est.est_n_codigo
                         join emp in Context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                         //Ordenação: Primeiro = Ativo, Segundo = Pendente Lib. e Terceiro = Inativo
                         orderby cli.cli_b_ativo == true ? "Primeiro" : cli.cli_d_inicioLicenca == null && cli.cli_b_ativo == false ? "Segundo" : "Terceiro", cli.cli_c_razaoSocial ascending
                         select new ClienteViewModel
                         {
                             cli_b_ativo = cli.cli_b_ativo.ToString(),
                             cli_est_n_codigo = cli.cli_est_n_codigo.ToString(),
                             cli_cid_n_codigo = cli.cli_cid_n_codigo.ToString(),
                             cli_c_bairro = cli.cli_c_bairro,
                             cli_c_celular = cli.cli_c_celular,
                             cli_c_celular2 = cli.cli_c_celular2,
                             cli_c_cep = cli.cli_c_cep,
                             cli_c_cnpj = cli.cli_c_cnpj,
                             cli_c_complemento = cli.cli_c_complemento,
                             cli_c_email = cli.cli_c_email,
                             cli_c_email2 = cli.cli_c_email2,
                             cli_c_ie = cli.cli_c_ie,
                             cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                             cli_c_numero = cli.cli_c_numero,
                             cli_c_observacao = cli.cli_c_observacao,
                             cli_c_pessoaContato = cli.cli_c_pessoaContato,
                             cli_c_ramais = cli.cli_c_ramais,
                             cli_c_razaoSocial = cli.cli_c_razaoSocial,
                             cli_c_rua = cli.cli_c_rua,
                             cli_c_unique = cli.cli_c_unique,
                             cli_c_usuario = cli.cli_c_usuario,
                             cli_d_alteracao = cli.cli_d_alteracao,
                             cli_mol_n_codigo = cli.cli_mol_n_codigo.ToString(),
                             cli_n_codigo = cli.cli_n_codigo.ToString(),
                             Estado = excel ? est.est_c_sigla : est.est_c_descricao + "-" + est.est_c_sigla,
                             Cidade = cid.cid_c_nome,
                             Empresa = emp.emp_c_nomeFantasia,
                             Status = cli.cli_b_ativo == true ? "ATIVO" : cli.cli_d_inicioLicenca == null && cli.cli_b_ativo == false ? "PENDENTE LIB." : "INATIVO",
                             buscaSimples = cli.cli_c_nomeFantasia + " " + " " + cli.cli_c_cnpj + " " + emp.emp_c_nomeFantasia + " " + emp.emp_c_cnpj
                         });

            if (!filter?.idsClientes?.Equals("todos") ?? false)
            {
                var ids = filter.idsClientes.Split(",");
                query = query.Where(w => ids.Contains(w.cli_n_codigo));
            }

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.cli_c_razaoSocial_filter))
            {
                query = query.Where(w => w.cli_c_razaoSocial.Contains(filter.cli_c_razaoSocial_filter));
            }

            if (!string.IsNullOrEmpty(filter.cli_c_nomeFantasia_filter))
            {
                query = query.Where(w => w.cli_c_nomeFantasia.Contains(filter.cli_c_nomeFantasia_filter));
            }

            if (!string.IsNullOrEmpty(filter.cli_c_cnpj_filter))
            {
                query = query.Where(w => w.cli_c_cnpj.Contains(filter.cli_c_cnpj_filter));
            }

            if (!string.IsNullOrEmpty(filter.empresa_filter))
            {
                query = query.Where(w => w.Empresa.Contains(filter.empresa_filter));
            }

            if (!string.IsNullOrEmpty(filter.estado_filter))
            {
                query = query.Where(w => w.Estado.Contains(filter.estado_filter));
            }

            if (!string.IsNullOrEmpty(filter.cidade_filter))
            {
                query = query.Where(w => w.Cidade.Contains(filter.cidade_filter));
            }

            if (!string.IsNullOrEmpty(filter.status_filter))
            {
                query = query.Where(w => w.Status.Equals(filter.status_filter.ToUpper()));
            }

            return query;
        }

        public ClienteViewModel GetClienteQR(int id)
        {
            return (from cli in context.tb_cli_cliente
                    where cli.cli_n_codigo == id
                    select new ClienteViewModel
                    {
                        cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                        cli_c_rua = cli.cli_c_rua,
                        cli_c_bairro = cli.cli_c_bairro,
                        cli_c_cep = cli.cli_c_cep,
                    }).FirstOrDefault();

        }

        public List<ClienteViewModel> getTipoEmpresarial()
        {
            var query = (from cli in context.tb_cli_cliente
                         where cli.cli_tcl_n_codigo == 2
                         select new ClienteViewModel
                         {
                             cli_n_codigo = cli.cli_n_codigo.ToString(),
                             cli_c_nomeFantasia = cli.cli_c_nomeFantasia

                         }).ToList();
            return query;
        }

        public List<ClienteViewModel> GetComboCliente(int idEmpresa)
        {
            //Se zero, lista todos clientes
            if (idEmpresa == 0)
            {
                return (from c in context.tb_cli_cliente
                        join emp in context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                        where c.cli_b_ativo == true
                        select new ClienteViewModel()
                        {
                            cli_n_codigo = c.cli_n_codigo.ToString(),
                            cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                            cli_emp_n_codigo = c.cli_emp_n_codigo.ToString(),
                        }).OrderBy(y => y.cli_c_nomeFantasia).ToList();
            }
            else
            {
                return (from c in context.tb_cli_cliente
                        join emp in context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                        where c.cli_b_ativo == true && c.cli_emp_n_codigo == idEmpresa
                        select new ClienteViewModel()
                        {
                            cli_n_codigo = c.cli_n_codigo.ToString(),
                            cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                        }).OrderBy(y => y.cli_c_nomeFantasia).ToList();
            }
        }

        public List<ClienteViewModel> FiltraCliente(string id)
        {
            var query = (from c in context.tb_cli_cliente
                         join emp in context.tb_emp_empresa on c.cli_emp_n_codigo equals emp.emp_n_codigo
                         where c.cli_b_ativo == true
                         select new ClienteViewModel()
                         {
                             cli_n_codigo = c.cli_n_codigo.ToString(),
                             cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                             cli_emp_n_codigo = c.cli_emp_n_codigo.ToString(),
                         });

            var ids = id.Split(",");
            query = query.Where(w => ids.Contains(w.cli_emp_n_codigo));

            return query.OrderBy(y => y.cli_c_nomeFantasia).ToList();
        }

        public ModuloViewModel GetModuloCliente(int id)
        {
            var query = (from cli in context.tb_cli_cliente
                         join mol in context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                         where cli.cli_n_codigo == id
                         select new ModuloViewModel()
                         {
                             mol_b_controleDeAcesso = mol.mol_b_controleDeAcesso.ToString(),
                             mol_b_MonitoriamentoPerimetral = mol.mol_b_MonitoriamentoPerimetral.ToString(),
                             mol_b_connectSolutions = mol.mol_b_connectSolutions.ToString(),
                         }).FirstOrDefault();
            return query;
        }

        public List<ClienteViewModel> GetClienteComercial(string ids)
        {
            var query = (from c in Context.tb_cli_cliente
                         where c.cli_b_ativo == true && c.cli_tcl_n_codigo == 3
                         select new ClienteViewModel()
                         {
                             cli_n_codigo = c.cli_n_codigo.ToString(),
                             cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                         }).OrderBy(y => y.cli_c_nomeFantasia).ToList();

            if (!string.IsNullOrEmpty(ids) && ids != "todos")
            {
                query = query.Where(x => ids.Split(',').Contains(x.cli_n_codigo))?.ToList();
            }

            return query;
        }

        public bool SalvarIdFotoFachada(ClienteViewModel model)
        {
            try
            {
                var cli = (from cliente in context.tb_cli_cliente where cliente.cli_n_codigo == Convert.ToInt32(model.cli_n_codigo) select cliente).FirstOrDefault();

                cli.cli_fot_fachada_n_codigo = Convert.ToInt32(model.cli_fot_fachada_n_codigo);
                cli.cli_d_alteracao = DateTime.Now;
                cli.cli_d_atualizado = DateTime.Now;

                Update(cli);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public List<ClienteViewModel> GetFotoFachada(int id)
        {
            var query = (from c in context.tb_cli_cliente
                         join f in context.tb_fot_foto on c.cli_fot_fachada_n_codigo equals f.fot_n_codigo
                         where c.cli_n_codigo == id && c.cli_fot_fachada_n_codigo != null
                         select new ClienteViewModel()
                         {
                             cli_n_codigo = c.cli_n_codigo.ToString(),
                             cli_c_nomeFantasia = c.cli_c_nomeFantasia,
                             cli_fot_fachada_n_codigo = c.cli_fot_fachada_n_codigo.ToString(),
                             fot_d_upload = Convert.ToDateTime(f.fot_d_upload).ToString("dd/MM/yyyy HH:mm")
                         }).ToList();

            return query;
        }

        public List<ClienteViewModel> GetComboRelMovimentacaoCliente(int id)
        {
            var listCliente = (from cli in context.tb_cli_cliente
                               join emp in context.tb_emp_empresa on cli.cli_emp_n_codigo equals emp.emp_n_codigo
                               where cli.cli_tcl_n_codigo == 2
                               && cli.cli_b_ativo == true
                               && cli.cli_emp_n_codigo == id
                               select new ClienteViewModel
                               {
                                   cli_n_codigo = cli.cli_n_codigo.ToString(),
                                   cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                                   cli_c_razaoSocial = cli.cli_c_razaoSocial,
                                   cli_tcl_n_codigo = cli.cli_tcl_n_codigo.ToString()
                               }).ToList();

            return listCliente;
        }
    }
}