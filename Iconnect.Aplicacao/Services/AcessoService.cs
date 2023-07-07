using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Exceptions;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class AcessoService : RepositoryBase<tb_ace_acesso>, IAcessoService
    {
        private IconnectCoreContext context;

        public AcessoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        List<string> clientes = new List<string>();

        public UsuarioViewModel Logar(string usuario, string senha)
        {
            var enc = Encoding.GetEncoding(0);
            var senhaCriptografada = CriptografarSenha(senha);
            var Ace = (from u in context.tb_ace_acesso
                       where u.ace_c_login.ToUpper() == usuario.ToUpper() &&
                       u.ace_c_senha.ToUpper() == senhaCriptografada.ToUpper()
                       select new tb_ace_acesso()
                       {
                           ace_per_n_codigo = u.ace_per_n_codigo,
                           tb_zec_zeladorCliente = (from z in context.tb_zec_zeladorCliente
                                                    where z.zec_ace_n_codigo == u.ace_n_codigo
                                                    select z).ToList(),
                           tb_pro_proprietario = (from p in context.tb_pro_proprietario
                                                  where p.pro_ace_n_codigo == u.ace_n_codigo
                                                  select p).ToList(),
                           tb_ope_operador = (from o in context.tb_ope_operador
                                              where o.ope_ace_n_codigo == u.ace_n_codigo
                                              select o).ToList(),
                           tb_emp_empresa = (from x in context.tb_emp_empresa
                                             where x.emp_n_codigo == u.ace_emp_n_codigo
                                             select x).FirstOrDefault(),
                           tb_dis_distribuidor = (from x in context.tb_dis_distribuidor
                                                  where x.dis_n_codigo == u.ace_dis_n_codigo
                                                  select x).FirstOrDefault(),
                           tb_grf_grupoFamiliar = (from x in context.tb_grf_grupoFamiliar
                                                   where x.grf_ace_n_codigo == u.ace_n_codigo
                                                   select x).ToList(),
                           tb_usc_usuarioSalaComercial = (from x in context.tb_usc_usuarioSalaComercial
                                                          where x.usc_ace_n_codigo == u.ace_n_codigo
                                                          select x).ToList(),
                           tb_age_agenteComercial = (from x in context.tb_age_agenteComercial
                                                     where x.age_ace_n_codigo == u.ace_n_codigo
                                                     select x).ToList(),

                           ace_n_codigo = u.ace_n_codigo,
                           ace_c_login = u.ace_c_login,
                           ace_c_senha = u.ace_c_senha
                       }).FirstOrDefault();

            var userInfos = new UsuarioViewModel();
            if (Ace != null)
                userInfos = GetUserInfos(Ace);

            var responsavelLocacao = context.tb_rel_responsavelLocacaoSaloes.Where(x => x.rel_c_login.ToUpper() == usuario.ToUpper() && x.rel_c_senha.ToUpper() == senhaCriptografada.ToUpper())?.FirstOrDefault();
            if (responsavelLocacao != null && Ace == null)
            {
                var permissoes = GetPermissoes(7);
                return userInfos = new UsuarioViewModel()
                {
                    idUsuario = responsavelLocacao.rel_n_codigo,
                    IdAcesso = responsavelLocacao.rel_n_codigo,
                    nomeUsuario = responsavelLocacao.rel_c_nome,
                    emailUsuario = responsavelLocacao.rel_c_email,
                    idsClientes = responsavelLocacao.rel_cli_n_codigo.ToString(),
                    Permissoes = permissoes,
                    PerfilResLoc = responsavelLocacao.rel_c_permissao,
                    Perfil = 7
                };
            }

            var operadorLocal = context.tb_opl_operadorLocal.Where(x => x.opl_c_login.ToUpper() == usuario.ToUpper() && x.opl_c_senha.ToUpper() == senhaCriptografada.ToUpper())?.FirstOrDefault();
            if (operadorLocal != null && Ace == null)
            {
                var permissoes = GetPermissoes(6);
                return userInfos = new UsuarioViewModel()
                {
                    idUsuario = operadorLocal.opl_n_codigo,
                    IdAcesso = operadorLocal.opl_n_codigo,
                    nomeUsuario = operadorLocal.opl_c_nome,
                    idsClientes = operadorLocal.opl_cli_n_codigo.ToString(),
                    Permissoes = ModulosOperadorLocal(ref permissoes, operadorLocal.opl_n_codigo),
                    PermissaoOpeLocal = GetPermissoesOperadorLocal(ref permissoes, operadorLocal.opl_n_codigo),
                    Perfil = 6,
                    PerfilResLoc = ObterPerfilResLocOpl(operadorLocal.opl_c_login, operadorLocal.opl_c_senha),
                };
            }

            return new UsuarioViewModel()
            {
                idUsuario = userInfos.idUsuario,
                IdAcesso = Ace?.ace_n_codigo,
                nomeUsuario = userInfos.nomeUsuario,
                emailUsuario = userInfos.emailUsuario,
                idEmpresa = userInfos.idEmpresa,
                idDistribuidor = userInfos.idDistribuidor,
                idsEmpresas = userInfos.idsEmpresas,
                idsClientes = userInfos.idsClientes,
                Permissoes = userInfos.Permissoes,
                Perfil = userInfos.Perfil,
                perfilOpe = userInfos.perfilOpe,
                PerfilResLoc = userInfos.PerfilResLoc,
                PermissoesEdicaoCliente = userInfos.PermissoesEdicaoCliente,
                solicitaRamalOperador = userInfos.solicitaRamalOperador
            };
        }

        public UsuarioViewModel Find(int id)
        {
            var Ace = (from u in context.tb_ace_acesso
                       where u.ace_n_codigo == id
                       select new tb_ace_acesso()
                       {
                           ace_per_n_codigo = u.ace_per_n_codigo,

                           tb_zec_zeladorCliente = (from z in context.tb_zec_zeladorCliente
                                                    where z.zec_ace_n_codigo == u.ace_n_codigo
                                                    select z).ToList(),
                           tb_pro_proprietario = (from p in context.tb_pro_proprietario
                                                  where p.pro_ace_n_codigo == u.ace_n_codigo
                                                  select p).ToList(),
                           tb_ope_operador = (from o in context.tb_ope_operador
                                              where o.ope_ace_n_codigo == u.ace_n_codigo
                                              select o).ToList(),
                           tb_grf_grupoFamiliar = (from o in context.tb_grf_grupoFamiliar
                                                   where o.grf_ace_n_codigo == u.ace_n_codigo
                                                   select o).ToList(),
                           tb_usc_usuarioSalaComercial = (from o in context.tb_usc_usuarioSalaComercial
                                                          where o.usc_ace_n_codigo == u.ace_n_codigo
                                                          select o).ToList(),
                           tb_age_agenteComercial = (from x in context.tb_age_agenteComercial
                                                     where x.age_ace_n_codigo == u.ace_n_codigo
                                                     select x).ToList(),
                       }).FirstOrDefault();

            var userInfos = new UsuarioViewModel();
            if (Ace != null)
            {
                userInfos = GetUserInfos(Ace);
            }
            else
            {
                var operadorLocal = context.tb_opl_operadorLocal.Where(x => x.opl_n_codigo == id)?.FirstOrDefault();
                if (operadorLocal != null)
                {
                    var permissoes = GetPermissoes(6);
                    return userInfos = new UsuarioViewModel()
                    {
                        idUsuario = operadorLocal.opl_n_codigo,
                        IdAcesso = operadorLocal.opl_n_codigo,
                        nomeUsuario = operadorLocal.opl_c_nome,
                        idsClientes = operadorLocal.opl_cli_n_codigo.ToString(),
                        Permissoes = ModulosOperadorLocal(ref permissoes, operadorLocal.opl_n_codigo),
                        PermissaoOpeLocal = GetPermissoesOperadorLocal(ref permissoes, operadorLocal.opl_n_codigo),
                        Perfil = 6,
                        PerfilResLoc = ObterPerfilResLocOpl(operadorLocal.opl_c_login, operadorLocal.opl_c_senha),
                    };
                }
            }

            return new UsuarioViewModel()
            {
                idUsuario = userInfos.idUsuario,
                IdAcesso = Ace?.ace_n_codigo,
                nomeUsuario = userInfos.nomeUsuario,
                emailUsuario = userInfos.emailUsuario ?? "",
                Permissoes = userInfos.Permissoes,
            };
        }

        private UsuarioViewModel GetUserInfos(tb_ace_acesso ace)
        {
            var resLoc = ObterPerfilResLoc(ace);
            var permissoes = GetPermissoes(ace.ace_per_n_codigo);
            if (ace?.tb_dis_distribuidor != null)
            {
                var distribuidor = ace?.tb_dis_distribuidor;
                var empresas = context.tb_emp_empresa.Where(x => x.emp_dis_n_codigo == distribuidor.dis_n_codigo && x.emp_b_ativo == true)?.Select(x => x.emp_n_codigo)?.ToList();
                var idsEmpresas = string.Join(',', empresas);
                return new UsuarioViewModel()
                {
                    idUsuario = distribuidor.dis_n_codigo,
                    idDistribuidor = distribuidor.dis_n_codigo,
                    nomeUsuario = distribuidor.dis_c_nomeFantasia,
                    emailUsuario = distribuidor.dis_c_email,
                    idsEmpresas = idsEmpresas,
                    Perfil = 11,
                    Permissoes = permissoes,
                    PerfilResLoc = "ADM"
                };
            }
            else if (ace?.tb_emp_empresa != null)
            {
                var empresa = ace?.tb_emp_empresa;
                var clientes = context.tb_cli_cliente.Where(x => x.cli_emp_n_codigo == empresa.emp_n_codigo)?.Select(x => x.cli_n_codigo)?.ToList();
                var idsClientes = string.Join(',', clientes);
                return new UsuarioViewModel()
                {
                    idUsuario = empresa.emp_n_codigo,
                    idEmpresa = empresa.emp_n_codigo,
                    nomeUsuario = empresa.emp_c_nomeFantasia,
                    emailUsuario = empresa.emp_c_email,
                    idsClientes = idsClientes,
                    Perfil = 2,
                    Permissoes = permissoes,
                    PerfilResLoc = "ADM"
                };
            }
            else if (ace?.tb_ope_operador?.Count() > 0)
            {
                var operador = ace?.tb_ope_operador.FirstOrDefault();
                ModuloPermitidosOperador(ref permissoes, operador.ope_mol_n_codigo ?? 0);
                var perfil = operador?.ope_emp_n_codigo == 0 || String.IsNullOrEmpty(operador?.ope_emp_n_codigo.ToString()) ? 8 : 5;

                if (clientes.Count == 0)
                {
                    foreach (var item in GetPermissoesCliente(operador?.ope_n_codigo).Split(","))
                    {
                        clientes.Add(item);
                    }
                }

                ValidaUsuarioInativo(operador.ope_b_ativoInativo ?? true);

                return new UsuarioViewModel
                {
                    idUsuario = operador?.ope_n_codigo,
                    nomeUsuario = operador?.ope_c_nome,
                    emailUsuario = operador?.ope_c_email,
                    idsClientes = GetPermissoesCliente(operador?.ope_n_codigo),
                    idsEmpresas = GetPermissoesEmpresa(operador?.ope_n_codigo),
                    idEmpresa = operador?.ope_emp_n_codigo,
                    Perfil = perfil,
                    Permissoes = PermissoesPerfil(ref permissoes),
                    perfilOpe = operador?.ope_pop_n_codigo,
                    PerfilResLoc = resLoc?.rel_c_permissao,
                    PermissoesEdicaoCliente = GetPermissoesEdicaoOperador(operador?.ope_n_codigo),
                    solicitaRamalOperador = Convert.ToBoolean(operador.ope_b_solicitaRamal)
                };
            }
            else if (ace?.tb_pro_proprietario?.Count() > 0)
            {
                var proprietario = ace?.tb_pro_proprietario.FirstOrDefault();
                return new UsuarioViewModel()
                {
                    idUsuario = proprietario.pro_n_codigo,
                    nomeUsuario = proprietario.pro_c_nome,
                    emailUsuario = proprietario.pro_c_email,
                    Perfil = 1,
                    idsClientes = "todos",
                    Permissoes = permissoes,
                    PerfilResLoc = "ADM"
                };
            }
            else if (ace?.tb_zec_zeladorCliente?.Count() > 0)
            {
                var zeladorCliente = ace?.tb_zec_zeladorCliente.FirstOrDefault();
                var cliente = context.tb_cli_cliente.Where(x => x.cli_n_codigo == zeladorCliente.zec_cli_n_codigo)?.FirstOrDefault();
         
                /*
                    ALTERAMOS O ID DO PERFIL QUANDO ADMINISTRADOR (NO CASO DOS PERFIS CADASTRADOS NO CLIENTE:
                    ADMINISTRADOR --> ID: 12
                    RESTANTE --> 4 (POR ENQUANTO)
                 */
                var perfil = getIdPerfilZec(zeladorCliente.zec_c_perfil);

                ValidaUsuarioInativo(cliente.cli_b_ativo ?? true);

                return new UsuarioViewModel()
                {
                    idUsuario = zeladorCliente.zec_n_codigo,
                    nomeUsuario = zeladorCliente.zec_c_nome,
                    emailUsuario = zeladorCliente.zec_c_email,
                    idsClientes = zeladorCliente.zec_cli_n_codigo.ToString(),
                    idEmpresa = cliente.cli_emp_n_codigo,
                    Perfil = perfil,
                    Permissoes = perfil == 12 ? ValidaPermissoesAdmCliente(permissoes, zeladorCliente.zec_cli_n_codigo) : permissoes,
                    PerfilResLoc = resLoc?.rel_c_permissao,
                    PermissoesEdicaoCliente = (getIdPerfilZec(zeladorCliente.zec_c_perfil) == 12 ? GetPermissoesEdicaoCliente(zeladorCliente.zec_cli_n_codigo) : null)
                };
            }
            else if (ace?.tb_grf_grupoFamiliar.Count() > 0)
            {
                var grupoFamiliar = ace?.tb_grf_grupoFamiliar.FirstOrDefault();
                var cli_emp_n_codigo = context.tb_cli_cliente.Where(x => x.cli_n_codigo == grupoFamiliar.grf_cli_n_codigo)?.Select(x => x.cli_emp_n_codigo)?.FirstOrDefault();

                return new UsuarioViewModel()
                {
                    idUsuario = grupoFamiliar.grf_n_codigo,
                    nomeUsuario = grupoFamiliar.grf_c_nomeResponsavel,
                    emailUsuario = grupoFamiliar.grf_c_email,
                    idsClientes = grupoFamiliar.grf_cli_n_codigo.ToString(),
                    Perfil = 4,
                    idEmpresa = cli_emp_n_codigo,
                    Permissoes = permissoes,
                    PerfilResLoc = "ADM"
                };
            }
            else if (ace?.tb_usc_usuarioSalaComercial.Count() > 0)
            {
                /*
                 PERMITE QUE O PERFIL DE ADM GERAL E INTEGRADORA TENHA ACESSO AS  ABAS DE "GERAL/ACESSO/CATALOGO"
                 SEPARAMOS OS PERFIS (9- 'ADM SALA COMERCIAL'| 10 - 'AGENDADOR') POR NIVEL DE PERMISSÕES:

                 TELA CADASRO DE SALA COMERCIAL
                 ADM:
                   -Edita Acessos
                   -Edita Catálogo
                   -Acessa Agenda (DASHBOARD)
                       AGENDADOR:
                   -Acessa Agenda (DASHBOARD)
               */
                var usuarioSala = ace?.tb_usc_usuarioSalaComercial.FirstOrDefault();
                var grupoF = context.tb_grf_grupoFamiliar.Where(x => x.grf_n_codigo == usuarioSala.usc_grf_n_codigo).FirstOrDefault();
                var cli_emp_n_codigo = context.tb_cli_cliente.Where(x => x.cli_n_codigo == grupoF.grf_cli_n_codigo)?.Select(x => x.cli_emp_n_codigo)?.FirstOrDefault();
                var perfil = getIdPerfil(usuarioSala.usc_c_perfil);
                return new UsuarioViewModel()
                {
                    idUsuario = grupoF.grf_n_codigo,
                    nomeUsuario = usuarioSala.usc_c_nome,
                    emailUsuario = grupoF.grf_c_email,
                    idsClientes = grupoF.grf_cli_n_codigo.ToString(),
                    Perfil = perfil,
                    idEmpresa = cli_emp_n_codigo,
                    Permissoes = GetPermissoes(perfil),
                    PerfilResLoc = "ADM"
                };
            }
            else if (ace?.tb_age_agenteComercial.Count() > 0)
            {
                var agente = ace?.tb_age_agenteComercial.FirstOrDefault();
                return new UsuarioViewModel()
                {
                    idUsuario = agente.age_n_codigo,
                    nomeUsuario = agente.age_c_nome,
                    emailUsuario = agente.age_c_email,
                    Perfil = 13,
                    idsClientes = "todos",
                    Permissoes = permissoes,
                    PerfilResLoc = "ADM"
                };
            }
            else
            {
                return new UsuarioViewModel() { idUsuario = 0, nomeUsuario = "" };
            }
        }

        private int? getIdPerfil(string usc_c_perfil)
        {
            int retorno = 9;
            try
            {
                if (usc_c_perfil == "AGENDADOR")
                {
                    retorno = 10;
                }
                else
                {
                    retorno = 9;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno;
            }
        }
        private int? getIdPerfilZec(string perfil)
        {
            int retorno = 4;
            try
            {
                if (perfil == "ADMINISTRADOR")
                {
                    retorno = 12;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno;
            }
        }
        private List<string> GetPermissoes(int? perfilId)
        {
            List<string> ret = new List<string>();

            ret.AddRange((from perPerfil in context.tb_per_per_perfilPermissionamento
                          join permissionamento in context.tb_per_permissionamento on perPerfil.per_u_n_codigo equals permissionamento.per_u_codigo
                          where perPerfil.per_n_codigo == perfilId
                          && permissionamento.per_b_ativo == true
                          select permissionamento.per_c_chave).ToList());

            ret.AddRange((from acePerfil in context.tb_ace_per_acessoPermissionamento
                          join permissionamento in context.tb_per_permissionamento on acePerfil.per_u_n_codigo equals permissionamento.per_u_codigo
                          where acePerfil.per_ace_n_codigo == perfilId
                          && permissionamento.per_b_ativo == true
                          select permissionamento.per_c_chave).ToList());

            return ret.Distinct().ToList();
        }

        private List<string> ModuloPermitidosOperador(ref List<string> permissoes, int ope_mol_n_codigo)
        {
            //Operador Módulos
            var modulosLiberados = context.tb_mol_modulosLiberados.Where(x => x.mol_n_codigo == ope_mol_n_codigo)?.FirstOrDefault();

            if (modulosLiberados != null)
            {
                if (!modulosLiberados.mol_b_connectSolutions)
                {
                    permissoes.Remove("ACESSAR_SOLUTION");
                };

                if (!modulosLiberados.mol_b_OrdemServico)
                {
                    permissoes.Remove("");
                };

                if (!modulosLiberados.mol_b_controleDeAcesso)
                {
                    permissoes.Remove("ACESSAR_ACCESS");
                };

                if (!modulosLiberados.mol_b_MonitoriamentoPerimetral)
                {
                    permissoes.Remove("ACESSAR_GUARD");
                };

                if (!modulosLiberados.mol_b_CFTV)
                {
                    permissoes.Remove("ACESSAR_VIEW");
                };
            }

            return permissoes;
        }

        private string GetPermissoesCliente(int? id)
        {
            List<string> ret = new List<string>();

            var temp = (from p in Context.tb_pec_permissaoCliente where p.pec_ope_n_codigo == id select p.pec_cli_n_codigo).ToList();

            var idsCli = string.Join(",", temp);

            return idsCli;
        }

        private string GetPermissoesEmpresa(int? id)
        {
            List<string> ret = new List<string>();

            var temp = (from p in Context.tb_pec_permissaoCliente
                        where p.pec_ope_n_codigo == id
                        join cli in Context.tb_cli_cliente on p.pec_cli_n_codigo equals cli.cli_n_codigo
                        select cli.cli_emp_n_codigo).ToList();

            var idsEmp = string.Join(",", temp.Distinct());

            return idsEmp;
        }

        private string CriptografarSenha(string senha)
        {
            var enc = Encoding.GetEncoding(0);
            byte[] buffer = enc.GetBytes(senha);
            var sha1 = SHA1.Create();
            var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }

        public AcessoViewModel InsertOrUpdate(AcessoViewModel model)
        {
            if (model == null) throw new MensagemException("Login e senha são obrigatórios.");

            string senhaCriptografada = "";

            var naoExiste = ValidaUsuario(model.ace_c_login, model.ace_n_codigo.ToString());

            if (!naoExiste) throw new MensagemException("O Login digitado já está sendo utilizado.");

            tb_ace_acesso tbAcesso = new tb_ace_acesso
            {
                ace_n_codigo = model.ace_n_codigo
            };


            if (model.ace_n_codigo == 0)
            {
                if (!string.IsNullOrEmpty(model.ace_c_senha))
                {
                    senhaCriptografada = CriptografarSenha(model.ace_c_senha);
                }

                int codEmp = Convert.ToInt32(model.ace_emp_n_codigo);
                tbAcesso.ace_c_senha = senhaCriptografada;
                tbAcesso.ace_c_login = model.ace_c_login;

                if (codEmp == 0)
                    tbAcesso.ace_emp_n_codigo = null;
                else
                    tbAcesso.ace_emp_n_codigo = codEmp;

                tbAcesso.ace_per_n_codigo = model.ace_per_n_codigo;
                tbAcesso.ace_b_relacional = model.ace_b_relacional;
                tbAcesso.ace_b_relacionalDist = model.ace_b_relacionalDist;
                tbAcesso.ace_d_atualizado = DateTime.Now;
                tbAcesso.ace_d_inclusao = DateTime.Now;
                tbAcesso.ace_c_unique = Guid.NewGuid();
                Insert(tbAcesso);
            }
            else
            {
                tbAcesso = (from ace in context.tb_ace_acesso where ace.ace_n_codigo == model.ace_n_codigo select ace)?.FirstOrDefault();

                if (!string.IsNullOrEmpty(model.ace_c_senha) && !model.ace_c_senha.Equals(tbAcesso.ace_c_senha))
                {
                    senhaCriptografada = CriptografarSenha(model.ace_c_senha);
                }

                if (tbAcesso == null) throw new MensagemException("Acesso não encontrado.");

                tbAcesso.ace_c_senha = senhaCriptografada != "" ? senhaCriptografada : tbAcesso.ace_c_senha;
                tbAcesso.ace_c_login = model.ace_c_login;
                tbAcesso.ace_per_n_codigo = model.ace_per_n_codigo;
                tbAcesso.ace_b_relacional = model.ace_b_relacional;
                tbAcesso.ace_d_atualizado = DateTime.Now;
                tbAcesso.ace_d_modificacao = DateTime.Now;

                Update(tbAcesso);
            }
            context.SaveChanges();

            if (model.ace_per_n_codigo == 11)
            {
                VincularAcessoADistribuidor(model.ace_dis_n_codigo);
            }

            model.ace_n_codigo = tbAcesso.ace_n_codigo;
            return model;
        }

        public AcessoViewModel ResetarSenha(AcessoViewModel model)
        {
            string senhaCriptografada = "";

            tb_ace_acesso tbAcesso = new tb_ace_acesso();
            tbAcesso.ace_n_codigo = model.ace_n_codigo;

            if (model != null && !string.IsNullOrEmpty(model.ace_c_senha))
            {
                senhaCriptografada = CriptografarSenha(model.ace_c_senha);
            }

            int AceCodigo = model.ace_n_codigo;
            try
            {
                if (model != null && AceCodigo == 0)
                {
                    int codEmp = Convert.ToInt32(model.ace_emp_n_codigo);
                    tbAcesso.ace_c_senha = senhaCriptografada;
                    tbAcesso.ace_c_login = model.ace_c_login;

                    if (codEmp == 0)
                    {
                        tbAcesso.ace_emp_n_codigo = null;

                    }
                    else
                    {
                        tbAcesso.ace_emp_n_codigo = codEmp;
                    }

                    tbAcesso.ace_per_n_codigo = Convert.ToInt32(model.ace_per_n_codigo);
                    tbAcesso.ace_b_relacional = Convert.ToBoolean(model.ace_b_relacional);
                    tbAcesso.ace_d_atualizado = DateTime.Now;
                    tbAcesso.ace_d_inclusao = DateTime.Now;
                    tbAcesso.ace_c_unique = Guid.NewGuid();
                    Insert(tbAcesso);
                }
                else
                {

                    tbAcesso = (from ace in context.tb_ace_acesso where ace.ace_n_codigo == AceCodigo select ace).FirstOrDefault();
                    tbAcesso.ace_c_senha = senhaCriptografada != "" ? senhaCriptografada : tbAcesso.ace_c_senha;
                    tbAcesso.ace_c_login = model.ace_c_login;
                    tbAcesso.ace_per_n_codigo = Convert.ToInt32(model.ace_per_n_codigo);
                    tbAcesso.ace_b_relacional = Convert.ToBoolean(model.ace_b_relacional);

                    tbAcesso.ace_c_login = model.ace_c_login;


                    tbAcesso.ace_d_atualizado = DateTime.Now;

                    Update(tbAcesso);
                }
                context.SaveChanges();

                model.ace_n_codigo = tbAcesso.ace_n_codigo;
            }
            catch (Exception)
            {
            }
            return model;
        }

        public bool DeletarAcesso(int id)
        {
            try
            {
                Delete(context.tb_ace_acesso.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public IPagedList<AcessoViewModel> GetAcessoFiltrado(AcessoFilterModel filter)
        {
            try
            {
                var query = (from ace in Context.tb_ace_acesso
                             orderby ace.ace_c_login
                             select new AcessoViewModel
                             {
                                 ace_n_codigo = ace.ace_n_codigo,
                                 ace_c_login = ace.ace_c_login,
                                 ace_b_relacional = ace.ace_b_relacional.Value,
                                 ace_b_relacionalDist = ace.ace_b_relacionalDist.Value,
                                 ace_emp_n_codigo = ace.ace_emp_n_codigo.Value,
                                 ace_dis_n_codigo = ace.ace_dis_n_codigo.Value
                             });

                int codDist = Convert.ToInt32(filter.ace_dis_n_codigo_filter);
                int codEmp = Convert.ToInt32(filter.ace_emp_n_codigo_filter);

                if (codEmp != 0)
                {
                    query = query.Where(w => w.ace_emp_n_codigo.Equals(codEmp));
                }
                else if (codDist != 0)
                {
                    query = query.Where(w => w.ace_dis_n_codigo.Equals(codDist));
                }
                else
                {
                    query = query.Where(w => w.ace_emp_n_codigo == null && w.ace_b_relacional.Equals(true)
                    || w.ace_dis_n_codigo == null && w.ace_b_relacionalDist.Equals(true));
                }

                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public AcessoViewModel GetAcesso(int id)
        {
            return (from ace in Context.tb_ace_acesso
                    where ace.ace_n_codigo == id
                    select new AcessoViewModel
                    {
                        ace_n_codigo = ace.ace_n_codigo,
                        ace_c_login = ace.ace_c_login,
                        ace_emp_n_codigo = Convert.ToInt32(ace.ace_emp_n_codigo),
                        ace_c_senha = ace.ace_c_senha
                    })?.FirstOrDefault() ?? new AcessoViewModel();
        }

        public bool ValidaUsuario(string usuario, string codigo)
        {
            bool NaoExiste = true;

            int id = Convert.ToInt32(codigo == null || codigo == "" || codigo == "null" || codigo == "undefined" ? "0" : codigo);

            var tbAcesso = (from ace in context.tb_ace_acesso where ace.ace_n_codigo != id && ace.ace_c_login == usuario select ace)?.FirstOrDefault();
            var tbResLoca = context.tb_rel_responsavelLocacaoSaloes.Where(x => x.rel_c_login == usuario)?.FirstOrDefault();
            var tbOpLocal = (from opl in context.tb_opl_operadorLocal where opl.opl_c_login == usuario select opl)?.FirstOrDefault();

            if (tbAcesso != null || tbResLoca != null || tbOpLocal != null)
            {
                NaoExiste = false;
            }

            return NaoExiste;
        }

        public List<AcessoViewModel> GetAllAcessos()
        {
            return (from a in context.tb_ace_acesso
                    select new AcessoViewModel()
                    {

                        ace_b_bloqueado = a.ace_b_bloqueado,
                        ace_b_relacional = Convert.ToBoolean(a.ace_b_relacional),
                        ace_c_login = a.ace_c_login,
                        ace_c_unique = a.ace_c_unique,
                        ace_d_atualizado = a.ace_d_atualizado,
                        ace_d_inclusao = a.ace_d_inclusao,
                        ace_emp_n_codigo = Convert.ToInt32(a.ace_emp_n_codigo),
                        ace_n_codigo = a.ace_n_codigo,
                        ace_per_n_codigo = Convert.ToInt32(a.ace_per_n_codigo),
                        ace_d_modificacao = a.ace_d_modificacao,
                    }).OrderBy(x => x.ace_c_login).ToList();
        }

        public object EsqueciSenha(UsuarioViewModel model)
        {
            string emailUsuario = model.emailUsuario;
            int perfil = 0;
            int id = 0;
            bool duplicado = false;
            Retorno retorno = new Retorno();


            var Pro = (from p in Context.tb_pro_proprietario where p.pro_c_email == emailUsuario select p).ToList();
            var Emp = (from e in Context.tb_emp_empresa where e.emp_c_email == emailUsuario select e).ToList();
            var Ope = (from o in Context.tb_zec_zeladorCliente where o.zec_c_email == emailUsuario select o).ToList();
            var Zec = (from z in Context.tb_zec_zeladorCliente where z.zec_c_email == emailUsuario select z).ToList();

            if (Pro.Count == 1 && Emp.Count == 0 && Ope.Count == 0 && Zec.Count == 0)
            {
                if (perfil == 0)
                {
                    perfil = 1;
                }
                else
                {
                    retorno.status = "ERROR";
                    retorno.conteudo = "DUPLICADO";
                }

            }
            if (Emp.Count == 1 && Pro.Count == 0 && Ope.Count == 0 && Zec.Count == 0)
            {
                if (perfil == 0)
                {
                    perfil = 2;
                }
                else
                {
                    retorno.status = "ERROR";
                    retorno.conteudo = "DUPLICADO";
                }
            }


            if (Zec.Count == 1 && Pro.Count == 0 && Ope.Count == 0 && Emp.Count == 0)
            {
                if (perfil == 0)
                {
                    perfil = 4;
                }
                else
                {
                    retorno.status = "ERROR";
                    retorno.conteudo = "DUPLICADO";
                }
            }
            if (Ope.Count == 1 && Pro.Count == 0 && Emp.Count == 0 && Zec.Count == 0)
            {
                if (perfil == 0)
                {
                    perfil = 5;
                }
                else
                {
                    retorno.status = "ERROR";
                    retorno.conteudo = "DUPLICADO";
                }
            }

            if (Ope.Count == 0 && Pro.Count == 0 && Emp.Count == 0 && Zec.Count == 0)
            {
                retorno.status = "null";
                retorno.conteudo = "NAO_ENCONTRADO";
            }

            if (retorno.conteudo == "NAO_ENCONTRADO" || retorno.conteudo == "DUPLICADO")
            {
                return retorno;
            }

            string path = "~\\EmailTemplate\\RecuperarSenha.html";

            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());

            CorpoEmail = CorpoEmail
                .Replace("{mensagem}", @"Atenção, segue os dados de recuperação de senha: <BR><BR>" +
                                        "<b>Login:</b> " + emailUsuario + "<BR><BR>" +
                                        "<b>Para redefinir sua senha acesse o link a seguir:</b><p style='color: #444444; font-family: 'Trebuchet MS', Helvetica, sans-serif; font-size: 16px; margin-bottom: 20px; margin-top: 20px'><a href='http://garen.portaliconnect.com.br/Login/RecuperarSenha/?id=" + id + "&email=" + emailUsuario + "' target='_blank' style='display: inline-block; font-family:  'Trebuchet MS', Helvetica, Arial, sans-serif; font-size: 16px; text-decoration: none;font-weight:normal;color:#214f97;'>Redefinir</a></p><BR><BR>"
                                        );

            return CorpoEmail.ToString();

        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_ace_acesso> listaAcessos = new List<tb_ace_acesso>();


                listaAcessos = (from a in context.tb_ace_acesso where a.ace_emp_n_codigo == null && a.ace_b_relacional == true select a).OrderBy(x => x.ace_c_login).ToList();


                foreach (var item in listaAcessos)
                {
                    DeletarAcesso(item.ace_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public bool VincularAcessoAEmpresa(int? empresaId)
        {
            try
            {
                tb_ace_acesso acesso = new tb_ace_acesso();
                List<tb_ace_acesso> listAcesso = context.tb_ace_acesso.Where(x => x.ace_emp_n_codigo == null && x.ace_b_relacional == true).ToList();

                if (listAcesso.Count() > 0)
                {
                    foreach (var item in listAcesso)
                    {
                        item.ace_emp_n_codigo = Convert.ToInt32(empresaId);
                        item.ace_per_n_codigo = 2;
                        context.tb_ace_acesso.Update(item);
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VincularAcessoADistribuidor(int? distribuidorId)
        {
            try
            {
                tb_ace_acesso acesso = new tb_ace_acesso();
                List<tb_ace_acesso> listAcesso = context.tb_ace_acesso.Where(x => x.ace_dis_n_codigo == null && x.ace_b_relacionalDist == true).ToList();

                if (listAcesso.Count() > 0)
                {
                    foreach (var item in listAcesso)
                    {
                        item.ace_dis_n_codigo = Convert.ToInt32(distribuidorId);
                        item.ace_per_n_codigo = 11;
                        context.tb_ace_acesso.Update(item);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Atualiza acesso com cod empresa gerado

        //Acesso acesso = new Acesso();
        //List<tb_ace_acesso> listAcesso = acesso.Listar(x => x.ace_emp_n_codigo == null && x.ace_b_relacional == true);
        //        foreach (var item in listAcesso)
        //        {
        //            item.ace_emp_n_codigo = emp.emp_n_codigo;
        //            item.ace_per_n_codigo = 2;
        //            item.ace_c_senha = "";
        //            acesso.InsertOrUpdate(item, false);
        //        }

        public tb_rel_responsavelLocacaoSaloes ObterPerfilResLoc(tb_ace_acesso acesso)
        {
            var ret = new tb_rel_responsavelLocacaoSaloes();
            if (!string.IsNullOrEmpty(acesso.ace_c_login) && !string.IsNullOrEmpty(acesso.ace_c_senha))
            {
                ret = context.tb_rel_responsavelLocacaoSaloes.Where(x => x.rel_c_login == acesso.ace_c_login)?.FirstOrDefault();
            }

            return ret;
        }

        private IDictionary<int, bool> GetPermissoesEdicaoOperador(int? operadorId)
        {
            var ret = new Dictionary<int, bool>();

            var temp = (from pec in Context.tb_pec_permissaoCliente
                        where pec.pec_ope_n_codigo == operadorId
                        join cli in Context.tb_cli_cliente on pec.pec_cli_n_codigo equals cli.cli_n_codigo
                        select new { EditaInfos = pec.pec_b_editaInformacoes, ClienteId = pec.pec_cli_n_codigo }).ToList();

            foreach (var item in temp)
            {
                ret.Add((int)item.ClienteId, (bool)item.EditaInfos);
            }

            return ret;
        }
        private IDictionary<int, bool> GetPermissoesEdicaoCliente(int? idCLi)
        {
            /*
             * Estamos adicioando por enquanto para os Perdis de ADMINISTRADOR (CLINTE)
             * a permissão somente de edição.
             */
            var ret = new Dictionary<int, bool>();
            ret.Add((int)idCLi, true);
            return ret;
        }

        private string GetPermissoesOperadorLocal(ref List<string> permissoes, int id)
        {
            var query = (from opl in context.tb_opl_operadorLocal
                         join gpp in context.tb_gpp_grupoPermissaoOperador on opl.opl_gpp_n_codigo equals gpp.gpp_n_codigo
                         join pgp in context.tb_pgp_permissoesGrupo on gpp.gpp_n_codigo equals pgp.pgp_gpp_n_codigo
                         join top in context.tb_top_tipoPermissaoOperador on pgp.pgp_top_n_codigo equals top.top_n_codigo
                         where opl.opl_n_codigo == id && pgp.pgp_b_checado == true
                         select top.top_c_chave).ToList();

            if (query.Contains("CadastraAvisos".ToUpper()))
            {
                permissoes.Add("ACESSAR_MURAL_MORADOR");
            }

            if (query.Contains("CadastraOperadorSistema".ToUpper()))
            {
                permissoes.Add("ACESSAR_CADASTRO_OPERADOR_LOCAL");
            }

            var stringPermissoes = string.Join(",", query);

            return stringPermissoes;
        }

        private List<string> ModulosOperadorLocal(ref List<string> permissoes, int id)
        {
            var modulos = (from opl in context.tb_opl_operadorLocal
                           join gpp in context.tb_gpp_grupoPermissaoOperador on opl.opl_gpp_n_codigo equals gpp.gpp_n_codigo
                           join mol in context.tb_mol_modulosLiberados on gpp.gpp_mol_n_codigo equals mol.mol_n_codigo
                           where opl.opl_n_codigo == id
                           select mol).FirstOrDefault();

            if (modulos != null)
            {
                if (modulos.mol_b_connectSolutions)
                {
                    permissoes.Add("ACESSAR_SOLUTION");
                }

                if (modulos.mol_b_controleDeAcesso)
                {
                    permissoes.Add("ACESSAR_ACCESS");
                }

                if (modulos.mol_b_MonitoriamentoPerimetral)
                {
                    permissoes.Add("ACESSAR_GUARD");
                }

                if (modulos.mol_b_CFTV)
                {
                    permissoes.Add("ACESSAR_VIEW");
                }
            }

            return permissoes;
        }

        public string ObterPerfilResLocOpl(string login, string senha)
        {
            var ret = new tb_rel_responsavelLocacaoSaloes();
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(senha))
            {
                ret = context.tb_rel_responsavelLocacaoSaloes.Where(x => x.rel_c_login == login)?.FirstOrDefault();
            }

            return ret == null ? "" : ret.rel_c_permissao;
        }

        public List<string> PermissoesPerfil(ref List<string> permissao)
        {
            for (var i = 0; i < clientes.Count; i++)
            {
                var tipo = (from cli in context.tb_cli_cliente where cli.cli_n_codigo == Convert.ToInt32(clientes[i]) select cli.cli_tcl_n_codigo).FirstOrDefault();

                if (tipo == 1)
                {
                    permissao.Remove("ACESSAR_RELATORIO_REFEITORIO");
                }
            }

            return permissao;
        }
        public List<string> ValidaPermissoesAdmCliente(List<string> permissoes, int? id)
        {
            var tipo = (from cli in context.tb_cli_cliente where cli.cli_n_codigo == id select cli.cli_tcl_n_codigo).FirstOrDefault();

            if (tipo != 3)
            {
                permissoes.Remove("ACESSAR_AGENDA");
                permissoes.Remove("ACESSAR_MENU_AGENDA");
                permissoes.Remove("ACESSAR_SALA_COMERCIAL");
            }

            return permissoes;
        }

        private void ValidaUsuarioInativo(bool status)
        {
            if (status == false)
            {
                throw new MensagemException("Não é possível realizar login. Usuário Inativo.");
            }
        }
    }
}
